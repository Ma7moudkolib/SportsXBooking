import { Injectable, signal, computed } from '@angular/core';
import { Observable, of, delay, tap } from 'rxjs';
import { User } from '../../models/types';

const MOCK_USERS: User[] = [
  { id: 'admin1',    firstName: 'Admin',   lastName: 'Super',    email: 'admin@sportsx.com',        role: 'Admin' },
  { id: 'u_owner1',  firstName: 'Charlie', lastName: 'Owner',    email: 'charlie.owner@example.com', role: 'Owner' },
  { id: 'u_owner2',  firstName: 'Diana',   lastName: 'Owner',    email: 'diana.owner@example.com',   role: 'Owner' },
  { id: 'u_owner3',  firstName: 'Ivan',    lastName: 'Owner',    email: 'ivan.owner@example.com',    role: 'Owner' },
  { id: 'u1',        firstName: 'Alice',   lastName: 'Johnson',  email: 'alice.j@example.com',       role: 'User' },
  { id: 'u2',        firstName: 'Bob',     lastName: 'Smith',    email: 'bob.s@example.com',         role: 'User' },
  { id: 'u3',        firstName: 'Charlie', lastName: 'Torres',   email: 'charlie.t@example.com',     role: 'User' },
  { id: 'u4',        firstName: 'David',   lastName: 'Lee',      email: 'david.l@example.com',       role: 'User' },
  { id: 'u5',        firstName: 'Eve',     lastName: 'Santos',   email: 'eve.s@example.com',         role: 'User' },
  { id: 'u6',        firstName: 'Frank',   lastName: 'Rivera',   email: 'frank.r@example.com',       role: 'User' },
];

@Injectable({ providedIn: 'root' })
export class UserService {
  private _store = signal<User[]>(MOCK_USERS);

  readonly allUsers = computed(() => this._store());

  getAll(): Observable<User[]> {
    return of(this._store()).pipe(delay(500));
  }

  delete(id: string): Observable<boolean> {
    return of(true).pipe(
      delay(500),
      tap(() => this._store.update(u => u.filter(usr => usr.id !== id)))
    );
  }
}
