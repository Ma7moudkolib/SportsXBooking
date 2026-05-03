export type UserRole = 'Guest' | 'User' | 'Player' | 'Owner' | 'Admin';
export type BookingStatus = 'Confirmed' | 'Pending' | 'Cancelled';
export type PaymentStatus = 'Completed' | 'Failed' | 'Refunded';

export interface UserForLoginDto {
  email: string;
  password: string;
}

export interface UserForRegistrationDto {
  firstName: string;
  lastName: string;
  email: string;
  password: string;
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
