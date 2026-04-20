import { Component, inject, signal, OnInit, computed } from '@angular/core';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { PlaygroundService } from '../../../core/services/playground.service';
import { AuthService } from '../../../core/services/auth.service';
import { ToastService } from '../../../core/services/toast.service';
import { Playground } from '../../../models/types';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-owner-dashboard',
  standalone: true,
  imports: [ReactiveFormsModule, RouterLink],
  template: `
    <div class="dashboard-layout" style="margin-top:var(--nav-height);">
      <!-- Sidebar -->
      <aside class="sidebar">
        <div class="sidebar-logo mb-6">
          <p class="text-xs text-muted font-semi mb-1" style="text-transform:uppercase;letter-spacing:.08em;">Owner Hub</p>
          <h4 class="text-primary" style="margin:0;">{{ auth.currentUser()?.firstName }}'s Venues</h4>
        </div>

        <button class="sidebar-item active">
          🏟️ My Playgrounds
        </button>
        <button class="sidebar-item" (click)="showForm.set(!showForm())">
          ➕ Add New Venue
        </button>
        <a routerLink="/" class="sidebar-item">← Back to Gallery</a>
      </aside>

      <!-- Content -->
      <main class="sidebar-content">
        <!-- Create Form -->
        @if (showForm()) {
          <div class="surface-card p-6 mb-8">
            <h3 class="mb-6">{{ editing() ? 'Edit Playground' : 'Add New Venue' }}</h3>
            <form [formGroup]="form" (ngSubmit)="submitForm()" id="create-playground-form">
              <div class="form-row">
                <div class="form-group">
                  <label class="form-label" for="pg-name">Venue Name</label>
                  <input id="pg-name" type="text" formControlName="name" class="form-control" placeholder="Elite Padel Court" />
                </div>
                <div class="form-group">
                  <label class="form-label" for="pg-sport">Sport</label>
                  <select id="pg-sport" formControlName="sport" class="form-control">
                    <option>Football</option>
                    <option>Padel</option>
                    <option>Tennis</option>
                    <option>Basketball</option>
                    <option>Volleyball</option>
                  </select>
                </div>
              </div>
              <div class="form-row">
                <div class="form-group">
                  <label class="form-label" for="pg-location">Location</label>
                  <input id="pg-location" type="text" formControlName="location" class="form-control" placeholder="City, District" />
                </div>
                <div class="form-group">
                  <label class="form-label" for="pg-price">Price / Hour (EGP)</label>
                  <input id="pg-price" type="number" formControlName="pricePerHour" class="form-control" placeholder="50" min="0" />
                </div>
              </div>
              <div class="form-group">
                <label class="form-label" for="pg-desc">Description</label>
                <textarea id="pg-desc" formControlName="description" class="form-control" rows="3" placeholder="Describe your venue..."></textarea>
              </div>
              <div class="flex gap-3 justify-end">
                <button type="button" class="btn btn-secondary" (click)="cancelForm()">Cancel</button>
                <button type="submit" class="btn btn-primary" [disabled]="formLoading()">
                  {{ formLoading() ? 'Saving...' : (editing() ? 'Save Changes' : 'Create Venue') }}
                </button>
              </div>
            </form>
          </div>
        }

        <!-- Playground List -->
        <div class="flex items-center justify-between mb-6">
          <h2>My Playgrounds <span class="text-muted text-sm">({{ myPlaygrounds().length }})</span></h2>
          @if (!showForm()) {
            <button class="btn btn-primary btn-sm" (click)="showForm.set(true)" id="add-playground-btn">
              + Add Venue
            </button>
          }
        </div>

        @if (pgLoading()) {
          <p class="text-muted">Loading...</p>
        } @else if (myPlaygrounds().length === 0) {
          <div class="surface-card p-8 text-center">
            <p style="font-size:3rem">🏟️</p>
            <h4 class="mb-2">No venues yet</h4>
            <p class="text-muted mb-4">Create your first venue to start accepting bookings.</p>
            <button class="btn btn-primary" (click)="showForm.set(true)">Add First Venue</button>
          </div>
        } @else {
          <div class="pg-table-wrapper">
            <table class="data-table">
              <thead>
                <tr>
                  <th>Venue Name</th>
                  <th>Sport</th>
                  <th>Location</th>
                  <th>Price/hr</th>
                  <th>Actions</th>
                </tr>
              </thead>
              <tbody>
                @for (pg of myPlaygrounds(); track pg.id) {
                  <tr>
                    <td class="font-semi">{{ pg.name }}</td>
                    <td>
                      <span class="badge" style="background:var(--surface-container);color:var(--on-surface-variant);">
                        {{ pg.sport }}
                      </span>
                    </td>
                    <td class="text-muted text-sm">{{ pg.location }}</td>
                    <td class="font-semi" style="color:var(--color-primary-fixed);">{{ pg.pricePerHour }} EGP</td>
                    <td>
                      <button class="btn btn-secondary btn-sm" (click)="editPlayground(pg)" [id]="'edit-pg-' + pg.id">Edit</button>
                    </td>
                  </tr>
                }
              </tbody>
            </table>
          </div>
        }
      </main>
    </div>
  `,
  styles: [`
    .form-row {
      display: grid;
      grid-template-columns: 1fr 1fr;
      gap: 1rem;
    }
    textarea.form-control {
      resize: vertical;
      min-height: 80px;
    }
    .pg-table-wrapper { overflow-x: auto; }
    .sidebar-logo { padding: 0 1rem; }
  `]
})
export class OwnerDashboardComponent implements OnInit {
  private fb         = inject(FormBuilder);
  private pgService  = inject(PlaygroundService);
  auth               = inject(AuthService);
  private toast      = inject(ToastService);

  myPlaygrounds = signal<Playground[]>([]);
  pgLoading     = signal(true);
  showForm      = signal(false);
  formLoading   = signal(false);
  editing       = signal<Playground | null>(null);
  form!: FormGroup;

  ngOnInit() {
    this.buildForm();
    const ownerId = this.auth.currentUser()?.id ?? 'u_owner1';
    this.pgService.getByOwner(ownerId).subscribe(pgs => {
      this.myPlaygrounds.set(pgs);
      this.pgLoading.set(false);
    });
  }

  buildForm(pg?: Playground) {
    const ownerId = this.auth.currentUser()?.id ?? 'u_owner1';
    this.form = this.fb.group({
      name:        [pg?.name ?? '',         Validators.required],
      sport:       [pg?.sport ?? 'Football'],
      location:    [pg?.location ?? '',     Validators.required],
      pricePerHour:[pg?.pricePerHour ?? '', Validators.required],
      description: [pg?.description ?? ''],
      ownerId:     [ownerId],
      imageUrl:    ['https://images.unsplash.com/photo-1574629810360-7efbc51b0f5b?auto=format&fit=crop&q=80&w=800']
    });
  }

  editPlayground(pg: Playground) {
    this.editing.set(pg);
    this.buildForm(pg);
    this.showForm.set(true);
  }

  cancelForm() {
    this.editing.set(null);
    this.buildForm();
    this.showForm.set(false);
  }

  submitForm() {
    this.form.markAllAsTouched();
    if (this.form.invalid) return;
    this.formLoading.set(true);
    const editPg = this.editing();

    const obs = editPg
      ? this.pgService.update(editPg.id, this.form.value)
      : this.pgService.create(this.form.value);

    obs.subscribe({
      next: () => {
        this.formLoading.set(false);
        const ownerId = this.auth.currentUser()?.id ?? 'u_owner1';
        this.pgService.getByOwner(ownerId).subscribe(pgs => this.myPlaygrounds.set(pgs));
        this.toast.show(editPg ? 'Venue updated!' : 'Venue created! 🎉', 'success');
        this.cancelForm();
      },
      error: () => {
        this.formLoading.set(false);
        this.toast.show('Error saving venue.', 'error');
      }
    });
  }
}
