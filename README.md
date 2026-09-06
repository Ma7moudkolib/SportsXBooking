# SportsXBooking

A full-stack SaaS platform for booking and managing sports playgrounds, connecting facility owners with athletes.

## Tech Stack

**Backend:** ASP.NET Core 9, Entity Framework Core, SQL Server, JWT Authentication  
**Frontend:** Angular 21, Signals, RxJS, Tailwind CSS

## Features

- User authentication with JWT and role-based access (Player, Owner, Admin)
- Playground search, listing, and facility management
- Real-time booking with availability checks and conflict resolution
- Booking confirmation and cancellation workflows
- Owner analytics dashboard with revenue and performance metrics
- Review and rating system for playgrounds

## Live Demo

[https://sports-x-booking.vercel.app](https://sports-x-booking.vercel.app)

## Getting Started

### Backend

```bash
cd Backend
dotnet ef database update --project Infrastructure --startup-project Presentation
dotnet run --project Presentation
```

### Frontend

```bash
cd Frontend
npm install
ng serve
```

## License

This project is licensed under the MIT License.
