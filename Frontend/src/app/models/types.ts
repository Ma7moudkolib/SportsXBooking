export type UserRole = 'Guest' | 'User' | 'Player' | 'Owner' | 'Admin';
export type BookingStatus = 'Confirmed' | 'Pending' | 'Cancelled';
export type PaymentStatus = 'Completed' | 'Failed' | 'Refunded';
export type DashboardTab = 'playgrounds' | 'bookings' | 'analytics';

export interface UserForLoginDto {
  email: string;
  password: string;
}

export interface UserForRegistrationDto {
  firstName: string;
  lastName: string;
  email: string;
  password: string;
  phone : string
  role: UserRole;
}

export interface LoginResponse {
  message: string;
  token: string;
  user: User;
}

export interface User {
  id: string;
  firstName: string;
  lastName: string;
  email: string;
  role: UserRole;
}

export interface Playground {
  id: string;
  name: string;
  location: string;
  pricePerHour: number;
  ownerId: string;
  description: string;
  imageUrl: string;
  sport?: string;
}
export interface CreatePlayground {
  id: string;
  name: string;
  location: string;
  pricePerHour: number;
  ownerId: string;
  description: string;
  imageFile: File;
  sport?: string;
}

export interface Review {
  id: string;
  playgroundId: string;
  userId: string;
  rating: number;
  comment: string;
  date: string;
  userName: string;
}

export interface Booking {
  id: string;
  playgroundId: string;
  userId: string;
  startTime: string;
  endTime: string;
  status: BookingStatus;
  totalPrice: number;
  playgroundName: string;
}

export interface Payment {
  id: string;
  bookingId: string;
  amount: number;
  status: PaymentStatus;
  transactionDate: string;
}

export interface OwnerBooking {
  bookingId: number;
  playerId: number;
  customerName: string;
  customerEmail: string;
  playgroundId: number;
  playgroundName: string;
  bookingDate: string;
  startTime: string;
  endTime: string;
  totalPrice: number;
  status: string;
  createdAt: string;
}

export interface OwnerBookingFilters {
  playgroundId?: number;
  status?: string;
  date?: string;
}

export interface PlaygroundPerformance {
  playgroundId: number;
  playgroundName: string;
  sportType: string;
  totalBookings: number;
  confirmedBookings: number;
  cancelledBookings: number;
  revenue: number;
}

export interface BookingsByMonth {
  month: string;
  count: number;
  revenue: number;
}

export interface PlaygroundAnalytics {
  totalBookings: number;
  confirmedBookings: number;
  pendingBookings: number;
  cancelledBookings: number;
  cancellationRate: number;
  totalRevenue: number;
  confirmedRevenue: number;
  playgroundStats: PlaygroundPerformance[];
  bookingsByMonth: BookingsByMonth[];
}
