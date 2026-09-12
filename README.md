# SportsXBooking

A full-stack SaaS platform for booking and managing sports playgrounds, connecting facility owners with athletes.

## Tech Stack

| Layer | Technologies |
|-------|-------------|
| **Backend** | ASP.NET Core 9, Entity Framework Core, SQL Server, JWT Authentication |
| **Frontend** | Angular 21, Signals, RxJS, Tailwind CSS |
| **Infrastructure** | Docker, GitHub Actions (CI/CD) |

## Project Workflow

1. **User** registers or logs in via the frontend, receiving a JWT token for authenticated access.
2. **Frontend** sends HTTP requests (with the JWT) to the backend API for all operations — searching playgrounds, creating bookings, managing venues, and viewing analytics.
3. **Backend** validates the token, enforces role-based authorization (Player, Owner, Admin), processes business logic, and interacts with the database through Entity Framework Core.
4. **Database** stores users, playgrounds, bookings, payments, and reviews, ensuring data integrity and availability checks for time-slot conflicts.
5. **Booking Flow** — A Player selects a playground and time slot; the backend validates availability, creates the booking, and tracks its status through confirmation, completion, or cancellation.

## Live Demo

[https://sports-x-booking.vercel.app](https://sports-x-booking.vercel.app)

## Getting Started

### Docker

```bash
docker-compose up --build
```

### Backend (Manual)

```bash
cd Backend
dotnet ef database update --project Infrastructure --startup-project Presentation
dotnet run --project Presentation
```

### Frontend (Manual)

```bash
cd Frontend
npm install
ng serve
```

## License

This project is licensed under the MIT License.
