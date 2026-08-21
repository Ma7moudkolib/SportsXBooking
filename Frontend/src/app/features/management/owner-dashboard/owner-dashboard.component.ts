import { Component, inject, signal, OnInit, computed } from '@angular/core';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { PlaygroundService } from '../../../core/services/playground.service';
import { AuthService } from '../../../core/services/auth.service';
import { ToastService } from '../../../core/services/toast.service';
import { CreatePlayground, Playground } from '../../../models/types';
import { RouterLink } from '@angular/router';
import { NgClass } from '@angular/common';

@Component({
  selector: 'app-owner-dashboard',
  imports: [ReactiveFormsModule, RouterLink,NgClass],
  templateUrl:'./owner-dashboard.component.html',
  styleUrl:'./owner-dashboard.component.css'
})
export class OwnerDashboardComponent implements OnInit {
  private fb         = inject(FormBuilder);
  private pgService  = inject(PlaygroundService);
  auth               = inject(AuthService);
  private toast      = inject(ToastService);

  myPlaygrounds = signal<Playground[]>([]);
  pgLoading     = signal(true);
  showForm      = signal(false);
  formLoading   = signal(false);
  editing       = signal<Playground | null>(null);
  // --- state ---
  selectedImageFile = signal<File | null>(null);
  imagePreview = signal<string | null>(null);
  imageError = signal<string | null>(null);
  isDragging = signal(false);

  private readonly maxFileSizeBytes = 5 * 1024 * 1024; // 5MB
  private readonly allowedTypes = ['image/png', 'image/jpeg', 'image/webp'];
  form!: FormGroup;

  ngOnInit() {
    this.buildForm();
    const ownerId = this.auth.currentUser()?.id ?? 'u_owner1';
    this.pgService.getByOwner(ownerId).subscribe(pgs => {
      this.myPlaygrounds.set(pgs);
      this.pgLoading.set(false);
    });
  }

  buildForm(pg?: Playground) {
    const ownerId = this.auth.currentUser()?.id ?? 'u_owner1';
    this.form = this.fb.group({
      name:        [pg?.name ?? '',         Validators.required],
      sport:       [pg?.sport ?? 'Football'],
      location:    [pg?.location ?? '',     Validators.required],
      pricePerHour:[pg?.pricePerHour ?? '', Validators.required],
      description: [pg?.description ?? ''],
      ownerId:     [ownerId],
      imageFile:   [null,Validators.required]
    });

      this.selectedImageFile.set(null);
      this.imagePreview.set(pg?.imageUrl ?? null);
      this.imageError.set(null);
  }

  // image functions
  onImageSelected(event: Event): void {
  const input = event.target as HTMLInputElement;
  const file = input.files?.[0];
  if (file) this.handleFile(file);
  input.value = ''; // allow re-selecting the same file later
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
  this.form.patchValue({ imageFile: file });        // ✅ sync into the form
  this.form.get('imageFile')?.updateValueAndValidity();

  const reader = new FileReader();
  reader.onload = () => this.imagePreview.set(reader.result as string);
  reader.readAsDataURL(file);
}

removeImage(): void {
  this.selectedImageFile.set(null);
  this.imagePreview.set(null);
  this.imageError.set(null);
  this.form.patchValue({ imageFile: null });        // ✅ also clear it here
}

  // --------------------------------------
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
      const ownerId = this.auth.currentUser()?.id ?? 'u_owner1';
      this.pgService.getByOwner(ownerId).subscribe(pgs => this.myPlaygrounds.set(pgs));
      this.toast.show(editPg ? 'Venue updated!' : 'Venue created! 🎉', 'success');
      this.cancelForm();
    },
    error: () => {
      this.formLoading.set(false);
      this.toast.show('Error saving venue.', 'error');
    }
  });
}
}
