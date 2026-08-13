import { Component, inject, signal, OnInit, computed } from '@angular/core';
import { BookingService } from '../../../core/services/booking.service';
import { PaymentService } from '../../../core/services/payment.service';
import { AuthService } from '../../../core/services/auth.service';
import { ToastService } from '../../../core/services/toast.service';
import { Booking, Payment } from '../../../models/types';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-my-bookings',
  imports: [RouterLink],
  templateUrl:'./my-bookings.component.html',
  styleUrl:'./my-bookings.component.css'
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
