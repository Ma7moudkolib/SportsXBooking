import { Injectable, inject, signal } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, map, tap } from 'rxjs';
import { Review } from '../../models/types';
import { environment } from '../../../environments/environment';

@Injectable({ providedIn: 'root' })
export class ReviewService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = `${environment.apiUrl}/Reviews`;
  private readonly cache = signal<Review[]>([]);

  getForPlayground(playgroundId: string): Observable<Review[]> {
    return this.http.get<any[]>(`${this.apiUrl}/playground/${playgroundId}`).pipe(
      map((reviews) => reviews.map((r) => ({
        id: String(r.reviewId ?? ''),
        playgroundId: String(r.playgroundId),
        userId: String(r.playerId),
        rating: r.rating,
        comment: r.comment,
        date: new Date(r.createdAt ?? Date.now()).toISOString().split('T')[0],
        userName: `User ${r.playerId}`
      } as Review))),
      tap((reviews) => this.cache.set(reviews))
    );
  }

  getAverageRating(playgroundId: string): number {
    const reviews = this.cache().filter(r => r.playgroundId === playgroundId);
    if (!reviews.length) return 0;
    return reviews.reduce((s, r) => s + r.rating, 0) / reviews.length;
  }

  getReviewCount(playgroundId: string): number {
    return this.cache().filter(r => r.playgroundId === playgroundId).length;
  }
}
