# 🍑 **Peach_ActiviGo — Project Overview & Runbook**

> A concise guide for running, understanding, and contributing to **Peach_ActiviGo** — including architecture overview, setup instructions, API surface, and team workflow.

---

## 🧱 1. Architecture Overview

| Layer | Project | Description |
|:------|:---------|:-------------|
| **API (Presentation)** | `Peach_ActiviGo.Api` | ASP.NET Core Web API (.NET 8). Configured in `Program.cs`. Includes middleware (`GlobalExceptionMiddleware`), JWT auth, and Swagger (Development only). |
| **Core / Domain** | `Peach_ActiviGo.Core` | Domain models (Activity, Booking, etc.), enums, and DTO contracts. |
| **Infrastructure** | `Peach_ActiviGo.Infrastructure` | EF Core + Identity via `AppDbContext`, migrations, repositories, and seed data (`IdentitySeed`, `BookingSeed`). |
| **Services** | `Peach_ActiviGo.Services` | Business logic, AutoMapper profiles, JWT service, FluentValidation. |
| **Frontend** | `FrontEnd/Peach_ActiviGo.Frontend` | Vite-powered SPA. `src/utils/constants.js` holds API paths and image URL builder. |

---

## ⚙️ 2. Local Run Instructions

### ✅ Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- SQL Server (LocalDB / Docker)
- Node.js (for frontend)
- (Optional) Visual Studio Package Manager Console

---

### 🔧 Environment Configuration

#### **Backend (`appsettings.Development.json` or User Secrets)**

| Key | Example / Description |
|:----|:----------------------|
| `ConnectionStrings:DefaultConnection` | Your SQL Server connection string |
| `Jwt:Key` / `Jwt:Issuer` / `Jwt:Audience` | JWT secrets for development |

#### **Frontend (`.env.local`)**

```bash
VITE_API_BASE_URL=http://localhost:5000
VITE_WEATHER_API_KEY=your_openweathermap_api_key
