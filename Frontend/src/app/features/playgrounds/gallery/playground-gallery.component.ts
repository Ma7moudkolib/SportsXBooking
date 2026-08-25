import { Component, inject, signal, computed, OnInit } from '@angular/core';
import { PlaygroundService } from '../../../core/services/playground.service';
import { PlaygroundCardComponent } from '../../../shared/playground-card/playground-card.component';
import { Playground } from '../../../models/types';
import { FormsModule, NgModel } from '@angular/forms';
import { AuthService } from '../../../core/services/auth.service';
import { RouterLink } from '@angular/router';
import { NgClass } from '@angular/common';

@Component({
  selector: 'app-playground-gallery',
  imports: [PlaygroundCardComponent, FormsModule, RouterLink,NgClass],
  templateUrl:'./playground-gallery.component.html',
  styleUrl:'./playground-gallery.component.css'
})
export class PlaygroundGalleryComponent implements OnInit {
  private pgService = inject(PlaygroundService);
  auth = inject(AuthService);

  sports = ['Football', 'Padel', 'Tennis', 'Basketball', 'Volleyball'];
  searchQuery = signal('');
  selectedSport = signal('');
  loading = signal(true);
  allPlaygrounds = signal<Playground[]>([]);
  currentPage = signal(1);
  pageSize = 12;

  filtered = computed(() => {
    let pgs = this.allPlaygrounds();

    if (this.searchQuery().trim()) {

      const q = this.searchQuery().toLowerCase();
      pgs = pgs.filter(p => p.name.toLowerCase().includes(q) || p.location.toLowerCase().includes(q));

    }
    if (this.selectedSport()) {
      pgs = pgs.filter(p => p.sport === this.selectedSport());
    }

    return pgs;
  });

  totalPages = computed(() => Math.max(1, Math.ceil(this.filtered().length / this.pageSize)));

  paginated = computed(() => {
  const start = (this.currentPage() - 1) * this.pageSize;
  return this.filtered().slice(start, start + this.pageSize);
  });

  // Windowed page numbers so you don't render 40 buttons on a big list
  pageNumbers = computed(() => {
    const total = this.totalPages();
    const current = this.currentPage();
    const delta = 2;
    const range: number[] = [];
    for (let i = Math.max(1, current - delta); i <= Math.min(total, current + delta); i++) {
      range.push(i);
    }
    return range;
  });

  goToPage(page: number) {
    if (page < 1 || page > this.totalPages() || page === this.currentPage()) return;
    this.currentPage.set(page);
    window.scrollTo({ top: 500, behavior: 'smooth' });
  }

  ngOnInit() {
    this.pgService.getAll().subscribe(list => {
      this.allPlaygrounds.set(list);
      this.loading.set(false);
    });
  }
}
