import { Component, inject, signal, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { Router, RouterLink } from '@angular/router';
import { AuthService } from '../../../core/services/auth.service';
import { ToastService } from '../../../core/services/toast.service';
import { UserRole } from '../../../models/types';

@Component({
  selector: 'app-register',
  imports: [ReactiveFormsModule, RouterLink],
  templateUrl:'./register.component.html',
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
      phone: ['',[Validators.required]],
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
