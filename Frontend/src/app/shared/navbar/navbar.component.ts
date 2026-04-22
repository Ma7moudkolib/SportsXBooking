import { Component, HostListener, computed, inject, signal } from '@angular/core';
import { NgClass } from '@angular/common';
import { RouterLink, RouterLinkActive } from '@angular/router';
import { AuthService } from '../../core/services/auth.service';
import { ToastContainerComponent } from '../toast-container/toast-container.component';

@Component({
  selector: 'app-navbar',
  standalone: true,
  imports: [NgClass, RouterLink, RouterLinkActive, ToastContainerComponent],
  template: `
    <header
      class="fixed inset-x-0 top-0 z-[1000] h-18 border-b transition-all duration-300"
      [ngClass]="navbarClasses()"
    >
      <div class="container flex h-full items-center justify-between">
        <a routerLink="/" class="font-display text-xl font-extrabold tracking-tight text-secondary">
          Sports<span class="text-accent">X</span>Booking
        </a>

        <nav class="flex items-center gap-3 md:gap-6" role="navigation">
          <a
            routerLink="/"
            routerLinkActive="text-accent border-accent"
            [routerLinkActiveOptions]="{ exact: true }"
            class="border-b-2 border-transparent pb-1 text-sm font-medium text-slate-100 transition hover:text-secondary"
          >Playgrounds</a>

          @if (auth.isAuthenticated()) {
            <a
              routerLink="/my-bookings"
              routerLinkActive="text-accent border-accent"
              class="border-b-2 border-transparent pb-1 text-sm font-medium text-slate-100 transition hover:text-secondary"
            >My Bookings</a>

            @if (auth.isOwnerOrAdmin()) {
              <a
                routerLink="/management/playgrounds"
                routerLinkActive="text-accent border-accent"
                class="border-b-2 border-transparent pb-1 text-sm font-medium text-slate-100 transition hover:text-secondary"
              >Manage</a>
            }

            @if (auth.userRole() === 'Admin') {
              <a
                routerLink="/management/users"
                routerLinkActive="text-accent border-accent"
                class="border-b-2 border-transparent pb-1 text-sm font-medium text-slate-100 transition hover:text-secondary"
              >Admin</a>
            }

            <div class="hidden items-center gap-3 border-l border-slate-300/40 pl-4 sm:flex">
              <span class="text-sm font-semibold text-secondary">{{ auth.currentUser()?.firstName }}</span>
              <span class="rounded-full bg-slate-100 px-2.5 py-1 text-[10px] font-bold uppercase tracking-wider text-primary">{{ auth.userRole() }}</span>
              <button class="btn btn-secondary btn-sm" (click)="logout()">Logout</button>
            </div>
          } @else {
            <a routerLink="/login" class="btn btn-secondary btn-sm">Login</a>
            <a routerLink="/register" class="btn btn-primary btn-sm">Sign Up</a>
          }
        </nav>
      </div>
    </header>

    <app-toast-container />
  `,
  styles: []
})
export class NavbarComponent {
  auth = inject(AuthService);
  private scrolled = signal(false);

  navbarClasses = computed(() => {
    if (this.scrolled()) {
      return 'border-primary/40 bg-primary/95 shadow-lg backdrop-blur-xl';
    }

    return 'border-white/15 bg-primary/30 backdrop-blur-md';
  });

  @HostListener('window:scroll')
  onWindowScroll() {
    this.scrolled.set(window.scrollY > 16);
  }

  logout() {
    this.auth.logout();
  }
}
