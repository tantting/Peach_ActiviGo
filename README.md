# 🍑 Peach_ActiviGo — Project Overview & Runbook

> A concise guide for running, understanding, and contributing to **Peach_ActiviGo** — inklusive arkitekturöversikt, lokal körning (migrations & seed, miljövariabler för väder-API), API-surface och rekommenderat team-workflow.

---

## 1. Architecture & Layers (high level)

- **API (Presentation)**
  - `Peach_ActiviGo.Api`
  - ASP.NET Core Web API (.NET 8). Konfigureras i `Program.cs`.
  - Middleware: `GlobalExceptionMiddleware`, JWT authentication (`JwtBearer`), authorization policy `AdminOnly`.
  - Swagger är aktiverat i Development.

- **Core / Domain**
  - `Peach_ActiviGo.Core`
  - Domain models (Activity, ActivityLocation, ActivitySlot, Booking, Category, Location), enums och delade DTO-kontrakt.

- **Infrastructure (data & Identity)**
  - `Peach_ActiviGo.Infrastructure`
  - `AppDbContext` (EF Core + Identity), Migrations, seed data (`IdentitySeed`, `BookingSeed`), repositories.

- **Services (business logic)**
  - `Peach_ActiviGo.Services`
  - Business services, AutoMapper profiles, JWT token service, FluentValidation validators.

- **Frontend**
  - `FrontEnd/Peach_ActiviGo.Frontend`
  - Vite-driven SPA. `src/utils/constants.js` innehåller API-vägar och bild-URL helper.

---

## 2. Local run instructions

### Prerequisites
- .NET 8 SDK
- SQL Server (LocalDB, Docker SQL Server eller annan)
- Node.js (för frontend)
- (Valfritt) **Package Manager Console** i Visual Studio

### Configuration / environment variables
- **Backend**: lägg till `appsettings.Development.json` (eller använd user secrets) med:
  - `ConnectionStrings:DefaultConnection` → SQL Server connection string
  - `Jwt:Key`, `Jwt:Issuer`, `Jwt:Audience` → stark secret för dev
- **Frontend** (.env för Vite): skapa `FrontEnd/Peach_ActiviGo.Frontend/.env.local`:
  - `VITE_API_BASE_URL=http://localhost:5000`
  - `VITE_WEATHER_API_KEY=your_openweathermap_api_key` (OpenWeatherMap eller motsvarande)

Exempel `.env.local` (klistra in i filen):
```
VITE_API_BASE_URL=http://localhost:5000
VITE_WEATHER_API_KEY=your_openweathermap_api_key
```

### How migrations & seed run
- `Program.cs` anropar vid startup:
  - `dbContext.Database.Migrate()` — applicerar pending migrations.
  - `IdentitySeed.InitializeAsync(userManager, roleManager)` — skapar roller (`Admin`, `User`) och default-konton.
  - `BookingSeed.InitializeAsync(dbContext)` — seedar activities, locations, slots och bookings (BookingSeed kräver slots och letar efter slots med start >= `2025-10-27 12:00` i nuvarande seed).

**Default seeded accounts (från `IdentitySeed`):**
- Admin: `exempel@live.com` / `Abc123!`
- Users: `user1@example.com` … `user4@example.com` (password `User123!`)

**BookingSeed notes:**
- Migrerar DB och returnerar tidigt om `Bookings.Any()` (för att undvika dubbletter).
- Väljer slots med `StartTime >= 2025-10-27 12:00` och skapar ~30 bookings kopplade till seeded users.

### Recommended local run steps

1. Restore, build och kör backend:
```bash
cd Peach_ActiviGo.Api
dotnet restore
dotnet build
dotnet run --project Peach_ActiviGo.Api
```

2. (Valfritt) Kör EF migrations manuellt:
```bash
dotnet tool install --global dotnet-ef
dotnet ef database update --project Peach_ActiviGo.Infrastructure --startup-project Peach_ActiviGo.Api
```
Eller från Visual Studio via **Package Manager Console**:
```powershell
Update-Database
```
(se till att rätt Default project är valt)

3. Frontend:
```bash
cd FrontEnd/Peach_ActiviGo.Frontend
npm install
npm run dev
```

- Swagger kommer vara tillgänglig i Development på: `https://localhost:{port}/swagger`.
- CORS-policy `AllowAll` är konfigurerad för lokal frontend-access.

---

## 3. API surface & central flows

**Primary endpoints (examples)**

- **Authentication**
  - `POST /api/Authentication/login` — returnerar JWT (access + refresh där implementerat)
  - `POST /api/Authentication/CreateAccount` — registrera ny användare
- **Booking**
  - `GET/POST/DELETE /api/Booking` — lista/skapa/avboka bookings (implementation-specifik)
- **Activities**
  - `GET /api/activities` — lista activities
  - `GET/POST /api/ActivityLocation` — activity locations
  - `GET/POST /api/ActivitySlots` — slots / calendar för bokningar
  - `GET /api/Location` — lista locations

**Authentication / Authorization flow**
1. Klient registrerar sig via `CreateAccount` eller använder seeded accounts.
2. Klient anropar `login` → får JWT.
3. Skyddade endpoints kräver header `Authorization: Bearer <token>`.
4. Admin-endpoints kräver roll `Admin` eller policy `AdminOnly`.

**Booking flow (typisk)**
1. Klient hämtar activities → väljer activity location.
2. Klient hämtar tillgängliga `ActivitySlots` för vald plats.
3. Klient postar booking till `POST /api/Booking` med `ActivitySlotId`. Backend löser `CustomerId` från token och validerar kapacitet.
4. Avbokning: backend sätter `Status = Cancelled` och `CancelledAt`.

**Validation & error handling**
- FluentValidation-validators är registrerade för DTOs och körs i controllers.
- `GlobalExceptionMiddleware` ger konsekventa JSON-felresponses.

**Images & assets**
- Backend-seedade bildvägar använder `images/...`. Frontend-helper `buildImageUrl` i `constants.js` bygger full URL med `VITE_API_BASE_URL` om vägen är relativ.

---

## 4. Team workflow (recommended)

### Branching
- `main` — skyddad, alltid deploybar
- Feature branches: `feature/<short-desc>` (t.ex. `feature/activity-search`)
- Bugfix: `bugfix/<issue-number>`
- Hotfix: `hotfix/<issue>`
- Release branches (valfritt): `release/vX.Y`

### Pull Requests
- PR target: `main` (eller release branch)
- Kräver 1–2 reviewers beroende på storlek.
- PR template-fält:
  - Summary / purpose
  - Related issue(s)
  - How to test locally (inkl. migrations/seed)
  - Checklist: builds, tests, linter, inga secrets, docs uppdaterade
- Merge-strategi: squash eller rebase (team-val), enforce CI green + approvals.

### CI / Quality gates
- Kör `dotnet build`, `dotnet test` för backend.
- Kör ESLint/Prettier och enhetstester för frontend.
- Kör eventuell DB-migration validation i staging pipeline.

### Code standards
**C# (.NET 8)**
- PascalCase för typer/metoder, camelCase för params/locals.
- Använd `async/await` och preferera `CancellationToken` i långkörande metoder (controllers/services).
- Undvik att returnera EF-entiteter direkt — använd DTOs + AutoMapper (projektet använder AutoMapper).
- FluentValidation för input-validering.
- Använd `IUnitOfWork`/repository patterns som finns för DB-access.
- Lägg XML summaries för komplexa publika API:er där det är hjälpsamt.

**Formatting**
- Använd gemensam `.editorconfig` eller kör **Format Document** i Visual Studio / `dotnet format`.
- Commit-meddelanden: följ Conventional Commits (rekommenderat): `feat:`, `fix:`, `chore:`, `docs:`, `refactor:`.

**PR review checklist (kort)**
- Kod bygger lokalt.
- Unit tests passerar.
- Inga secrets i repo.
- Migrations dokumenterade och migrationsfiler läggs i `Peach_ActiviGo.Infrastructure`.
- API-ändringar dokumenterade (Swagger / README).

---

## 5. Quick commands cheat-sheet

- Kör API:
```bash
dotnet run --project Peach_ActiviGo.Api
```

- Applicera migrations (CLI):
```bash
dotnet ef database update --project Peach_ActiviGo.Infrastructure --startup-project Peach_ActiviGo.Api
```

- Kör frontend:
```bash
cd FrontEnd/Peach_ActiviGo.Frontend
npm install
npm run dev
```

- Öppna Visual Studio och använd **Package Manager Console** för `Update-Database` (välj korrekt Default project).

---

## Optional / Förslag på fler filer att lägga till
- `docs/PR_TEMPLATE.md` eller `.github/pull_request_template.md`
- `.env.example`
- Minimal `.editorconfig`
- `CONTRIBUTING.md` baserat på workflow ovan

---

## Notes / Specifika implementationer att känna till
- BookingSeed kräver att seeded slots har `StartTime >= 2025-10-27 12:00` för att bokningar ska skapas vid seed. Om du behöver annan seed-tidsram uppdatera seed-logiken.
- IdentitySeed skapar rollerna `Admin` och `User` och några demo-konton — byt lösenord eller använd user-secrets i produktion.
- CORS-policyn är satt till `AllowAll` i dev; begränsa detta i staging/production.

---

🧡 **Peach_ActiviGo** — En tydlig, strukturerad och modern fullstack-bas.
