import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, map } from 'rxjs';
import { CreatePlayground, Playground } from '../../models/types';
import { environment } from '../../../environments/environment';

@Injectable({ providedIn: 'root' })
export class PlaygroundService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = `${environment.apiUrl}/Playgrounds`;

  private mapPlayground = (p: any): Playground => ({
    id: String(p.playgroundId),
    name: p.name,
    location: p.location,
    pricePerHour: p.pricePerHour,
    ownerId: String(p.ownerId ?? ''),
    description: p.description ?? `${p.sportType} venue in ${p.location}`,
    imageUrl: p.imageUrl,
    sport: p.sportType
  });

  getAll(): Observable<Playground[]> {
    return this.http.get<any[]>(this.apiUrl).pipe(map(list => list.map(this.mapPlayground)));
  }

  getById(id: string): Observable<Playground | undefined> {
    return this.http.get<any>(`${this.apiUrl}/${id}`).pipe(map(this.mapPlayground));
  }

  getByOwner(ownerId: string): Observable<Playground[]> {
    return this.http.get<any[]>(`${this.apiUrl}/owner/${ownerId}`).pipe(map(list => list.map(this.mapPlayground)));
  }

  create(data: Omit<CreatePlayground, 'id'>): Observable<any> {
  const formData = new FormData();
  formData.append('OwnerId', String(Number(data.ownerId)));
  formData.append('Name', data.name);
  formData.append('Location', data.location);
  formData.append('SportType', data.sport ?? 'Football');
  formData.append('PricePerHour', String(data.pricePerHour));

  if (data.imageFile) {
    formData.append('Image', data.imageFile);
  }

  return this.http.post(`${this.apiUrl}/create`, formData);
}

  update(id: string, data: Partial<Playground>): Observable<any> {
    const payload = {
      name: data.name,
      location: data.location,
      sportType: data.sport,
      pricePerHour: data.pricePerHour,
      imageUrl: data.imageUrl
    };
    return this.http.put(`${this.apiUrl}/${id}`, payload);
  }
}
