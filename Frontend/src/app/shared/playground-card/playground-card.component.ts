import { Component, Input } from '@angular/core';
import { RouterLink } from '@angular/router';
import { Playground } from '../../models/types';
import { ReviewService } from '../../core/services/review.service';
import { inject } from '@angular/core';

@Component({
  selector: 'app-playground-card',
  standalone: true,
  imports: [RouterLink],
  template: `
    <article class="pg-card surface-card">
      <a [routerLink]="['/playgrounds', playground.id]" class="pg-card-image-link">
        <div class="pg-card-image">
          <img [src]="playground.imageUrl" [alt]="playground.name" loading="lazy" />
          <span class="sport-chip">{{ playground.sport }}</span>
        </div>
      </a>

      <div class="pg-card-body">
        <div class="flex justify-between items-start mb-2">
          <h3 class="pg-card-title">{{ playground.name }}</h3>
          <span class="pg-price font-display">
            <b>{{ playground.pricePerHour }}</b> EGP<span class="text-muted text-sm">/hr</span>
          </span>
        </div>

        <p class="pg-location text-muted text-sm mb-3">📍 {{ playground.location }}</p>

        <div class="flex items-center gap-2 mb-4">
          <div class="stars">
            @for (s of starsArr; track $index) {
              <span class="star" [class.filled]="$index < Math.round(avgRating)">★</span>
            }
          </div>
          <span class="text-sm text-muted">({{ reviewCount }} reviews)</span>
        </div>

        <a [routerLink]="['/playgrounds', playground.id]" class="btn btn-primary btn-full">
          View & Book
        </a>
      </div>
    </article>
  `,
  styles: [`
    .pg-card {
      overflow: hidden;
      transition: transform 0.25s ease, box-shadow 0.25s ease;
      display: flex;
      flex-direction: column;
    }
    .pg-card:hover {
      transform: translateY(-4px);
      box-shadow: var(--shadow-float);
    }

    .pg-card-image-link { display: block; }
    .pg-card-image {
      position: relative;
      height: 200px;
      overflow: hidden;
    }
    .pg-card-image img {
      width: 100%;
      height: 100%;
      object-fit: cover;
      transition: transform 0.4s ease;
    }
    .pg-card:hover .pg-card-image img { transform: scale(1.05); }

    .sport-chip {
      position: absolute;
      top: 0.75rem;
      left: 0.75rem;
      background: rgba(0,31,63,0.8);
      color: var(--color-primary-fixed);
      padding: 0.25rem 0.75rem;
      border-radius: var(--radius-full);
      font-size: 0.75rem;
      font-weight: 700;
      letter-spacing: 0.04em;
      text-transform: uppercase;
      backdrop-filter: blur(8px);
    }

    .pg-card-body {
      padding: 1.25rem;
      flex: 1;
      display: flex;
      flex-direction: column;
    }

    .pg-card-title {
      font-size: 1.0625rem;
      font-weight: 600;
      color: var(--on-surface);
      margin: 0;
      line-height: 1.35;
    }

    .pg-price {
      font-size: 0.9375rem;
      color: var(--color-primary);
      white-space: nowrap;
    }
    .pg-price b { font-size: 1.25rem; color: var(--color-primary-fixed); }

    .pg-location { line-height: 1.4; }

    .stars { display: flex; gap: 1px; }
    .star { color: var(--outline-variant); font-size: 0.9rem; }
    .star.filled { color: var(--color-primary-fixed); }
  `]
})
export class PlaygroundCardComponent {
  @Input({ required: true }) playground!: Playground;

  private reviewService = inject(ReviewService);
  starsArr = [1, 2, 3, 4, 5];
  Math = Math;

  get avgRating(): number { return this.reviewService.getAverageRating(this.playground.id); }
  get reviewCount(): number { return this.reviewService.getReviewCount(this.playground.id); }
}
