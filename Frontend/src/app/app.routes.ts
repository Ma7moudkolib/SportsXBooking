import { Routes } from '@angular/router';
import { authGuard } from './core/guards/auth.guard';
import { roleGuard } from './core/guards/role.guard';

export const routes: Routes = [
  {
    path: '',
    loadComponent: () =>
      import('./features/playgrounds/gallery/playground-gallery.component').then(m => m.PlaygroundGalleryComponent),
    title: 'SportsXBooking — Find & Book Playgrounds'
  },
  {
    path: 'playgrounds/:id',
    loadComponent: () =>
      import('./features/playgrounds/detail/playground-detail.component').then(m => m.PlaygroundDetailComponent),
    title: 'SportsXBooking — Venue Details'
  },
  {
    path: 'login',
    loadComponent: () =>
      import('./features/auth/login/login.component').then(m => m.LoginComponent),
    title: 'SportsXBooking — Login'
  },
  {
    path: 'register',
    loadComponent: () =>
      import('./features/auth/register/register.component').then(m => m.RegisterComponent),
    title: 'SportsXBooking — Create Account'
  },
  {
    path: 'my-bookings',
    loadComponent: () =>
      import('./features/bookings/my-bookings/my-bookings.component').then(m => m.MyBookingsComponent),
    canActivate: [authGuard],
    title: 'SportsXBooking — My Bookings'
  },
  {
    path: 'management/playgrounds',
    loadComponent: () =>
      import('./features/management/owner-dashboard/owner-dashboard.component').then(m => m.OwnerDashboardComponent),
    canActivate: [roleGuard('Owner', 'Admin')],
    title: 'SportsXBooking — Manage Playgrounds'
  },
  {
    path: 'management/users',
    loadComponent: () =>
      import('./features/management/admin-users/admin-users.component').then(m => m.AdminUsersComponent),
    canActivate: [roleGuard('Admin')],
    title: 'SportsXBooking — Admin: User Management'
  },
  {
    path: '**',
    redirectTo: '',
    pathMatch: 'full'
  }
];
