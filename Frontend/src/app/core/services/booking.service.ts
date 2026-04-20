import { Injectable, signal, computed } from '@angular/core';
import { Observable, of, delay, tap } from 'rxjs';
import { Booking, BookingStatus } from '../../models/types';

const MOCK_BOOKINGS: Booking[] = [
  { id: 'b1', playgroundId: 'p1', userId: 'u1', startTime: '2026-04-22T10:00:00Z', endTime: '2026-04-22T11:00:00Z', status: 'Confirmed',  totalPrice: 45,  playgroundName: 'Elite Padel Court' },
  { id: 'b2', playgroundId: 'p2', userId: 'u1', startTime: '2026-04-25T18:00:00Z', endTime: '2026-04-25T19:30:00Z', status: 'Pending',    totalPrice: 120, playgroundName: 'City Football Pitch' },
  { id: 'b3', playgroundId: 'p3', userId: 'u1', startTime: '2026-04-18T09:00:00Z', endTime: '2026-04-18T11:00:00Z', status: 'Cancelled',  totalPrice: 110, playgroundName: 'Pro Tennis Court' },
];

@Injectable({ providedIn: 'root' })
export class BookingService {
  private _store = signal<Booking[]>(MOCK_BOOKINGS);

  readonly bookings = computed(() => this._store());

  getForUser(userId: string): Observable<Booking[]> {
    return of(this._store().filter(b => b.userId === userId)).pipe(delay(500));
  }

  create(data: Omit<Booking, 'id' | 'status'>): Observable<Booking> {
    const newBooking: Booking = { ...data, id: `b${Date.now()}`, status: 'Pending' };
    return of(newBooking).pipe(
      delay(700),
      tap(b => this._store.update(list => [...list, b]))
    );
  }

  // PUT /api/bookings/{id}/cancel — matches BookingsController.CancelBooking
  cancel(id: string): Observable<Booking | undefined> {
    const idx = this._store().findIndex(b => b.id === id);
    if (idx === -1) return of(undefined).pipe(delay(400));
    const updated: Booking = { ...this._store()[idx], status: 'Cancelled' };
    return of(updated).pipe(
      delay(600),
      tap(b => this._store.update(list => { const c = [...list]; c[idx] = b; return c; }))
    );
  }
}
