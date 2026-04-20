import { Component, inject, signal, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { Router, RouterLink } from '@angular/router';
import { AuthService } from '../../../core/services/auth.service';
import { ToastService } from '../../../core/services/toast.service';
import { UserRole } from '../../../models/types';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [ReactiveFormsModule, RouterLink],
  template: `
    <div class="auth-page">
      <div class="auth-panel surface-card">
        <div class="auth-header mb-8">
          <a routerLink="/" class="back-logo">Sports<span>X</span>Booking</a>
          <h1 class="mt-4 mb-1">Create Account</h1>
          <p class="text-muted">Join thousands of athletes and venue owners.</p>
        </div>

        <form [formGroup]="form" (ngSubmit)="submit()" id="register-form">
          <div class="form-row">
            <div class="form-group">
              <label class="form-label" for="reg-firstName">First Name</label>
              <input id="reg-firstName" type="text" formControlName="firstName" class="form-control" placeholder="John" />
              @if (form.get('firstName')?.invalid && form.get('firstName')?.touched) {
                <p class="field-error">First name is required.</p>
              }
            </div>
            <div class="form-group">
              <label class="form-label" for="reg-lastName">Last Name</label>
              <input id="reg-lastName" type="text" formControlName="lastName" class="form-control" placeholder="Smith" />
              @if (form.get('lastName')?.invalid && form.get('lastName')?.touched) {
                <p class="field-error">Last name is required.</p>
              }
            </div>
          </div>

          <div class="form-group">
            <label class="form-label" for="reg-email">Email Address</label>
            <input id="reg-email" type="email" formControlName="email" class="form-control" placeholder="you@example.com" autocomplete="email" />
            @if (form.get('email')?.invalid && form.get('email')?.touched) {
              <p class="field-error">A valid email is required.</p>
            }
          </div>

          <div class="form-group">
            <label class="form-label" for="reg-role">Account Type</label>
            <select id="reg-role" formControlName="role" class="form-control">
              <option value="User">Player / Athlete</option>
              <option value="Owner">Venue Owner</option>
            </select>
          </div>

          <div class="form-group">
            <label class="form-label" for="reg-password">Password</label>
            <input id="reg-password" type="password" formControlName="password" class="form-control" placeholder="Min. 8 characters" autocomplete="new-password" />
            @if (form.get('password')?.invalid && form.get('password')?.touched) {
              <p class="field-error">Password must be at least 8 characters.</p>
            }
          </div>

          @if (error()) {
            <div class="alert alert-error mb-4">{{ error() }}</div>
          }

          <button id="register-submit" type="submit" class="btn btn-primary btn-full btn-lg" [disabled]="loading()">
            {{ loading() ? 'Creating Account...' : 'Create Account' }}
          </button>
        </form>

        <div class="divider"></div>
        <p class="text-center text-sm text-muted">
          Already have an account? <a routerLink="/login" class="text-accent font-semi">Log in</a>
        </p>
      </div>
    </div>
  `,
  styles: [`
    .auth-page {
      min-height: 100vh;
      background: linear-gradient(160deg, var(--color-primary) 0%, #002d5c 60%, var(--surface) 100%);
      display: flex;
      align-items: center;
      justify-content: center;
      padding: 2rem 1rem;
    }
    .auth-panel {
      width: 100%;
      max-width: 520px;
      padding: 2.5rem;
      box-shadow: var(--shadow-ambient);
    }
    .back-logo {
      font-family: var(--font-display);
      font-weight: 700;
      font-size: 1.25rem;
      color: var(--color-primary);
      text-decoration: none;
      letter-spacing: -0.02em;
    }
    .back-logo span { color: var(--color-primary-fixed); }
    .form-row {
      display: grid;
      grid-template-columns: 1fr 1fr;
      gap: 1rem;
    }
    .field-error {
      font-size: 0.8rem;
      color: var(--color-error);
      margin-top: 0.375rem;
    }
    select.form-control { cursor: pointer; }
  `]
})
export class RegisterComponent implements OnInit {
  private fb     = inject(FormBuilder);
  private auth   = inject(AuthService);
  private router = inject(Router);
  private toast  = inject(ToastService);

  form!: FormGroup;
  loading = signal(false);
  error   = signal<string | null>(null);

  ngOnInit() {
    this.form = this.fb.group({
      firstName: ['', Validators.required],
      lastName:  ['', Validators.required],
      email:     ['', [Validators.required, Validators.email]],
      role:      ['User' as UserRole],
      password:  ['', [Validators.required, Validators.minLength(8)]]
    });
    if (this.auth.isAuthenticated()) this.router.navigate(['/']);
  }

  submit() {
    this.form.markAllAsTouched();
    if (this.form.invalid) return;
    this.loading.set(true);
    this.error.set(null);

    this.auth.register(this.form.value).subscribe({
      next: (res) => {
        this.loading.set(false);
        this.toast.show(`Account created! Welcome, ${res.user.firstName}!`, 'success');
        this.router.navigate(['/']);
      },
      error: () => {
        this.loading.set(false);
        this.error.set('Registration failed. Please try again.');
      }
    });
  }
}
