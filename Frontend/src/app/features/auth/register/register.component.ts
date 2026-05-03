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
    <div class="auth-layout">
      <div class="surface-card w-full max-w-[520px] rounded-2xl p-10">
        <div class="mb-8">
          <a routerLink="/" class="font-display text-xl font-extrabold tracking-tight text-primary">Sports<span class="text-accent">X</span>Booking</a>
          <h1 class="mb-1 mt-4 text-4xl">Create Account</h1>
          <p class="text-muted">Join thousands of athletes and venue owners.</p>
        </div>

        <form [formGroup]="form" (ngSubmit)="submit()" id="register-form">
          <div class="mb-5 grid grid-cols-1 gap-4 sm:grid-cols-2">
            <div>
              <label class="form-label" for="reg-firstName">First Name</label>
              <div class="group rounded-xl border border-slate-300 bg-white/90 px-3 py-2 transition focus-within:border-accent focus-within:ring-2 focus-within:ring-accent/25">
                <input id="reg-firstName" type="text" formControlName="firstName" class="w-full border-none bg-transparent px-1 py-1.5 text-sm text-ink outline-none" placeholder="John" />
              </div>
              @if (form.get('firstName')?.invalid && form.get('firstName')?.touched) {
                <p class="mt-1.5 text-xs text-rose-700">First name is required.</p>
              }
            </div>

            <div>
              <label class="form-label" for="reg-lastName">Last Name</label>
              <div class="group rounded-xl border border-slate-300 bg-white/90 px-3 py-2 transition focus-within:border-accent focus-within:ring-2 focus-within:ring-accent/25">
                <input id="reg-lastName" type="text" formControlName="lastName" class="w-full border-none bg-transparent px-1 py-1.5 text-sm text-ink outline-none" placeholder="Smith" />
              </div>
              @if (form.get('lastName')?.invalid && form.get('lastName')?.touched) {
                <p class="mt-1.5 text-xs text-rose-700">Last name is required.</p>
              }
            </div>
          </div>

          <div class="form-group">
            <label class="form-label" for="reg-email">Email Address</label>
            <div class="group rounded-xl border border-slate-300 bg-white/90 px-3 py-2 transition focus-within:border-accent focus-within:ring-2 focus-within:ring-accent/25">
              <input id="reg-email" type="email" formControlName="email" class="w-full border-none bg-transparent px-1 py-1.5 text-sm text-ink outline-none" placeholder="you@example.com" autocomplete="email" />
            </div>
            @if (form.get('email')?.invalid && form.get('email')?.touched) {
              <p class="mt-1.5 text-xs text-rose-700">A valid email is required.</p>
            }
          </div>

          <div class="form-group">
            <label class="form-label" for="reg-role">Account Type</label>
            <div class="group rounded-xl border border-slate-300 bg-white/90 px-3 py-2 transition focus-within:border-accent focus-within:ring-2 focus-within:ring-accent/25">
              <select id="reg-role" formControlName="role" class="w-full cursor-pointer border-none bg-transparent px-1 py-1.5 text-sm text-ink outline-none">
                <option value="Player">Player / Athlete</option>
                <option value="Owner">Venue Owner</option>
              </select>
            </div>
          </div>

          <div class="form-group">
            <label class="form-label" for="reg-password">Password</label>
            <div class="group rounded-xl border border-slate-300 bg-white/90 px-3 py-2 transition focus-within:border-accent focus-within:ring-2 focus-within:ring-accent/25">
              <input id="reg-password" type="password" formControlName="password" class="w-full border-none bg-transparent px-1 py-1.5 text-sm text-ink outline-none" placeholder="Min. 8 characters" autocomplete="new-password" />
            </div>
            @if (form.get('password')?.invalid && form.get('password')?.touched) {
              <p class="mt-1.5 text-xs text-rose-700">Password must be at least 8 characters.</p>
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
          Already have an account? <a routerLink="/login" class="font-semibold text-accent">Log in</a>
        </p>
      </div>
    </div>
  `,
  styles: []
})
export class RegisterComponent implements OnInit {
  private fb = inject(FormBuilder);
  private auth = inject(AuthService);
  private router = inject(Router);
  private toast = inject(ToastService);

  form!: FormGroup;
  loading = signal(false);
  error = signal<string | null>(null);

  ngOnInit() {
    this.form = this.fb.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      role: ['Player' as UserRole],
      password: ['', [Validators.required, Validators.minLength(8)]]
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
