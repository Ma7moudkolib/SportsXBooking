import { Component, inject, signal, OnInit, computed } from '@angular/core';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { PlaygroundService } from '../../../core/services/playground.service';
import { BookingService } from '../../../core/services/booking.service';
import { AuthService } from '../../../core/services/auth.service';
import { ToastService } from '../../../core/services/toast.service';
import { CreatePlayground, Playground, OwnerBooking, OwnerBookingFilters, PlaygroundAnalytics, DashboardTab } from '../../../models/types';
import { RouterLink } from '@angular/router';
import { NgClass, DecimalPipe } from '@angular/common';

@Component({
  selector: 'app-owner-dashboard',
  imports: [ReactiveFormsModule, RouterLink, NgClass, DecimalPipe],
  templateUrl: './owner-dashboard.component.html',
  styleUrl: './owner-dashboard.component.css'
})
export class OwnerDashboardComponent implements OnInit {
  private fb = inject(FormBuilder);
  private pgService = inject(PlaygroundService);
  private bookingService = inject(BookingService);
  auth = inject(AuthService);
  private toast = inject(ToastService);

  activeTab = signal<DashboardTab>('playgrounds');

  myPlaygrounds = signal<Playground[]>([]);
  pgLoading = signal(true);
  showForm = signal(false);
  formLoading = signal(false);
  editing = signal<Playground | null>(null);
  selectedImageFile = signal<File | null>(null);
  imagePreview = signal<string | null>(null);
  imageError = signal<string | null>(null);
  isDragging = signal(false);
  deletingId = signal<string | null>(null);

  bookings = signal<OwnerBooking[]>([]);
  bookingsLoading = signal(false);
  confirmingId = signal<number | null>(null);
  selectedBooking = signal<OwnerBooking | null>(null);
  bookingFilters = signal<OwnerBookingFilters>({});

  analytics = signal<PlaygroundAnalytics | null>(null);
  analyticsLoading = signal(false);

  bookingStats = computed(() => {
    const bks = this.bookings();
    return {
      total: bks.length,
      confirmed: bks.filter(b => b.status === 'Confirmed').length,
      pending: bks.filter(b => b.status === 'Pending').length,
      cancelled: bks.filter(b => b.status === 'Cancelled').length
    };
  });

  filteredPlaygrounds = computed(() => this.myPlaygrounds());

  private readonly maxFileSizeBytes = 5 * 1024 * 1024;
  private readonly allowedTypes = ['image/png', 'image/jpeg', 'image/webp'];
  form!: FormGroup;

  ngOnInit() {
    this.buildForm();
    this.loadPlaygrounds();
  }

  setTab(tab: DashboardTab) {
    this.activeTab.set(tab);
    if (tab === 'bookings' && this.bookings().length === 0 && !this.bookingsLoading()) {
      this.loadBookings();
    }
    if (tab === 'analytics' && !this.analytics() && !this.analyticsLoading()) {
      this.loadAnalytics();
    }
  }

  loadPlaygrounds() {
    const ownerId = this.auth.currentUser()?.id ?? '';
    this.pgService.getByOwner(ownerId).subscribe({
      next: (pgs) => {
        this.myPlaygrounds.set(pgs);
        this.pgLoading.set(false);
      },
      error: () => {
        this.pgLoading.set(false);
      }
    });
  }

  loadBookings() {
    this.bookingsLoading.set(true);
    this.bookingService.getOwnerBookings(this.bookingFilters()).subscribe({
      next: (bks) => {
        this.bookings.set(bks);
        this.bookingsLoading.set(false);
      },
      error: () => {
        this.bookingsLoading.set(false);
        this.toast.show('Failed to load bookings.', 'error');
      }
    });
  }

  loadAnalytics() {
    this.analyticsLoading.set(true);
    this.bookingService.getOwnerAnalytics().subscribe({
      next: (data) => {
        this.analytics.set(data);
        this.analyticsLoading.set(false);
        console.log(data);
      },
      error: () => {
        this.analyticsLoading.set(false);
        this.toast.show('Failed to load analytics.', 'error');
        console.log('error');
      }
    });
  }

  applyBookingFilters() {
    this.loadBookings();
  }

  clearBookingFilters() {
    this.bookingFilters.set({});
    this.loadBookings();
  }

  updateFilter(key: keyof OwnerBookingFilters, value: string) {
    this.bookingFilters.update(f => {
      const updated = { ...f };
      if (key === 'playgroundId') {
        updated.playgroundId = value ? Number(value) : undefined;
      } else if (key === 'status') {
        updated.status = value || undefined;
      } else if (key === 'date') {
        updated.date = value || undefined;
      }
      return updated;
    });
  }

  confirmBooking(booking: OwnerBooking) {
    this.confirmingId.set(booking.bookingId);
    this.bookingService.confirmBooking(booking.bookingId).subscribe({
      next: (res) => {
        this.confirmingId.set(null);
        if (res.success) {
          this.toast.show('Booking confirmed successfully.', 'success');
          this.loadBookings();
          this.selectedBooking.set(null);
        } else {
          this.toast.show(res.message || 'Failed to confirm booking.', 'error');
        }
      },
      error: () => {
        this.confirmingId.set(null);
        this.toast.show('Failed to confirm booking.', 'error');
      }
    });
  }

  viewBookingDetails(booking: OwnerBooking) {
    this.selectedBooking.set(booking);
  }

  closeBookingDetails(event: MouseEvent) {
    if ((event.target as HTMLElement).classList.contains('modal-overlay')) {
      this.selectedBooking.set(null);
    }
  }

  formatBookingDate(dateStr: string): string {
    if (!dateStr) return '';
    const d = new Date(dateStr);
    return d.toLocaleDateString('en-GB', { day: 'numeric', month: 'short', year: 'numeric' });
  }

  formatTime(timeStr: string): string {
    if (!timeStr) return '';
    const parts = timeStr.split(':');
    const h = parseInt(parts[0], 10);
    const m = parts[1] || '00';
    const ampm = h >= 12 ? 'PM' : 'AM';
    const h12 = h % 12 || 12;
    return `${h12}:${m} ${ampm}`;
  }

  statusBadgeClass(status: string): string {
    const base = 'inline-flex items-center rounded-full px-3 py-1 text-xs font-bold uppercase tracking-wide';
    return {
      Confirmed: `${base} bg-emerald-100 text-emerald-800`,
      Pending: `${base} bg-amber-100 text-amber-800`,
      Cancelled: `${base} bg-rose-100 text-rose-700`
    }[status] ?? `${base} bg-slate-100 text-slate-700`;
  }

  formatMonth(monthStr: string): string {
    const [year, month] = monthStr.split('-');
    const date = new Date(Number(year), Number(month) - 1);
    return date.toLocaleDateString('en-GB', { month: 'short', year: 'numeric' });
  }

  // Playground form methods
  buildForm(pg?: Playground) {
    const ownerId = this.auth.currentUser()?.id ?? '';
    this.form = this.fb.group({
      name: [pg?.name ?? '', Validators.required],
      sport: [pg?.sport ?? 'Football'],
      location: [pg?.location ?? '', Validators.required],
      pricePerHour: [pg?.pricePerHour ?? '', Validators.required],
      description: [pg?.description ?? ''],
      ownerId: [ownerId],
      imageFile: [null, Validators.required]
    });

    this.selectedImageFile.set(null);
    this.imagePreview.set(pg?.imageUrl ?? null);
    this.imageError.set(null);
  }

  onImageSelected(event: Event): void {
    const input = event.target as HTMLInputElement;
    const file = input.files?.[0];
    if (file) this.handleFile(file);
    input.value = '';
  }

  onImageDrop(event: DragEvent): void {
    event.preventDefault();
    this.isDragging.set(false);
    const file = event.dataTransfer?.files?.[0];
    if (file) this.handleFile(file);
  }

  onDragOver(event: DragEvent): void {
    event.preventDefault();
    this.isDragging.set(true);
  }

  onDragLeave(event: DragEvent): void {
    event.preventDefault();
    this.isDragging.set(false);
  }

  private handleFile(file: File): void {
    this.imageError.set(null);
    if (!this.allowedTypes.includes(file.type)) {
      this.imageError.set('Please upload a PNG, JPG, or WEBP image.');
      return;
    }
    if (file.size > this.maxFileSizeBytes) {
      this.imageError.set('Image must be smaller than 5MB.');
      return;
    }
    this.selectedImageFile.set(file);
    this.form.patchValue({ imageFile: file });
    this.form.get('imageFile')?.updateValueAndValidity();
    const reader = new FileReader();
    reader.onload = () => this.imagePreview.set(reader.result as string);
    reader.readAsDataURL(file);
  }

  removeImage(): void {
    this.selectedImageFile.set(null);
    this.imagePreview.set(null);
    this.imageError.set(null);
    this.form.patchValue({ imageFile: null });
  }

  editPlayground(pg: Playground) {
    this.editing.set(pg);
    this.buildForm(pg);
    this.showForm.set(true);
  }

  cancelForm() {
    this.editing.set(null);
    this.buildForm();
    this.showForm.set(false);
  }

  submitForm() {
    this.form.markAllAsTouched();
    if (this.form.invalid) return;
    this.formLoading.set(true);
    const editPg = this.editing();

    const obs = editPg
      ? this.pgService.update(editPg.id, this.form.value)
      : this.pgService.create(this.form.value);

    obs.subscribe({
      next: () => {
        this.formLoading.set(false);
        this.loadPlaygrounds();
        this.toast.show(editPg ? 'Venue updated!' : 'Venue created!', 'success');
        this.cancelForm();
      },
      error: () => {
        this.formLoading.set(false);
        this.toast.show('Error saving venue.', 'error');
      }
    });
  }

  deletePlayground(pg: Playground): void {
    const confirmed = confirm(`Delete "${pg.name}"? This can't be undone.`);
    if (!confirmed) return;
    this.deletingId.set(pg.id);
    this.pgService.delete(pg.id).subscribe({
      next: () => {
        this.deletingId.set(null);
        this.myPlaygrounds.update(list => list.filter(p => p.id !== pg.id));
        this.toast.show('Venue deleted.', 'success');
      },
      error: () => {
        this.deletingId.set(null);
        this.toast.show('Error deleting venue.', 'error');
      }
    });
  }
}
