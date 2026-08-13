import { Component, inject, signal, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { Router, RouterLink } from '@angular/router';
import { AuthService } from '../../../core/services/auth.service';
import { ToastService } from '../../../core/services/toast.service';

@Component({
  selector: 'app-login',
  imports: [ReactiveFormsModule, RouterLink],
  templateUrl:'./login.component.html'
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
