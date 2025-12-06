# Sports Playground Booking API

A production-ready ASP.NET Core 9 Web API for managing sports playground bookings, payments, and user management with enterprise-grade architecture.

## Overview

This API provides a complete solution for sports facility management, enabling playground owners to list their venues, players to book time slots, and administrators to oversee operations. Built with Clean Architecture principles, the system ensures scalability, maintainability, and testability.

## Key Features

- **User Management** - Role-based access control (Player, Owner, Admin) with JWT authentication
- **Playground Management** - Owners can create, update, and manage their sports facilities
- **Booking System** - Real-time availability checking and slot reservation
- **Payment Processing** - Integrated payment handling and transaction management
- **Admin Dashboard** - System oversight and user management capabilities

## Architecture

The project follows Clean Architecture with clear separation of concerns:

```
├── Domain          # Core business entities and interfaces
├── Application     # Business logic and use cases
├── Infrastructure  # Data access and external services
└── API             # Presentation layer and HTTP endpoints
```

## Technology Stack

- **Framework**: ASP.NET Core 9
- **Database**: SQL Server with Entity Framework Core
- **Authentication**: JWT Bearer tokens
- **Patterns**: Repository Pattern, Unite of Worke
- **Mapping**: AutoMapper
- **Architecture**: Clean Architecture

## Getting Started

### Prerequisites

- .NET 9 SDK
- SQL Server
- Visual Studio 2022 

### Installation

1. Clone the repository
```bash
git clone https://github.com/yourusername/sports-playground-booking-api.git
cd sports-playground-booking-api
```

2. Update the connection string in `appsettings.json`
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=.;Database=SportsBookingDB;Trusted_Connection=True;"
}
```

3. Apply database migrations
```bash
dotnet ef database update
```

4. Run the application
```bash
dotnet run --project API
```

The API will be available at `https://localhost:5001`

## API Documentation

Once running, access the Swagger documentation at:
```
https://localhost:5001/swagger
```

### Core Endpoints

- **Authentication**: `/api/auth/login`, `/api/auth/register`
- **Playgrounds**: `/api/playgrounds`
- **Bookings**: `/api/bookings`
- **Payments**: `/api/payments`
- **Admin**: `/api/admin`

## User Roles

| Role | Permissions |
|------|-------------|
| **Player** | Browse playgrounds, create bookings, manage own bookings |
| **Owner** | Manage own playgrounds, view bookings, handle availability |
| **Admin** | Full system access, user management, oversight |

## Configuration

Key configuration options in `appsettings.json`:

```json
{
  "JwtSettings": {
    "Secret": "your-secret-key",
    "ExpirationInMinutes": 60
  },
  "ConnectionStrings": {
    "DefaultConnection": "your-connection-string"
  }
}
```

## Contributing

Contributions are welcome! Please follow these steps:

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/amazing-feature`)
3. Commit your changes (`git commit -m 'Add amazing feature'`)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Contact

For questions or support, please open an issue on GitHub.

---

**Built with ❤️ using Clean Architecture and ASP.NET Core 9**
