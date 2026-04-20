import { Component, Input, Output, EventEmitter, inject, signal, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { Playground } from '../../../models/types';
import { BookingService } from '../../../core/services/booking.service';
import { AuthService } from '../../../core/services/auth.service';
import { ToastService } from '../../../core/services/toast.service';

@Component({
  selector: 'app-create-booking-modal',
  standalone: true,
  imports: [ReactiveFormsModule],
  template: `
    <div class="modal-overlay" (click)="onClose($event)">
      <div class="modal-box" role="dialog" aria-modal="true" aria-labelledby="book-modal-title">
        <div class="flex items-center justify-between mb-6">
          <h3 id="book-modal-title">Book: {{ playground.name }}</h3>
          <button class="btn btn-ghost btn-sm" (click)="close.emit()" aria-label="Close">✕</button>
        </div>

        <div class="venue-summary mb-6">
          <p class="text-sm text-muted mb-1">📍 {{ playground.location }}</p>
          <p class="text-sm font-semi" style="color:var(--color-primary-fixed);">
            {{ playground.pricePerHour }} EGP / hour
          </p>
        </div>

        <form [formGroup]="form" (ngSubmit)="submit()" id="create-booking-form">
          <div class="form-row">
            <div class="form-group">
              <label class="form-label" for="booking-date">Date</label>
              <input id="booking-date" type="date" formControlName="date" class="form-control" [min]="today" />
              @if (form.get('date')?.invalid && form.get('date')?.touched) {
                <p class="field-error">Please pick a date.</p>
              }
            </div>
            <div class="form-group">
              <label class="form-label" for="booking-start">Start Time</label>
              <input id="booking-start" type="time" formControlName="startTime" class="form-control" />
            </div>
          </div>

          <div class="form-group">
            <label class="form-label" for="booking-hours">Duration (hours)</label>
            <select id="booking-hours" formControlName="hours" class="form-control">
              <option value="1">1 hour</option>
              <option value="2">2 hours</option>
              <option value="3">3 hours</option>
              <option value="4">4 hours</option>
            </select>
          </div>

          <div class="total-row mb-4">
            <span class="text-muted">Estimated Total</span>
            <span class="total-price font-display">{{ estimatedTotal() }} EGP</span>
          </div>

          @if (error()) {
            <div class="alert alert-error mb-4">{{ error() }}</div>
          }

          <div class="flex gap-3">
            <button type="button" class="btn btn-secondary flex-1" (click)="close.emit()">Cancel</button>
            <button
              type="submit"
              id="confirm-booking-btn"
              class="btn btn-primary flex-1"
              [disabled]="loading()"
            >
              {{ loading() ? 'Confirming...' : 'Confirm Booking' }}
            </button>
          </div>
        </form>
      </div>
    </div>
  `,
  styles: [`
    .venue-summary {
      background: var(--surface-container-low);
      border-radius: var(--radius-md);
      padding: 0.875rem 1rem;
    }
    .form-row {
      display: grid;
      grid-template-columns: 1fr 1fr;
      gap: 1rem;
    }
    .total-row {
      display: flex;
      align-items: center;
      justify-content: space-between;
      background: var(--surface-container);
      border-radius: var(--radius-md);
      padding: 0.875rem 1rem;
    }
    .total-price {
      font-size: 1.5rem;
      font-weight: 700;
      color: var(--color-primary-fixed);
    }
    .field-error {
      font-size: 0.8rem;
      color: var(--color-error);
      margin-top: 0.375rem;
    }
  `]
})
export class CreateBookingModalComponent implements OnInit {
  @Input({ required: true }) playground!: Playground;
  @Output() close = new EventEmitter<void>();

  private fb             = inject(FormBuilder);
  private bookingService = inject(BookingService);
  private authService    = inject(AuthService);
  private toast          = inject(ToastService);

  form!: FormGroup;
  loading = signal(false);
  error   = signal<string | null>(null);
  today   = new Date().toISOString().split('T')[0];

  estimatedTotal = signal(0);

  ngOnInit() {
    this.form = this.fb.group({
      date:      [this.today, Validators.required],
      startTime: ['10:00',    Validators.required],
      hours:     [1]
    });

    this.form.valueChanges.subscribe(v => {
      this.estimatedTotal.set((v.hours ?? 1) * this.playground.pricePerHour);
    });
    this.estimatedTotal.set(this.playground.pricePerHour);
  }

  submit() {
    this.form.markAllAsTouched();
    if (this.form.invalid) return;

    this.loading.set(true);
    const { date, startTime, hours } = this.form.value;
    const start = new Date(`${date}T${startTime}:00`);
    const end   = new Date(start.getTime() + hours * 3600 * 1000);

    this.bookingService.create({
      playgroundId:    this.playground.id,
      userId:          this.authService.currentUser()!.id,
      startTime:       start.toISOString(),
      endTime:         end.toISOString(),
      totalPrice:      hours * this.playground.pricePerHour,
      playgroundName:  this.playground.name,
    }).subscribe({
      next: () => {
        this.loading.set(false);
        this.toast.show('Booking created successfully! 🎉', 'success');
        this.close.emit();
      },
      error: () => {
        this.loading.set(false);
        this.error.set('Failed to create booking. Please try again.');
      }
    });
  }

  onClose(event: MouseEvent) {
    if ((event.target as HTMLElement).classList.contains('modal-overlay')) {
      this.close.emit();
    }
  }
}
