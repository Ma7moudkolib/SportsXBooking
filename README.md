# SportsXBooking
> **The Elite Engine for Sports Facility Management & Athletic Reservations.**

[![Build Status](https://img.shields.io/badge/Build-Passing-brightgreen.svg)]()
[![Platform](https://img.shields.io/badge/.NET-9.0-blue.svg)]()
[![Frontend](https://img.shields.io/badge/Angular-19%2B-red.svg)]()
[![State Management](https://img.shields.io/badge/Signals-Reactive-orange.svg)]()
[![Design](https://img.shields.io/badge/Design-Stitch-7E22CE.svg)]()

**SportsXBooking** is a high-performance, full-stack SaaS platform designed to bridge the gap between sports facility owners and athletes. Built with enterprise-grade architecture and a modern reactive frontend, it provides a seamless end-to-end experience for booking, managing, and reviewing sports playgrounds.

---

## 🏗️ Technical Architecture

### Backend: .NET 9 Web API
Implementing **Clean Architecture** to ensure high decoupling, testability, and scalability.
- **Domain Layer**: Core entities, value objects, and domain logic.
- **Application Layer**: Use cases, DTOs, and interface definitions.
- **Infrastructure Layer**: EF Core implementation, JWT identity services, and external integrations.
- **Presentation Layer**: RESTful API nodes with structured response handling.

### Frontend: Angular 19+
A cutting-edge client-side application focused on performance and developer velocity.
- **Signal-Based State Management**: Real-time reactive updates without the overhead of Zone.js.
- **Standalone Components**: Modular and lightweight architecture.
- **Stitch Design System**: High-fidelity UI using **Deep Navy** and **Action Green** "Sports Performance" theme.
- **Tailwind CSS**: Utility-first styling integrated with custom design tokens.

---

## 🛠️ Tech Stack

### Backend
| Technology | Usage |
| :--- | :--- |
| **ASP.NET Core 9** | High-performance API framework |
| **EF Core** | Modern Object-Database Mapper |
| **Identity / JWT** | Secure authentication and authorization |
| **Repository Pattern** | Data access abstraction |
| **MS SQL Server** | Reliable relational data storage |

### Frontend
| Technology | Usage |
| :--- | :--- |
| **Angular 19/20** | Component-based web framework |
| **Signals** | Fine-grained reactivity |
| **RxJS** | Reactive extensions for async operations |
| **Tailwind CSS** | Premium styling and layout |
| **Stitch Tokens** | Design system consistency |

---

## 🌟 Core Features

- 🔐 **Secure Authentication**: Robust Identity-based registration and login with JWT-secured endpoints.
- 🏟️ **Playground Management**: Comprehensive CRUD operations for facility owners and system administrators.
- 📅 **Advanced Booking Engine**: Intelligent scheduling with real-time availability checks and conflict resolution.
- 🚫 **Cancellation Logic**: Automated rules for booking modifications and status transitions.
- 💬 **Review & Feedback**: Dual-sided feedback loop for quality assurance and community trust.
- 💳 **Payment Orchestration**: Secure status tracking for transactions and financial reporting.

---

## 📡 API Overview

The API is architected around specialized domain modules:

| Module | Responsibility |
| :--- | :--- |
| **`Auth`** | Identity management, token issuance, and password security. |
| **`Playgrounds`** | Venue discovery, facility details, and owner management. |
| **`Bookings`** | Reservation lifecycle, time-slot allocation, and scheduling. |
| **`Users`** | Profile management and role assignment. |
| **`Payments`** | Transaction verification and status tracking. |
| **`Reviews`** | Rating systems and community feedback moderation. |

---

## 🛡️ Role-Based Access Control (RBAC)

The system enforces strict permission sets defined by user roles:

| Feature | Player | Owner | Admin |
| :--- | :---: | :---: | :---: |
| Search & View Playgrounds | ✅ | ✅ | ✅ |
| Create Bookings | ✅ | ❌ | ❌ |
| Manage Own Facilities | ❌ | ✅ | ✅ |
| Manage All System Users | ❌ | ❌ | ✅ |
| Cancel Bookings | ✅ | ✅ | ✅ |
| Financial Overview | ❌ | ✅ | ✅ |

---

## 🚀 Installation & Setup

### Prerequisites
- .NET 9.0 SDK
- Node.js (v20+) & Angular CLI
- SQL Server

### Backend Setup
1. Navigate to the Backend directory:
   ```bash
   cd Backend
   ```
2. Update `appsettings.json` with your Connection String.
3. Apply database migrations:
   ```bash
   dotnet ef database update --project Infrastructure --startup-project Presentation
   ```
4. Launch the API:
   ```bash
   dotnet run --project Presentation
   ```

### Frontend Setup
1. Navigate to the Frontend directory:
   ```bash
   cd Frontend
   ```
2. Install dependencies:
   ```bash
   npm install
   ```
3. Start the development server:
   ```bash
   ng serve
   ```
4. Access the application at `http://localhost:4200`.

---

## 🎨 Design Language
Designed via **Stitch**, the platform adopts a **"Sports Performance"** aesthetic:
- **Primary Color**: Deep Navy (#0F172A)
- **Action Color**: Action Green (#22C55E)
- **Typography**: Precision-focused sans-serif fonts optimization for readability at high speed.

---

**SportsXBooking** — *Empowering the next generation of athletic coordination.*
