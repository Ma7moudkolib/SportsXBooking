import { Injectable, signal } from '@angular/core';
import { Observable, of, delay } from 'rxjs';
import { Payment } from '../../models/types';

const MOCK_PAYMENTS: Payment[] = [
  { id: 'pay1', bookingId: 'b1', amount: 45,  status: 'Completed', transactionDate: '2026-04-18T10:15:00Z' },
  { id: 'pay2', bookingId: 'b2', amount: 120, status: 'Completed', transactionDate: '2026-04-19T14:20:00Z' },
  { id: 'pay3', bookingId: 'b3', amount: 110, status: 'Refunded',  transactionDate: '2026-04-16T09:05:00Z' },
];

@Injectable({ providedIn: 'root' })
export class PaymentService {
  private _store = signal<Payment[]>(MOCK_PAYMENTS);

  getById(id: string): Observable<Payment | undefined> {
    return of(this._store().find(p => p.id === id)).pipe(delay(300));
  }

  getByBookingId(bookingId: string): Observable<Payment | undefined> {
    return of(this._store().find(p => p.bookingId === bookingId)).pipe(delay(300));
  }
}
