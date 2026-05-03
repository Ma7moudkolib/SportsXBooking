import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, map, switchMap } from 'rxjs';
import { Booking } from '../../models/types';
import { environment } from '../../../environments/environment';

@Injectable({ providedIn: 'root' })
export class BookingService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = `${environment.apiUrl}/Bookings`;

  private mapBooking = (b: any): Booking => {
    const bookingDate = String(b.bookingDate).split('T')[0];
    const startTime = `${bookingDate}T${b.startTime}`;
    const endTime = `${bookingDate}T${b.endTime}`;
    return {
      id: String(b.bookingId),
      playgroundId: String(b.playgroundId),
      userId: String(b.playerId),
      startTime,
      endTime,
      status: b.status,
      totalPrice: b.totalPrice,
      playgroundName: `Playground #${b.playgroundId}`
    };
  };

  getForUser(userId: string): Observable<Booking[]> {
    return this.http.get<any[]>(this.apiUrl).pipe(
      map(list => list.map(this.mapBooking).filter(b => b.userId === userId))
    );
  }

  create(data: Omit<Booking, 'id' | 'status'>): Observable<any> {
    const start = new Date(data.startTime);
    const end = new Date(data.endTime);
    const bookingDate = start.toISOString().split('T')[0];

    const payload = {
      playerId: Number(data.userId),
      playgroundId: Number(data.playgroundId),
      bookingDate,
      startTime: `${String(start.getUTCHours()).padStart(2, '0')}:${String(start.getUTCMinutes()).padStart(2, '0')}:00`,
      endTime: `${String(end.getUTCHours()).padStart(2, '0')}:${String(end.getUTCMinutes()).padStart(2, '0')}:00`
    };

    return this.http.post(this.apiUrl, payload);
  }

  cancel(id: string): Observable<any> {
    return this.http.put(`${this.apiUrl}/cancel/${id}`, {});
  }
}
