import { Component, Input } from '@angular/core';
import { RouterLink } from '@angular/router';
import { Playground } from '../../models/types';
import { ReviewService } from '../../core/services/review.service';
import { inject } from '@angular/core';

@Component({
  selector: 'app-playground-card',
  imports: [RouterLink],
  templateUrl: './playground-card.component.html',
  styleUrl:'./playground-card.component.css'
})
export class PlaygroundCardComponent {
  @Input({ required: true }) playground!: Playground;

  private reviewService = inject(ReviewService);
  starsArr = [1, 2, 3, 4, 5];
  Math = Math;

  get avgRating(): number { return this.reviewService.getAverageRating(this.playground.id); }
  get reviewCount(): number { return this.reviewService.getReviewCount(this.playground.id); }
}
