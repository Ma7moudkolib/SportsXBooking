import { Component, HostListener, computed, inject, signal } from '@angular/core';
import { NgClass } from '@angular/common';
import { NavigationEnd, Router, RouterLink, RouterLinkActive } from '@angular/router';
import { AuthService } from '../../core/services/auth.service';
import { ToastContainerComponent } from '../toast-container/toast-container.component';
import { toSignal } from '@angular/core/rxjs-interop';
import { filter, map } from 'rxjs';

@Component({
  selector: 'app-navbar',
  imports: [NgClass, RouterLink, RouterLinkActive, ToastContainerComponent],
  templateUrl:'./navbar.component.html'
})
export class NavbarComponent {
  auth = inject(AuthService);
  private scrolled = signal(false);
    private router = inject(Router);
    // inside your component class
  isMobileMenuOpen = signal(false);
 // Tracks the current URL as a signal, updating on every navigation
  private currentUrl = toSignal(
    this.router.events.pipe(
      filter((event): event is NavigationEnd => event instanceof NavigationEnd),
      map(event => event.urlAfterRedirects)
    ),
    { initialValue: this.router.url }
  );

  // True on /login or /register (and any nested/query-param variants of them)
  isAuthPage = computed(() => {
    const url = this.currentUrl().split('?')[0].split('#')[0];
    return url === '/login' || url === '/register';
  });
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


toggleMobileMenu() {
  this.isMobileMenuOpen.update(v => !v);
}

closeMobileMenu() {
  this.isMobileMenuOpen.set(false);
}

  logout() {
    this.auth.logout();
  }
}
