import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, map } from 'rxjs';
import { User } from '../../models/types';
import { environment } from '../../../environments/environment';

@Injectable({ providedIn: 'root' })
export class UserService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = `${environment.apiUrl}/Users`;

  getAll(): Observable<User[]> {
    return this.http.get<any[]>(this.apiUrl).pipe(
      map((users) => users.map((u) => {
        const [firstName, ...rest] = (u.fullName as string).split(' ');
        return {
          id: String(u.userId),
          firstName,
          lastName: rest.join(' ') || '',
          email: u.email,
          role: u.role === 'Player' ? 'User' : u.role
        } as User;
      }))
    );
  }

  delete(id: string): Observable<boolean> {
    return this.http.delete(`${this.apiUrl}/${id}`).pipe(map(() => true));
  }
}
