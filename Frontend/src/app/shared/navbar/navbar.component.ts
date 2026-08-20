import { Component, HostListener, computed, inject, signal } from '@angular/core';
import { NgClass } from '@angular/common';
import { RouterLink, RouterLinkActive } from '@angular/router';
import { AuthService } from '../../core/services/auth.service';
import { ToastContainerComponent } from '../toast-container/toast-container.component';

@Component({
  selector: 'app-navbar',
  imports: [NgClass, RouterLink, RouterLinkActive, ToastContainerComponent],
  templateUrl:'./navbar.component.html'
})
export class NavbarComponent {
  auth = inject(AuthService);
  private scrolled = signal(false);
    // inside your component class
  isMobileMenuOpen = signal(false);

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
