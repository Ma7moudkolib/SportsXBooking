import { Component, inject, signal, OnInit } from '@angular/core';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { PlaygroundService } from '../../../core/services/playground.service';
import { ReviewService } from '../../../core/services/review.service';
import { AuthService } from '../../../core/services/auth.service';
import { Playground, Review } from '../../../models/types';
import { CreateBookingModalComponent } from '../../bookings/create-booking-modal/create-booking-modal.component';

@Component({
  selector: 'app-playground-detail',
  standalone: true,
  imports: [RouterLink, CreateBookingModalComponent],
  template: `
    @if (loading()) {
      <div class="page-wrapper container" style="padding-top: 8rem;">
        <div class="skeleton skeleton-title mb-4" style="width:40%;height:2.5rem;"></div>
        <div class="skeleton skeleton-card" style="height:400px;border-radius:var(--radius-xl);"></div>
      </div>
    } @else if (!playground()) {
      <div class="page-wrapper container text-center" style="padding-top:8rem;">
        <h2>Playground not found</h2>
        <a routerLink="/" class="btn btn-primary mt-4">Back to Gallery</a>
      </div>
    } @else {
      <!-- Hero Image -->
      <div class="detail-hero">
        <img [src]="playground()!.imageUrl" [alt]="playground()!.name" />
        <div class="detail-hero-overlay">
          <div class="container">
            <a routerLink="/" class="breadcrumb">← All Playgrounds</a>
            <div class="hero-meta">
              <span class="sport-chip-lg">{{ playground()!.sport }}</span>
            </div>
            <h1 class="detail-title">{{ playground()!.name }}</h1>
            <p class="detail-location">📍 {{ playground()!.location }}</p>
          </div>
        </div>
      </div>

      <!-- Content -->
      <div class="page-section">
        <div class="container">
          <div class="detail-grid">
            <!-- Left: Info + Reviews -->
            <div class="detail-main">
              <!-- Description -->
              <div class="surface-card p-6 mb-6">
                <h3 class="mb-3">About this Venue</h3>
                <p class="text-muted" style="line-height:1.8;">{{ playground()!.description }}</p>
              </div>

              <!-- Rating Summary -->
              <div class="surface-card p-6 mb-6">
                <div class="flex items-center justify-between mb-4">
                  <h3>Player Reviews</h3>
                  <div class="flex items-center gap-2">
                    <div class="stars">
                      @for (s of [1,2,3,4,5]; track s) {
                        <span class="star" [class.filled]="s <= avgRating()">★</span>
                      }
                    </div>
                    <span class="text-muted text-sm">{{ avgRating().toFixed(1) }} ({{ reviews().length }} reviews)</span>
                  </div>
                </div>

                @if (reviewLoading()) {
                  <p class="text-muted">Loading reviews...</p>
                } @else if (reviews().length === 0) {
                  <p class="text-muted">No reviews yet. Be the first to book!</p>
                } @else {
                  <div class="reviews-list">
                    @for (r of reviews(); track r.id) {
                      <div class="review-item">
                        <div class="review-header">
                          <div class="review-avatar">{{ r.userName.charAt(0) }}</div>
                          <div>
                            <p class="font-semi text-sm">{{ r.userName }}</p>
                            <p class="text-xs text-muted">{{ r.date }}</p>
                          </div>
                          <div class="stars ml-auto">
                            @for (s of [1,2,3,4,5]; track s) {
                              <span class="star sm" [class.filled]="s <= r.rating">★</span>
                            }
                          </div>
                        </div>
                        <p class="review-comment text-muted text-sm">{{ r.comment }}</p>
                      </div>
                    }
                  </div>
                }
              </div>
            </div>

            <!-- Right: Booking CTA -->
            <aside class="detail-aside">
              <div class="surface-card p-6 booking-cta-card">
                <div class="price-display mb-4">
                  <span class="price-big font-display">{{ playground()!.pricePerHour }}</span>
                  <span class="price-unit text-muted">EGP / hour</span>
                </div>

                <div class="divider"></div>

                @if (auth.isAuthenticated()) {
                  <button id="open-booking-btn" class="btn btn-primary btn-full btn-lg mb-3" (click)="showBooking.set(true)">
                    🗓 Book This Venue
                  </button>
                } @else {
                  <a routerLink="/login" class="btn btn-primary btn-full btn-lg mb-3">
                    Log In to Book
                  </a>
                }

                <p class="text-center text-xs text-muted">Free cancellation up to 24 hours before</p>
              </div>
            </aside>
          </div>
        </div>
      </div>
    }

    @if (showBooking() && playground()) {
      <app-create-booking-modal
        [playground]="playground()!"
        (close)="showBooking.set(false)"
      />
    }
  `,
  styles: [`
    .detail-hero {
      position: relative;
      height: 420px;
      overflow: hidden;
      margin-top: var(--nav-height);
    }
    .detail-hero img {
      width: 100%;
      height: 100%;
      object-fit: cover;
    }
    .detail-hero-overlay {
      position: absolute;
      inset: 0;
      background: linear-gradient(to top, rgba(0,15,30,0.85) 0%, rgba(0,15,30,0.3) 60%, transparent 100%);
      display: flex;
      align-items: flex-end;
      padding-bottom: 2.5rem;
    }
    .breadcrumb {
      display: inline-block;
      color: rgba(255,255,255,0.7);
      font-size: 0.875rem;
      text-decoration: none;
      margin-bottom: 1rem;
      transition: color 0.2s;
    }
    .breadcrumb:hover { color: #fff; }
    .hero-meta { margin-bottom: 0.75rem; }
    .sport-chip-lg {
      background: rgba(50,205,50,0.2);
      color: var(--color-primary-fixed);
      padding: 0.3rem 0.9rem;
      border-radius: var(--radius-full);
      font-size: 0.8rem;
      font-weight: 700;
      letter-spacing: 0.05em;
      text-transform: uppercase;
      backdrop-filter: blur(8px);
    }
    .detail-title {
      color: #fff;
      font-size: clamp(1.75rem, 4vw, 2.75rem);
      margin-bottom: 0.5rem;
    }
    .detail-location { color: rgba(255,255,255,0.75); font-size: 1rem; }

    .detail-grid {
      display: grid;
      grid-template-columns: 1fr 340px;
      gap: 2rem;
      align-items: start;
    }
    @media (max-width: 900px) {
      .detail-grid { grid-template-columns: 1fr; }
    }

    .booking-cta-card { position: sticky; top: calc(var(--nav-height) + 1.5rem); }

    .price-display { text-align: center; }
    .price-big {
      font-size: 3rem;
      font-weight: 800;
      color: var(--color-primary);
      display: block;
      line-height: 1;
    }
    .price-unit { font-size: 1rem; }

    .reviews-list { display: flex; flex-direction: column; gap: 1.25rem; }
    .review-item {
      padding-bottom: 1.25rem;
      border-bottom: 1px solid rgba(196,198,207,0.13);
    }
    .review-item:last-child { border-bottom: none; padding-bottom: 0; }
    .review-header {
      display: flex;
      align-items: center;
      gap: 0.75rem;
      margin-bottom: 0.5rem;
    }
    .review-avatar {
      width: 36px;
      height: 36px;
      border-radius: 50%;
      background: linear-gradient(135deg, var(--color-primary), #002d5c);
      color: #fff;
      display: flex;
      align-items: center;
      justify-content: center;
      font-weight: 700;
      font-size: 0.9rem;
      flex-shrink: 0;
    }
    .review-comment { margin-top: 0.25rem; line-height: 1.6; }
    .ml-auto { margin-left: auto; }
    .stars { display: flex; gap: 1px; }
    .star { font-size: 1rem; color: var(--outline-variant); }
    .star.sm { font-size: 0.8rem; }
    .star.filled { color: var(--color-primary-fixed); }
  `]
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
