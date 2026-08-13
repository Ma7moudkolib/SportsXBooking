import { Component, Input, Output, EventEmitter, inject, signal, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { Playground } from '../../../models/types';
import { BookingService } from '../../../core/services/booking.service';
import { AuthService } from '../../../core/services/auth.service';
import { ToastService } from '../../../core/services/toast.service';

@Component({
  selector: 'app-create-booking-modal',
  imports: [ReactiveFormsModule],
  templateUrl:'./create-booking-modal.component.html',
  styleUrl:'./create-booking-modal.component.css'
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
