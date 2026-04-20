import { Component, inject } from '@angular/core';
import { ToastService } from '../../core/services/toast.service';

@Component({
  selector: 'app-toast-container',
  standalone: true,
  template: `
    <div class="toast-container" role="status" aria-live="polite">
      @for (toast of toastService.toasts(); track toast.id) {
        <div class="toast" [class]="'toast-' + toast.type">
          <span>{{ toast.type === 'success' ? '✓' : '✕' }}</span>
          {{ toast.message }}
        </div>
      }
    </div>
  `,
  styles: [`
    .toast-container {
      position: fixed;
      top: calc(var(--nav-height) + 1rem);
      right: 1.5rem;
      z-index: 10001;
      display: flex;
      flex-direction: column;
      gap: 0.75rem;
      pointer-events: none;
    }
    .toast {
      display: flex;
      align-items: center;
      gap: 0.625rem;
      padding: 0.875rem 1.25rem;
      border-radius: var(--radius-lg);
      font-weight: 500;
      font-size: 0.9rem;
      box-shadow: var(--shadow-float);
      animation: slideInRight 0.3s ease;
      min-width: 280px;
      max-width: 380px;
      pointer-events: auto;
    }
    .toast-success { background: var(--inverse-surface); color: var(--inverse-on-surface); }
    .toast-error   { background: var(--color-error); color: #fff; }
  `]
})
export class ToastContainerComponent {
  toastService = inject(ToastService);
}
