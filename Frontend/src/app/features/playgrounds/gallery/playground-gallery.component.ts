import { Component, inject, signal, computed, OnInit } from '@angular/core';
import { PlaygroundService } from '../../../core/services/playground.service';
import { PlaygroundCardComponent } from '../../../shared/playground-card/playground-card.component';
import { Playground } from '../../../models/types';
import { FormsModule } from '@angular/forms';
import { AuthService } from '../../../core/services/auth.service';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-playground-gallery',
  standalone: true,
  imports: [PlaygroundCardComponent, FormsModule, RouterLink],
  template: `
    <!-- Hero -->
    <section class="hero-section">
      <div class="container hero-content">
        <p class="hero-kicker">The Performance Grid</p>
        <h1 class="hero-title">Find Your<br/><span class="hero-accent">Perfect Court</span></h1>
        <p class="hero-sub">Book premium sports venues in seconds. No phone calls. No hassle.</p>

        <!-- Search Bar -->
        <div class="search-bar glass">
          <span class="search-icon">🔍</span>
          <input
            id="search-playgrounds"
            class="search-input"
            type="text"
            placeholder="Search by name or location..."
            [(ngModel)]="searchQuery"
          />
          @if (searchQuery) {
            <button class="btn btn-ghost btn-sm" (click)="searchQuery = ''">✕</button>
          }
        </div>

        <!-- Sport Filters -->
        <div class="sport-filters">
          <button
            class="filter-chip"
            [class.active]="selectedSport() === ''"
            (click)="selectedSport.set('')"
          >All Sports</button>
          @for (sport of sports; track sport) {
            <button
              class="filter-chip"
              [class.active]="selectedSport() === sport"
              (click)="selectedSport.set(sport)"
            >{{ sport }}</button>
          }
        </div>
      </div>
    </section>

    <!-- Gallery Section -->
    <section class="page-section">
      <div class="container">
        <div class="gallery-header mb-6">
          <div>
            <h2 class="mb-1">Available Venues</h2>
            <p class="text-muted text-sm">{{ filtered().length }} playground{{ filtered().length !== 1 ? 's' : '' }} found</p>
          </div>

          @if (auth.isOwnerOrAdmin()) {
            <a routerLink="/management/playgrounds" class="btn btn-secondary btn-sm">
              + Manage My Venues
            </a>
          }
        </div>

        @if (loading()) {
          <div class="grid grid-3">
            @for (i of [1,2,3,4,5]; track i) {
              <div class="surface-card skeleton skeleton-card"></div>
            }
          </div>
        } @else if (filtered().length === 0) {
          <div class="empty-state text-center">
            <p class="empty-emoji">🏟️</p>
            <h3 class="mb-2">No playgrounds found</h3>
            <p class="text-muted">Try a different search or sport filter.</p>
          </div>
        } @else {
          <div class="grid grid-3">
            @for (pg of filtered(); track pg.id) {
              <app-playground-card [playground]="pg" />
            }
          </div>
        }
      </div>
    </section>
  `,
  styles: [`
    .hero-content { position: relative; z-index: 1; }
    .hero-kicker {
      font-size: 0.875rem;
      font-weight: 600;
      letter-spacing: 0.1em;
      text-transform: uppercase;
      color: var(--color-primary-fixed);
      margin-bottom: 1rem;
    }
    .hero-title {
      font-size: clamp(2.5rem, 5vw, 4rem);
      font-weight: 800;
      color: #fff;
      line-height: 1.1;
      letter-spacing: -0.02em;
      margin-bottom: 1rem;
    }
    .hero-accent { color: var(--color-primary-fixed); }
    .hero-sub {
      font-size: 1.125rem;
      color: rgba(255,255,255,0.7);
      margin-bottom: 2.5rem;
      max-width: 500px;
    }

    .search-bar {
      display: flex;
      align-items: center;
      border-radius: var(--radius-xl);
      padding: 0.625rem 1rem;
      gap: 0.75rem;
      max-width: 540px;
      margin-bottom: 1.5rem;
    }
    .search-icon { font-size: 1rem; }
    .search-input {
      flex: 1;
      border: none;
      background: transparent;
      font-family: var(--font-body);
      font-size: 1rem;
      color: var(--on-surface);
      outline: none;
    }
    .search-input::placeholder { color: var(--outline); }

    .sport-filters {
      display: flex;
      gap: 0.5rem;
      flex-wrap: wrap;
    }
    .filter-chip {
      padding: 0.375rem 1rem;
      border-radius: var(--radius-full);
      border: none;
      cursor: pointer;
      font-size: 0.875rem;
      font-weight: 500;
      background: rgba(255,255,255,0.15);
      color: rgba(255,255,255,0.85);
      transition: all 0.2s;
      font-family: var(--font-body);
    }
    .filter-chip:hover { background: rgba(255,255,255,0.25); }
    .filter-chip.active {
      background: var(--color-primary-fixed);
      color: #002201;
    }

    .gallery-header {
      display: flex;
      align-items: center;
      justify-content: space-between;
      flex-wrap: wrap;
      gap: 1rem;
    }

    .empty-state { padding: 4rem 1rem; }
    .empty-emoji { font-size: 4rem; margin-bottom: 1rem; }
  `]
})
export class PlaygroundGalleryComponent implements OnInit {
  private pgService = inject(PlaygroundService);
  auth = inject(AuthService);

  sports = ['Football', 'Padel', 'Tennis', 'Basketball', 'Volleyball'];
  searchQuery = '';
  selectedSport = signal('');
  loading = signal(true);
  allPlaygrounds = signal<Playground[]>([]);

  filtered = computed(() => {
    let pgs = this.allPlaygrounds();
    if (this.searchQuery.trim()) {
      const q = this.searchQuery.toLowerCase();
      pgs = pgs.filter(p => p.name.toLowerCase().includes(q) || p.location.toLowerCase().includes(q));
    }
    if (this.selectedSport()) {
      pgs = pgs.filter(p => p.sport === this.selectedSport());
    }
    return pgs;
  });

  ngOnInit() {
    this.pgService.getAll().subscribe(list => {
      this.allPlaygrounds.set(list);
      this.loading.set(false);
    });
  }
}
