import { Injectable, signal } from '@angular/core';

@Injectable({ providedIn: 'root' })
export class LoadingService {
  private pendingCount = 0;
  readonly loading = signal(false);

  start() {
    this.pendingCount++;
    this.loading.set(true);
  }

  stop() {
    this.pendingCount = Math.max(0, this.pendingCount - 1);
    if (this.pendingCount === 0) {
      this.loading.set(false);
    }
  }

  reset() {
    this.pendingCount = 0;
    this.loading.set(false);
  }
}
