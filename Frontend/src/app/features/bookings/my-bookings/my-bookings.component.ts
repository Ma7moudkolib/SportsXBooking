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
    <div class="main-layout bg-surface-low">
      <div class="container py-10">
        <div class="mb-8 flex flex-wrap items-center justify-between gap-4">
          <div>
            <h1 class="mb-1">My Bookings</h1>
            <p class="text-muted">Manage your upcoming and past reservations.</p>
          </div>
          <a routerLink="/" class="btn btn-primary btn-action">+ Book a Venue</a>
        </div>

        <div class="mb-8 grid gap-4 md:grid-cols-3">
          @for (stat of stats(); track stat.label) {
            <div class="surface-card p-6 text-center">
              <span class="mb-1 block font-display text-4xl font-bold text-primary">{{ stat.value }}</span>
              <span class="text-sm text-muted">{{ stat.label }}</span>
            </div>
          }
        </div>

        @if (loading()) {
          <div class="text-center text-muted">Loading bookings...</div>
        } @else if (bookings().length === 0) {
          <div class="surface-card p-8 text-center">
            <p class="mb-4 text-5xl">📅</p>
            <h3 class="mb-2">No bookings yet</h3>
            <p class="mb-6 text-muted">Head to the gallery to find and book your next venue.</p>
            <a routerLink="/" class="btn btn-primary">Browse Playgrounds</a>
          </div>
        } @else {
          <div class="flex flex-col gap-4">
            @for (b of bookings(); track b.id) {
              <div class="surface-card p-6">
                <div class="mb-5 flex flex-wrap items-start justify-between gap-4">
                  <div>
                    <h4 class="mb-1">{{ b.playgroundName }}</h4>
                    <p class="text-sm text-muted">
                      📅 {{ formatDate(b.startTime) }} — {{ formatTime(b.startTime) }} to {{ formatTime(b.endTime) }}
                    </p>
                  </div>
                  <span [class]="statusBadgeClass(b.status)">{{ b.status }}</span>
                </div>

                <div class="flex flex-wrap items-center justify-between gap-3 border-t border-slate-200 pt-4">
                  <div class="flex items-center gap-4 font-display text-primary">
                    <b class="text-2xl">{{ b.totalPrice }}</b> EGP
                    <button class="btn btn-ghost btn-sm text-muted" (click)="viewPayment(b.id)" id="view-payment-{{ b.id }}">View Transaction</button>
                  </div>

                  @if (b.status !== 'Cancelled') {
                    <button class="btn btn-danger btn-sm" id="cancel-booking-{{ b.id }}" [disabled]="cancelling() === b.id" (click)="cancelBooking(b.id)">
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

    @if (activePayment()) {
      <div class="modal-overlay" (click)="closePayment($event)">
        <div class="modal-box">
          <div class="mb-6 flex items-center justify-between">
            <h3>Transaction Details</h3>
            <button class="btn btn-ghost btn-sm" (click)="activePayment.set(null)">✕</button>
          </div>

          <div class="flex items-center justify-between border-b border-slate-200 py-3.5">
            <span class="text-sm text-muted">Transaction ID</span>
            <span class="text-sm font-semibold" style="font-family:monospace;">{{ activePayment()!.id }}</span>
          </div>
          <div class="flex items-center justify-between border-b border-slate-200 py-3.5">
            <span class="text-sm text-muted">Booking ID</span>
            <span class="text-sm font-semibold" style="font-family:monospace;">{{ activePayment()!.bookingId }}</span>
          </div>
          <div class="flex items-center justify-between border-b border-slate-200 py-3.5">
            <span class="text-sm text-muted">Amount</span>
            <span class="font-semibold text-accent">{{ activePayment()!.amount }} EGP</span>
          </div>
          <div class="flex items-center justify-between border-b border-slate-200 py-3.5">
            <span class="text-sm text-muted">Status</span>
            <span [class]="paymentStatusBadgeClass(activePayment()!.status)">{{ activePayment()!.status }}</span>
          </div>
          <div class="flex items-center justify-between py-3.5">
            <span class="text-sm text-muted">Date</span>
            <span class="text-sm">{{ formatDate(activePayment()!.transactionDate) }}</span>
          </div>
        </div>
      </div>
    }
  `,
  styles: []
})
export class MyBookingsComponent implements OnInit {
  private bookingService = inject(BookingService);
  private paymentService = inject(PaymentService);
  private auth = inject(AuthService);
  private toast = inject(ToastService);

  bookings = signal<Booking[]>([]);
  loading = signal(true);
  cancelling = signal<string | null>(null);
  activePayment = signal<Payment | null>(null);

  stats = computed(() => {
    const bks = this.bookings();
    return [
      { label: 'Total Bookings', value: bks.length },
      { label: 'Confirmed', value: bks.filter(b => b.status === 'Confirmed').length },
      { label: 'Total Spent (EGP)', value: bks.filter(b => b.status !== 'Cancelled').reduce((s, b) => s + b.totalPrice, 0) }
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

  statusBadgeClass(status: string): string {
    const base = 'inline-flex items-center rounded-full px-3 py-1 text-xs font-bold uppercase tracking-wide';
    return {
      Confirmed: `${base} bg-emerald-100 text-emerald-800`,
      Pending: `${base} bg-amber-100 text-amber-800`,
      Cancelled: `${base} bg-rose-100 text-rose-700`
    }[status] ?? `${base} bg-slate-100 text-slate-700`;
  }

  paymentStatusBadgeClass(status: string): string {
    const base = 'inline-flex items-center rounded-full px-3 py-1 text-xs font-bold uppercase tracking-wide';
    return {
      Completed: `${base} bg-emerald-100 text-emerald-800`,
      Refunded: `${base} bg-amber-100 text-amber-800`,
      Failed: `${base} bg-rose-100 text-rose-700`
    }[status] ?? `${base} bg-slate-100 text-slate-700`;
  }

  formatDate(iso: string): string {
    return new Date(iso).toLocaleDateString('en-GB', { day: 'numeric', month: 'short', year: 'numeric' });
  }

  formatTime(iso: string): string {
    return new Date(iso).toLocaleTimeString('en-GB', { hour: '2-digit', minute: '2-digit' });
  }
}
