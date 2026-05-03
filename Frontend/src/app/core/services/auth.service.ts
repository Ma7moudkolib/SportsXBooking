import { Injectable, signal, computed, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, tap, switchMap, map } from 'rxjs';
import { User, UserForLoginDto, UserForRegistrationDto, LoginResponse, UserRole } from '../../models/types';
import { environment } from '../../../environments/environment';

@Injectable({ providedIn: 'root' })
export class AuthService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = `${environment.apiUrl}/Authentication`;

  private _user = signal<User | null>(this._loadUser());
  private _token = signal<string | null>(this._loadToken());

  readonly currentUser = computed(() => this._user());
  readonly isAuthenticated = computed(() => !!this._token());
  readonly token = computed(() => this._token());
  readonly userRole = computed<UserRole>(() => this._user()?.role ?? 'Guest');
  readonly isOwnerOrAdmin = computed(() => {
    const r = this.userRole();
    return r === 'Owner' || r === 'Admin';
  });

  private _loadUser(): User | null {
    try { return JSON.parse(localStorage.getItem('sx_user') ?? 'null'); }
    catch { return null; }
  }

  private _loadToken(): string | null {
    return localStorage.getItem('sx_token');
  }

  login(dto: UserForLoginDto): Observable<LoginResponse> {
    return this.http.post<any>(`${this.apiUrl}/login`, dto).pipe(
      map(res => {
        const [firstName, ...rest] = (res.user.fullName as string).split(' ');
        const role = (res.user.role === 'Player' ? 'User' : res.user.role) as UserRole;
        return {
          message: res.message,
          token: res.token,
          user: {
            id: String(res.user.id),
            firstName,
            lastName: rest.join(' ') || '',
            email: res.user.email,
            role
          }
        } as LoginResponse;
      }),
      tap(res => this._persist(res.token, res.user))
    );
  }

  register(dto: UserForRegistrationDto): Observable<LoginResponse> {
    const payload = {
      fullName: `${dto.firstName} ${dto.lastName}`.trim(),
      email: dto.email,
      phone: '01000000000',
      password: dto.password,
      role: dto.role === 'User' ? 'Player' : dto.role
    };

    return this.http.post(`${this.apiUrl}/register`, payload).pipe(
      switchMap(() => this.login({ email: dto.email, password: dto.password }))
    );
  }

  logout(): void {
    this._token.set(null);
    this._user.set(null);
    localStorage.removeItem('sx_token');
    localStorage.removeItem('sx_user');
  }

  private _persist(token: string, user: User): void {
    this._token.set(token);
    this._user.set(user);
    localStorage.setItem('sx_token', token);
    localStorage.setItem('sx_user', JSON.stringify(user));
  }
}
