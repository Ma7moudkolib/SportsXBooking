import { Component, inject, signal, OnInit, computed } from '@angular/core';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { PlaygroundService } from '../../../core/services/playground.service';
import { AuthService } from '../../../core/services/auth.service';
import { ToastService } from '../../../core/services/toast.service';
import { Playground } from '../../../models/types';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-owner-dashboard',
  imports: [ReactiveFormsModule, RouterLink],
  templateUrl:'./owner-dashboard.component.html',
  styleUrl:'./owner-dashboard.component.css'
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
