import { Component, inject, signal, OnInit, computed } from '@angular/core';
import { BookingService } from '../../../core/services/booking.service';
import { PaymentService } from '../../../core/services/payment.service';
import { AuthService } from '../../../core/services/auth.service';
import { ToastService } from '../../../core/services/toast.service';
import { Booking, Payment } from '../../../models/types';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-my-bookings',
  standalone: true,
  imports: [RouterLink],
  template: `
    <div class="page-wrapper" style="background:var(--surface-container-low);min-height:100vh;">
      <div class="container" style="padding-top:2.5rem;padding-bottom:3rem;">
        <!-- Page Header -->
        <div class="flex items-center justify-between mb-8">
          <div>
            <h1 class="mb-1">My Bookings</h1>
            <p class="text-muted">Manage your upcoming and past reservations.</p>
          </div>
          <a routerLink="/" class="btn btn-primary">+ Book a Venue</a>
        </div>

        <!-- Stats Row -->
        <div class="stats-row mb-8">
          @for (stat of stats(); track stat.label) {
            <div class="stat-card surface-card">
              <span class="stat-number font-display">{{ stat.value }}</span>
              <span class="stat-label text-muted text-sm">{{ stat.label }}</span>
            </div>
          }
        </div>

        @if (loading()) {
          <div class="text-center text-muted">Loading bookings...</div>
        } @else if (bookings().length === 0) {
          <div class="empty-state surface-card text-center p-8">
            <p style="font-size:3rem;margin-bottom:1rem;">📅</p>
            <h3 class="mb-2">No bookings yet</h3>
            <p class="text-muted mb-6">Head to the gallery to find and book your next venue.</p>
            <a routerLink="/" class="btn btn-primary">Browse Playgrounds</a>
          </div>
        } @else {
          <div class="bookings-list">
            @for (b of bookings(); track b.id) {
              <div class="booking-card surface-card">
                <div class="booking-card-header">
                  <div class="booking-info">
                    <h4 class="mb-1">{{ b.playgroundName }}</h4>
                    <p class="text-sm text-muted">
                      📅 {{ formatDate(b.startTime) }} — {{ formatTime(b.startTime) }} to {{ formatTime(b.endTime) }}
                    </p>
                  </div>
                  <span class="badge" [class]="badgeClass(b.status)">{{ b.status }}</span>
                </div>

                <div class="booking-card-footer">
                  <div class="price-tag font-display">
                    <b>{{ b.totalPrice }}</b> EGP
                    <button
                      class="btn btn-ghost btn-sm text-muted"
                      (click)="viewPayment(b.id)"
                      id="view-payment-{{ b.id }}"
                    >View Transaction</button>
                  </div>

                  @if (b.status !== 'Cancelled') {
                    <button
                      class="btn btn-danger btn-sm"
                      id="cancel-booking-{{ b.id }}"
                      [disabled]="cancelling() === b.id"
                      (click)="cancelBooking(b.id)"
                    >
                      {{ cancelling() === b.id ? 'Cancelling...' : 'Cancel Booking' }}
                    </button>
                  }
                </div>
              </div>
            }
          </div>
        }
      </div>
    </div>

    <!-- Payment Modal -->
    @if (activePayment()) {
      <div class="modal-overlay" (click)="closePayment($event)">
        <div class="modal-box">
          <div class="flex items-center justify-between mb-6">
            <h3>Transaction Details</h3>
            <button class="btn btn-ghost btn-sm" (click)="activePayment.set(null)">✕</button>
          </div>

          <div class="payment-detail-row">
            <span class="text-muted text-sm">Transaction ID</span>
            <span class="font-semi text-sm" style="font-family:monospace;">{{ activePayment()!.id }}</span>
          </div>
          <div class="payment-detail-row">
            <span class="text-muted text-sm">Booking ID</span>
            <span class="font-semi text-sm" style="font-family:monospace;">{{ activePayment()!.bookingId }}</span>
          </div>
          <div class="payment-detail-row">
            <span class="text-muted text-sm">Amount</span>
            <span class="font-semi" style="color:var(--color-primary-fixed);">{{ activePayment()!.amount }} EGP</span>
          </div>
          <div class="payment-detail-row">
            <span class="text-muted text-sm">Status</span>
            <span class="badge" [class]="paymentBadgeClass(activePayment()!.status)">{{ activePayment()!.status }}</span>
          </div>
          <div class="payment-detail-row">
            <span class="text-muted text-sm">Date</span>
            <span class="text-sm">{{ formatDate(activePayment()!.transactionDate) }}</span>
          </div>
        </div>
      </div>
    }
  `,
  styles: [`
    .stats-row {
      display: grid;
      grid-template-columns: repeat(3, 1fr);
      gap: 1rem;
    }
    .stat-card {
      padding: 1.5rem;
      text-align: center;
    }
    .stat-number {
      display: block;
      font-size: 2.5rem;
      font-weight: 700;
      color: var(--color-primary);
      line-height: 1;
      margin-bottom: 0.375rem;
    }

    .bookings-list { display: flex; flex-direction: column; gap: 1rem; }
    .booking-card { padding: 1.5rem; }
    .booking-card-header {
      display: flex;
      align-items: flex-start;
      justify-content: space-between;
      gap: 1rem;
      margin-bottom: 1.25rem;
    }
    .booking-card-footer {
      display: flex;
      align-items: center;
      justify-content: space-between;
      padding-top: 1rem;
      border-top: 1px solid rgba(196,198,207,0.12);
    }
    .price-tag {
      display: flex;
      align-items: center;
      gap: 1rem;
    }
    .price-tag b { font-size: 1.375rem; color: var(--color-primary); }

    .payment-detail-row {
      display: flex;
      align-items: center;
      justify-content: space-between;
      padding: 0.875rem 0;
      border-bottom: 1px solid rgba(196,198,207,0.1);
    }
    .payment-detail-row:last-child { border-bottom: none; }

    @media (max-width: 600px) {
      .stats-row { grid-template-columns: 1fr; }
      .booking-card-footer { flex-direction: column; align-items: flex-start; gap: 0.75rem; }
    }
  `]
})
export class MyBookingsComponent implements OnInit {
  private bookingService = inject(BookingService);
  private paymentService = inject(PaymentService);
  private auth           = inject(AuthService);
  private toast          = inject(ToastService);

  bookings      = signal<Booking[]>([]);
  loading       = signal(true);
  cancelling    = signal<string | null>(null);
  activePayment = signal<Payment | null>(null);

  stats = computed(() => {
    const bks = this.bookings();
    return [
      { label: 'Total Bookings',   value: bks.length },
      { label: 'Confirmed',        value: bks.filter(b => b.status === 'Confirmed').length },
      { label: 'Total Spent (EGP)',value: bks.filter(b => b.status !== 'Cancelled').reduce((s, b) => s + b.totalPrice, 0) }
    ];
  });

  ngOnInit() {
    const userId = this.auth.currentUser()?.id ?? 'u1';
    this.bookingService.getForUser(userId).subscribe(bks => {
      this.bookings.set(bks);
      this.loading.set(false);
    });
  }

  cancelBooking(id: string) {
    this.cancelling.set(id);
    this.bookingService.cancel(id).subscribe({
      next: () => {
        this.cancelling.set(null);
        // Signal-based update—service updates its store, re-fetch to sync local signal
        const userId = this.auth.currentUser()?.id ?? 'u1';
        this.bookingService.getForUser(userId).subscribe(bks => this.bookings.set(bks));
        this.toast.show('Booking cancelled successfully.', 'success');
      },
      error: () => {
        this.cancelling.set(null);
        this.toast.show('Failed to cancel booking.', 'error');
      }
    });
  }

  viewPayment(bookingId: string) {
    this.paymentService.getByBookingId(bookingId).subscribe(p => {
      if (p) this.activePayment.set(p);
      else this.toast.show('No payment record found for this booking.', 'error');
    });
  }

  closePayment(event: MouseEvent) {
    if ((event.target as HTMLElement).classList.contains('modal-overlay')) {
      this.activePayment.set(null);
    }
  }

  badgeClass(status: string): string {
    return { Confirmed: 'badge-confirmed', Pending: 'badge-pending', Cancelled: 'badge-cancelled' }[status] ?? '';
  }

  paymentBadgeClass(status: string): string {
    return { Completed: 'badge-confirmed', Refunded: 'badge-pending', Failed: 'badge-cancelled' }[status] ?? '';
  }

  formatDate(iso: string): string {
    return new Date(iso).toLocaleDateString('en-GB', { day: 'numeric', month: 'short', year: 'numeric' });
  }

  formatTime(iso: string): string {
    return new Date(iso).toLocaleTimeString('en-GB', { hour: '2-digit', minute: '2-digit' });
  }
}
