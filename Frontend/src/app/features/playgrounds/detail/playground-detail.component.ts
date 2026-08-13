import { Component, inject, signal, OnInit } from '@angular/core';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { PlaygroundService } from '../../../core/services/playground.service';
import { ReviewService } from '../../../core/services/review.service';
import { AuthService } from '../../../core/services/auth.service';
import { Playground, Review } from '../../../models/types';
import { CreateBookingModalComponent } from '../../bookings/create-booking-modal/create-booking-modal.component';

@Component({
  selector: 'app-playground-detail',
  imports: [RouterLink, CreateBookingModalComponent],
  templateUrl:'./playground-detail.component.html',
  styleUrl:'./playground-detail.component.css'

})
export class PlaygroundDetailComponent implements OnInit {
  private route     = inject(ActivatedRoute);
  private pgService = inject(PlaygroundService);
  private rvService = inject(ReviewService);
  auth = inject(AuthService);

  playground    = signal<Playground | null>(null);
  reviews       = signal<Review[]>([]);
  loading       = signal(true);
  reviewLoading = signal(true);
  showBooking   = signal(false);

  avgRating = signal(0);

  ngOnInit() {
    const id = this.route.snapshot.paramMap.get('id') ?? '';
    this.pgService.getById(id).subscribe(pg => {
      this.playground.set(pg ?? null);
      this.loading.set(false);
    });
    this.rvService.getForPlayground(id).subscribe(rvs => {
      this.reviews.set(rvs);
      this.avgRating.set(rvs.length ? rvs.reduce((s, r) => s + r.rating, 0) / rvs.length : 0);
      this.reviewLoading.set(false);
    });
  }
}
