import { Injectable, signal } from '@angular/core';
import { Observable, of, delay } from 'rxjs';
import { Review } from '../../models/types';

const MOCK_REVIEWS: Review[] = [
  { id: 'r1',  playgroundId: 'p1', userId: 'u1', rating: 5, comment: 'Incredible court quality—the glass walls and lighting are world-class!', date: '2026-04-10', userName: 'Alice J.' },
  { id: 'r2',  playgroundId: 'p1', userId: 'u2', rating: 4, comment: 'Great experience overall. A bit pricey but totally worth it.', date: '2026-04-12', userName: 'Bob M.' },
  { id: 'r3',  playgroundId: 'p1', userId: 'u3', rating: 5, comment: 'Best padel court in downtown. Book early—it fills up fast!', date: '2026-04-13', userName: 'Charlie T.' },
  { id: 'r4',  playgroundId: 'p2', userId: 'u4', rating: 5, comment: 'Perfect artificial turf. Excellent floodlights for evening games.', date: '2026-04-14', userName: 'David L.' },
  { id: 'r5',  playgroundId: 'p2', userId: 'u5', rating: 3, comment: 'Good pitch, but the parking situation is a nightmare on weekends.', date: '2026-04-15', userName: 'Eve S.' },
  { id: 'r6',  playgroundId: 'p3', userId: 'u1', rating: 5, comment: 'Flawless clay court. Maintained so well it plays like a pro tournament.', date: '2026-04-16', userName: 'Alice J.' },
  { id: 'r7',  playgroundId: 'p3', userId: 'u6', rating: 4, comment: 'Well-maintained surface, though it gets very hot in the afternoon.',  date: '2026-04-17', userName: 'Frank R.' },
  { id: 'r8',  playgroundId: 'p4', userId: 'u2', rating: 5, comment: 'Perfect indoor conditions. The hardwood floor is absolutely pristine.', date: '2026-04-18', userName: 'Bob M.' },
  { id: 'r9',  playgroundId: 'p4', userId: 'u7', rating: 2, comment: 'The AC system broke down during our booking. Disappointing.', date: '2026-04-18', userName: 'Grace W.' },
  { id: 'r10', playgroundId: 'p5', userId: 'u8', rating: 5, comment: 'Nothing beats volleyball at sunset on this court. Absolute paradise!', date: '2026-04-19', userName: 'Heidi P.' },
];

@Injectable({ providedIn: 'root' })
export class ReviewService {
  private _store = signal<Review[]>(MOCK_REVIEWS);

  getForPlayground(playgroundId: string): Observable<Review[]> {
    return of(this._store().filter(r => r.playgroundId === playgroundId)).pipe(delay(400));
  }

  getAverageRating(playgroundId: string): number {
    const reviews = this._store().filter(r => r.playgroundId === playgroundId);
    if (!reviews.length) return 0;
    return reviews.reduce((s, r) => s + r.rating, 0) / reviews.length;
  }

  getReviewCount(playgroundId: string): number {
    return this._store().filter(r => r.playgroundId === playgroundId).length;
  }
}
