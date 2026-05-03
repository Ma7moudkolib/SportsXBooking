import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, map } from 'rxjs';
import { Payment } from '../../models/types';
import { environment } from '../../../environments/environment';

@Injectable({ providedIn: 'root' })
export class PaymentService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = `${environment.apiUrl}/Payments`;

  getById(id: string): Observable<Payment | undefined> {
    return this.http.get<any>(`${this.apiUrl}/${id}`).pipe(map((p) => this.mapPayment(p)));
  }

  getByBookingId(bookingId: string): Observable<Payment | undefined> {
    return this.http.get<any>(`${this.apiUrl}/${bookingId}`).pipe(map((p) => this.mapPayment(p)));
  }

  private mapPayment(p: any): Payment {
    return {
      id: String(p.paymentId),
      bookingId: String(p.bookingId),
      amount: p.amount,
      status: p.paymentStatus === 'Paid' ? 'Completed' : p.paymentStatus,
      transactionDate: new Date().toISOString()
    };
  }
}
