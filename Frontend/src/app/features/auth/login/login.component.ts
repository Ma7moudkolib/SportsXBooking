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
    <div class="auth-layout">
      <div class="surface-card w-full max-w-[460px] rounded-2xl p-10">
        <div class="mb-8">
          <a routerLink="/" class="font-display text-xl font-extrabold tracking-tight text-primary">Sports<span class="text-accent">X</span>Booking</a>
          <h1 class="mb-1 mt-4 text-4xl">Welcome Back</h1>
          <p class="text-muted">Sign in to access your performance grid.</p>
        </div>

        <div class="mb-6 rounded-xl border border-accent/20 bg-accent/10 px-4 py-3">
          <p class="mb-1 text-xs font-semibold">Demo Mode</p>
          <p class="text-xs text-muted">Tip: Add <strong>admin</strong> or <strong>owner</strong> to your email to log in with those roles (e.g. admin&#64;test.com)</p>
        </div>

        <form [formGroup]="form" (ngSubmit)="submit()" id="login-form">
          <div class="form-group">
            <label class="form-label" for="login-email">Email Address</label>
            <div class="group rounded-xl border border-slate-300 bg-white/90 px-3 py-2 transition focus-within:border-accent focus-within:ring-2 focus-within:ring-accent/25">
              <input
                id="login-email"
                type="email"
                formControlName="email"
                class="w-full border-none bg-transparent px-1 py-1.5 text-sm text-ink outline-none"
                placeholder="coach&#64;example.com"
                autocomplete="email"
              />
            </div>
            @if (form.get('email')?.invalid && form.get('email')?.touched) {
              <p class="mt-1.5 text-xs text-rose-700">Please enter a valid email address.</p>
            }
          </div>

          <div class="form-group">
            <label class="form-label" for="login-password">Password</label>
            <div class="group rounded-xl border border-slate-300 bg-white/90 px-3 py-2 transition focus-within:border-accent focus-within:ring-2 focus-within:ring-accent/25">
              <input
                id="login-password"
                type="password"
                formControlName="password"
                class="w-full border-none bg-transparent px-1 py-1.5 text-sm text-ink outline-none"
                placeholder="••••••••"
                autocomplete="current-password"
              />
            </div>
            @if (form.get('password')?.invalid && form.get('password')?.touched) {
              <p class="mt-1.5 text-xs text-rose-700">Password is required.</p>
            }
          </div>

          @if (error()) {
            <div class="alert alert-error mb-4">{{ error() }}</div>
          }

          <button id="login-submit" type="submit" class="btn btn-primary btn-full btn-lg" [disabled]="loading()">
            {{ loading() ? 'Authenticating...' : 'Access System' }}
          </button>
        </form>

        <div class="divider"></div>
        <p class="text-center text-sm text-muted">
          No account? <a routerLink="/register" class="font-semibold text-accent">Register for access</a>
        </p>
      </div>
    </div>
  `,
  styles: []
})
export class LoginComponent implements OnInit {
  private fb = inject(FormBuilder);
  private auth = inject(AuthService);
  private router = inject(Router);
  private toast = inject(ToastService);

  form!: FormGroup;
  loading = signal(false);
  error = signal<string | null>(null);

  ngOnInit() {
    this.form = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', Validators.required]
    });

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
