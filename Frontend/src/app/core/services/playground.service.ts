import { Injectable, signal, computed } from '@angular/core';
import { Observable, of, delay, tap } from 'rxjs';
import { Playground } from '../../models/types';

const MOCK_PLAYGROUNDS: Playground[] = [
  {
    id: 'p1', name: 'Elite Padel Court', location: 'Downtown Sports Complex, Cairo',
    pricePerHour: 45, ownerId: 'u_owner1', sport: 'Padel',
    description: 'Premium panoramic glass padel court equipped with advanced LED lighting and a Hawkeye ball-tracking system. Ideal for competitive play.',
    imageUrl: 'https://images.unsplash.com/photo-1628120610931-1e967a659345?auto=format&fit=crop&q=80&w=800'
  },
  {
    id: 'p2', name: 'City Football Pitch', location: 'Northside Sports Park, Cairo',
    pricePerHour: 80, ownerId: 'u_owner1', sport: 'Football',
    description: 'FIFA-compliant 7-a-side artificial turf pitch with full floodlights, electronic scoreboards, and changing facilities on-site.',
    imageUrl: 'https://images.unsplash.com/photo-1574629810360-7efbc51b0f5b?auto=format&fit=crop&q=80&w=800'
  },
  {
    id: 'p3', name: 'Pro Tennis Court', location: 'West End Club, Alexandria',
    pricePerHour: 55, ownerId: 'u_owner2', sport: 'Tennis',
    description: 'Internationally graded clay court maintained daily by certified groundskeepers. Ball machine and coaching rackets available on request.',
    imageUrl: 'https://images.unsplash.com/photo-1595435934249-5df7ed86e1c0?auto=format&fit=crop&q=80&w=800'
  },
  {
    id: 'p4', name: 'Hoops Basketball Gym', location: 'Central Rec Center, Giza',
    pricePerHour: 35, ownerId: 'u_owner2', sport: 'Basketball',
    description: 'Indoor hardwood basketball court with climate control. Available in full-court or half-court configurations with pro-grade hoops.',
    imageUrl: 'https://images.unsplash.com/photo-1504450758481-7338eba7524a?auto=format&fit=crop&q=80&w=800'
  },
  {
    id: 'p5', name: 'Sunset Beach Volleyball', location: 'Beachfront Cove, North Coast',
    pricePerHour: 20, ownerId: 'u_owner3', sport: 'Volleyball',
    description: 'Professional-grade beach volleyball court with freshly sifted sand and panoramic water views. Available for sunset and evening sessions.',
    imageUrl: 'https://images.unsplash.com/photo-1612872087720-bb876e2e67d1?auto=format&fit=crop&q=80&w=800'
  }
];

@Injectable({ providedIn: 'root' })
export class PlaygroundService {
  private _store = signal<Playground[]>(MOCK_PLAYGROUNDS);

  readonly playgrounds = computed(() => this._store());

  getAll(): Observable<Playground[]> {
    return of(this._store()).pipe(delay(500));
  }

  getById(id: string): Observable<Playground | undefined> {
    return of(this._store().find(p => p.id === id)).pipe(delay(300));
  }

  getByOwner(ownerId: string): Observable<Playground[]> {
    return of(this._store().filter(p => p.ownerId === ownerId)).pipe(delay(400));
  }

  create(data: Omit<Playground, 'id'>): Observable<Playground> {
    const newPg: Playground = { ...data, id: `p${Date.now()}` };
    return of(newPg).pipe(
      delay(700),
      tap(pg => this._store.update(list => [...list, pg]))
    );
  }

  update(id: string, data: Partial<Playground>): Observable<Playground | undefined> {
    const idx = this._store().findIndex(p => p.id === id);
    if (idx === -1) return of(undefined).pipe(delay(400));
    const updated = { ...this._store()[idx], ...data };
    return of(updated).pipe(
      delay(600),
      tap(pg => this._store.update(list => { const c = [...list]; c[idx] = pg; return c; }))
    );
  }
}
