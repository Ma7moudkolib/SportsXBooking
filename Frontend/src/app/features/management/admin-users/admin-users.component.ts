import { Component, inject, signal, OnInit } from '@angular/core';
import { UserService } from '../../../core/services/user.service';
import { ToastService } from '../../../core/services/toast.service';
import { User } from '../../../models/types';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-admin-users',
  standalone: true,
  imports: [RouterLink],
  template: `
    <div class="dashboard-layout" style="margin-top:var(--nav-height);">
      <!-- Sidebar -->
      <aside class="sidebar">
        <div class="sidebar-logo mb-6">
          <p class="text-xs text-muted font-semi mb-1" style="text-transform:uppercase;letter-spacing:.08em;">Admin Panel</p>
          <h4 style="margin:0;color:var(--color-primary);">Operations</h4>
        </div>
        <button class="sidebar-item active">👥 User Management</button>
        <a routerLink="/management/playgrounds" class="sidebar-item">🏟️ All Venues</a>
        <a routerLink="/" class="sidebar-item">← Front-End</a>
      </aside>

      <!-- Content -->
      <main class="sidebar-content">
        <!-- Header -->
        <div class="flex items-center justify-between mb-8">
          <div>
            <h2 class="mb-1">User Management</h2>
            <p class="text-muted">{{ users().length }} registered accounts across all roles.</p>
          </div>
        </div>

        <!-- Role Summary -->
        <div class="role-summary mb-8">
          @for (rs of roleSummary(); track rs.role) {
            <div class="role-stat surface-card">
              <span class="badge" [class]="'badge-' + rs.role.toLowerCase()">{{ rs.role }}</span>
              <span class="role-count font-display">{{ rs.count }}</span>
            </div>
          }
        </div>

        @if (loading()) {
          <p class="text-muted">Loading users...</p>
        } @else {
          <div class="table-wrapper">
            <table class="data-table">
              <thead>
                <tr>
                  <th>User</th>
                  <th>Email</th>
                  <th>Role</th>
                  <th>ID</th>
                  <th>Actions</th>
                </tr>
              </thead>
              <tbody>
                @for (u of users(); track u.id) {
                  <tr>
                    <td>
                      <div class="flex items-center gap-3">
                        <div class="user-avatar">{{ u.firstName.charAt(0) }}{{ u.lastName.charAt(0) }}</div>
                        <span class="font-semi">{{ u.firstName }} {{ u.lastName }}</span>
                      </div>
                    </td>
                    <td class="text-muted text-sm">{{ u.email }}</td>
                    <td>
                      <span class="badge" [class]="'badge-' + u.role.toLowerCase()">{{ u.role }}</span>
                    </td>
                    <td class="text-xs text-muted" style="font-family:monospace;">{{ u.id }}</td>
                    <td>
                      @if (u.role !== 'Admin') {
                        <button
                          class="btn btn-danger btn-sm"
                          [id]="'delete-user-' + u.id"
                          [disabled]="deleting() === u.id"
                          (click)="deleteUser(u)"
                        >
                          {{ deleting() === u.id ? '...' : 'Delete' }}
                        </button>
                      } @else {
                        <span class="text-xs text-muted">—</span>
                      }
                    </td>
                  </tr>
                }
              </tbody>
            </table>
          </div>
        }
      </main>
    </div>
  `,
  styles: [`
    .sidebar-logo { padding: 0 1rem; }
    .table-wrapper { overflow-x: auto; }

    .role-summary {
      display: grid;
      grid-template-columns: repeat(3, 1fr);
      gap: 1rem;
    }
    .role-stat {
      padding: 1.5rem;
      display: flex;
      flex-direction: column;
      align-items: flex-start;
      gap: 0.75rem;
    }
    .role-count {
      font-size: 2.25rem;
      font-weight: 700;
      color: var(--color-primary);
      line-height: 1;
    }

    .user-avatar {
      width: 36px;
      height: 36px;
      border-radius: 50%;
      background: linear-gradient(135deg, var(--color-primary), #002d5c);
      color: #fff;
      display: flex;
      align-items: center;
      justify-content: center;
      font-size: 0.75rem;
      font-weight: 700;
      flex-shrink: 0;
    }

    @media (max-width: 600px) {
      .role-summary { grid-template-columns: 1fr; }
    }
  `]
})
export class AdminUsersComponent implements OnInit {
  private userService = inject(UserService);
  private toast       = inject(ToastService);

  users    = signal<User[]>([]);
  loading  = signal(true);
  deleting = signal<string | null>(null);

  roleSummary = signal<{ role: string; count: number }[]>([]);

  ngOnInit() {
    this.userService.getAll().subscribe(us => {
      this.users.set(us);
      this.loading.set(false);
      this.computeSummary(us);
    });
  }

  computeSummary(users: User[]) {
    const roles = ['Admin', 'Owner', 'User'];
    this.roleSummary.set(
      roles.map(role => ({ role, count: users.filter(u => u.role === role).length }))
    );
  }

  deleteUser(u: User) {
    if (!confirm(`Delete account for ${u.firstName} ${u.lastName}?`)) return;
    this.deleting.set(u.id);
    this.userService.delete(u.id).subscribe({
      next: () => {
        this.deleting.set(null);
        this.users.update(us => us.filter(usr => usr.id !== u.id));
        this.computeSummary(this.users());
        this.toast.show(`User ${u.firstName} ${u.lastName} deleted.`, 'success');
      },
      error: () => {
        this.deleting.set(null);
        this.toast.show('Failed to delete user.', 'error');
      }
    });
  }
}
