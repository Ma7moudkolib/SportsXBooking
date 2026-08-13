import { Component, inject, signal, computed, OnInit } from '@angular/core';
import { PlaygroundService } from '../../../core/services/playground.service';
import { PlaygroundCardComponent } from '../../../shared/playground-card/playground-card.component';
import { Playground } from '../../../models/types';
import { FormsModule } from '@angular/forms';
import { AuthService } from '../../../core/services/auth.service';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-playground-gallery',
  imports: [PlaygroundCardComponent, FormsModule, RouterLink],
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

  filtered = computed(() => {
    let pgs = this.allPlaygrounds();
    console.log(this.searchQuery().trim());
    if (this.searchQuery().trim()) {
      const q = this.searchQuery().toLowerCase();
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
