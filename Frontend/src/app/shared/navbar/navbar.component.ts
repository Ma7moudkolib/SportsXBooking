import { Component, inject, computed } from '@angular/core';
import { RouterLink, RouterLinkActive } from '@angular/router';
import { AuthService } from '../../core/services/auth.service';
import { ToastContainerComponent } from '../toast-container/toast-container.component';

@Component({
  selector: 'app-navbar',
  standalone: true,
  imports: [RouterLink, RouterLinkActive, ToastContainerComponent],
  template: `
    <header class="navbar glass">
      <div class="container navbar-inner">
        <!-- Logo -->
        <a routerLink="/" class="logo">
          Sports<span>X</span>Booking
        </a>

        <!-- Nav Links -->
        <nav class="nav-links" role="navigation">
          <a routerLink="/" routerLinkActive="nav-active" [routerLinkActiveOptions]="{exact:true}" class="nav-link">Playgrounds</a>

          @if (auth.isAuthenticated()) {
            <a routerLink="/my-bookings" routerLinkActive="nav-active" class="nav-link">My Bookings</a>

            @if (auth.isOwnerOrAdmin()) {
              <a routerLink="/management/playgrounds" routerLinkActive="nav-active" class="nav-link">Manage</a>
            }

            @if (auth.userRole() === 'Admin') {
              <a routerLink="/management/users" routerLinkActive="nav-active" class="nav-link">Admin</a>
            }

            <div class="user-pill">
              <span class="user-name">{{ auth.currentUser()?.firstName }}</span>
              <span class="role-chip">{{ auth.userRole() }}</span>
              <button class="btn btn-secondary btn-sm" (click)="logout()">Logout</button>
            </div>
          } @else {
            <a routerLink="/login"    class="btn btn-secondary btn-sm">Login</a>
            <a routerLink="/register" class="btn btn-primary   btn-sm">Sign Up</a>
          }
        </nav>
      </div>
    </header>

    <app-toast-container />
  `,
  styles: [`
    .navbar {
      position: fixed;
      top: 0; left: 0; right: 0;
      height: var(--nav-height);
      z-index: 1000;
      border-bottom: 1px solid rgba(196,198,207,0.18);
    }

    .navbar-inner {
      display: flex;
      align-items: center;
      justify-content: space-between;
      height: 100%;
    }

    .logo {
      font-family: var(--font-display);
      font-size: 1.375rem;
      font-weight: 700;
      letter-spacing: -0.02em;
      color: var(--color-primary);
      text-decoration: none;
    }
    .logo span { color: var(--color-primary-fixed); }

    .nav-links {
      display: flex;
      align-items: center;
      gap: 1.75rem;
    }

    .nav-link {
      font-size: 0.9375rem;
      font-weight: 500;
      color: var(--on-surface-variant);
      text-decoration: none;
      position: relative;
      transition: color 0.2s;
    }
    .nav-link:hover { color: var(--on-surface); }
    .nav-active {
      color: var(--color-primary);
      font-weight: 600;
    }
    .nav-active::after {
      content: '';
      position: absolute;
      bottom: -4px; left: 0; right: 0;
      height: 2px;
      background: var(--color-primary-fixed);
      border-radius: 2px;
    }

    .user-pill {
      display: flex;
      align-items: center;
      gap: 0.75rem;
      padding-left: 1.25rem;
      border-left: 1px solid rgba(196,198,207,0.25);
    }
    .user-name {
      font-weight: 600;
      font-size: 0.875rem;
      color: var(--color-primary);
    }
    .role-chip {
      padding: 0.2rem 0.6rem;
      border-radius: var(--radius-full);
      background: var(--surface-container);
      font-size: 0.7rem;
      font-weight: 700;
      letter-spacing: 0.06em;
      text-transform: uppercase;
      color: var(--on-surface-variant);
    }
  `]
})
export class NavbarComponent {
  auth = inject(AuthService);

  logout() {
    this.auth.logout();
  }
}
