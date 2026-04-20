import { Injectable, signal, computed } from '@angular/core';
import { Observable, of, delay, tap } from 'rxjs';
import { User, UserForLoginDto, UserForRegistrationDto, LoginResponse, UserRole } from '../../models/types';

@Injectable({ providedIn: 'root' })
export class AuthService {
  private _user   = signal<User | null>(this._loadUser());
  private _token  = signal<string | null>(this._loadToken());

  readonly currentUser      = computed(() => this._user());
  readonly isAuthenticated  = computed(() => !!this._token());
  readonly token            = computed(() => this._token());
  readonly userRole         = computed<UserRole>(() => this._user()?.role ?? 'Guest');
  readonly isOwnerOrAdmin   = computed(() => {
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
    const role: UserRole = dto.email.toLowerCase().includes('admin')
      ? 'Admin'
      : dto.email.toLowerCase().includes('owner')
        ? 'Owner'
        : 'User';

    const mockUser: User = {
      id: role === 'Admin' ? 'admin1' : role === 'Owner' ? 'u_owner1' : 'u1',
      firstName: role === 'Admin' ? 'Admin' : 'Test',
      lastName:  role === 'Admin' ? 'Super' : 'User',
      email: dto.email,
      role
    };
    const mockToken = `eyJ.mock-jwt-${Date.now()}.signature`;

    return of<LoginResponse>({ message: 'Login Successful', token: mockToken, user: mockUser }).pipe(
      delay(800),
      tap(res => this._persist(res.token, res.user))
    );
  }

  register(dto: UserForRegistrationDto): Observable<LoginResponse> {
    const mockUser: User = {
      id: `u_${Date.now()}`,
      firstName: dto.firstName,
      lastName:  dto.lastName,
      email:     dto.email,
      role:      dto.role
    };
    const mockToken = `eyJ.mock-jwt-reg-${Date.now()}.signature`;

    return of<LoginResponse>({ message: 'Registration Successful', token: mockToken, user: mockUser }).pipe(
      delay(1000),
      tap(res => this._persist(res.token, res.user))
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
