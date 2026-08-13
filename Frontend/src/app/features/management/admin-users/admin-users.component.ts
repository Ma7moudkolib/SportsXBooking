import { Component, inject, signal, OnInit } from '@angular/core';
import { UserService } from '../../../core/services/user.service';
import { ToastService } from '../../../core/services/toast.service';
import { User } from '../../../models/types';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-admin-users',
  imports: [RouterLink],
  templateUrl:'./admin-users.component.html',
  styleUrl:'./admin-users.component.css'
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
    const roles = ['Admin', 'Owner', 'Player'];
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
