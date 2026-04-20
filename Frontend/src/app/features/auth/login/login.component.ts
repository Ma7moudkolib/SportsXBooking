import { Component, inject, signal, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { Router, RouterLink } from '@angular/router';
import { AuthService } from '../../../core/services/auth.service';
import { ToastService } from '../../../core/services/toast.service';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [ReactiveFormsModule, RouterLink],
  template: `
    <div class="auth-page">
      <div class="auth-panel surface-card">
        <!-- Header -->
        <div class="auth-header mb-8">
          <a routerLink="/" class="back-logo">Sports<span>X</span>Booking</a>
          <h1 class="mt-4 mb-1">Welcome Back</h1>
          <p class="text-muted">Sign in to access your performance grid.</p>
        </div>

        <!-- Demo hint -->
        <div class="demo-hint mb-6">
          <p class="text-xs font-semi mb-1">🎯 Demo Mode</p>
          <p class="text-xs text-muted">Tip: Add <strong>admin</strong> or <strong>owner</strong> to your email to log in with those roles (e.g. admin&#64;test.com)</p>
        </div>

        <form [formGroup]="form" (ngSubmit)="submit()" id="login-form">
          <div class="form-group">
            <label class="form-label" for="login-email">Email Address</label>
            <input
              id="login-email" type="email"
              formControlName="email"
              class="form-control"
              placeholder="coach&#64;example.com"
              autocomplete="email"
            />
            @if (form.get('email')?.invalid && form.get('email')?.touched) {
              <p class="field-error">Please enter a valid email address.</p>
            }
          </div>

          <div class="form-group">
            <label class="form-label" for="login-password">Password</label>
            <input
              id="login-password" type="password"
              formControlName="password"
              class="form-control"
              placeholder="••••••••"
              autocomplete="current-password"
            />
            @if (form.get('password')?.invalid && form.get('password')?.touched) {
              <p class="field-error">Password is required.</p>
            }
          </div>

          @if (error()) {
            <div class="alert alert-error mb-4">{{ error() }}</div>
          }

          <button
            id="login-submit"
            type="submit"
            class="btn btn-primary btn-full btn-lg"
            [disabled]="loading()"
          >
            {{ loading() ? 'Authenticating...' : 'Access System' }}
          </button>
        </form>

        <div class="divider"></div>
        <p class="text-center text-sm text-muted">
          No account? <a routerLink="/register" class="text-accent font-semi">Register for access</a>
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
      max-width: 460px;
      padding: 2.5rem;
      box-shadow: var(--shadow-ambient);
    }

    .auth-header {}
    .back-logo {
      font-family: var(--font-display);
      font-weight: 700;
      font-size: 1.25rem;
      color: var(--color-primary);
      text-decoration: none;
      letter-spacing: -0.02em;
    }
    .back-logo span { color: var(--color-primary-fixed); }

    .demo-hint {
      background: rgba(50,205,50,0.08);
      border-radius: var(--radius-md);
      padding: 0.875rem 1rem;
    }

    .field-error {
      font-size: 0.8rem;
      color: var(--color-error);
      margin-top: 0.375rem;
    }
  `]
})
export class LoginComponent implements OnInit {
  private fb     = inject(FormBuilder);
  private auth   = inject(AuthService);
  private router = inject(Router);
  private toast  = inject(ToastService);

  form!: FormGroup;
  loading = signal(false);
  error   = signal<string | null>(null);

  ngOnInit() {
    this.form = this.fb.group({
      email:    ['', [Validators.required, Validators.email]],
      password: ['', Validators.required]
    });

    // Redirect if already logged in
    if (this.auth.isAuthenticated()) this.router.navigate(['/']);
  }

  submit() {
    this.form.markAllAsTouched();
    if (this.form.invalid) return;
    this.loading.set(true);
    this.error.set(null);

    this.auth.login(this.form.value).subscribe({
      next: (res) => {
        this.loading.set(false);
        this.toast.show(`Welcome back, ${res.user.firstName}!`, 'success');
        this.router.navigate(['/']);
      },
      error: () => {
        this.loading.set(false);
        this.error.set('Invalid credentials. Please try again.');
      }
    });
  }
}
