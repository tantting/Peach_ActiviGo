# Activities CRUD API - Admin Only

This document describes the CRUD (Create, Read, Update, Delete) operations for Activities that are protected with Admin authorization.

## Overview

The Activities CRUD API provides full management capabilities for activities in the Peach ActiviGo system. All endpoints require Admin role authentication via JWT token.

## Architecture

The implementation follows a clean architecture pattern:

- **Core Layer**: Contains domain models and interfaces
  - `Activity` model
  - `IActivityRepository` interface

- **Infrastructure Layer**: Contains data access implementations
  - `ApplicationDbContext` - Entity Framework Core DbContext
  - `ActivityRepository` - Repository implementation

- **Services Layer**: Contains business logic and DTOs
  - `ActivityDto`, `CreateActivityDto`, `UpdateActivityDto` - Data Transfer Objects
  - `IActivityService` interface
  - `ActivityService` - Service implementation
  - `ActivityMappingProfile` - AutoMapper profile
  - `CreateActivityDtoValidator`, `UpdateActivityDtoValidator` - FluentValidation validators

- **API Layer**: Contains HTTP endpoints
  - `ActivitiesController` - RESTful API controller

## API Endpoints

All endpoints are prefixed with `/api/Activities` and require:
- **Authorization**: Bearer token with Admin role
- **Content-Type**: application/json (for POST/PUT)

### 1. Get All Activities
```
GET /api/Activities
```
**Response**: 200 OK with array of ActivityDto

### 2. Get Activity by ID
```
GET /api/Activities/{id}
```
**Response**: 
- 200 OK with ActivityDto
- 404 Not Found if activity doesn't exist

### 3. Create Activity
```
POST /api/Activities
```
**Request Body**:
```json
{
  "name": "string",
  "description": "string (optional)",
  "environment": "string (optional)",
  "timeLenght": "2024-01-01T00:00:00Z",
  "price": 0.00,
  "imageUrl": "string",
  "categoryId": 1
}
```
**Validation Rules**:
- Name: Required, max 200 characters
- Description: Max 1000 characters
- Environment: Max 100 characters
- Price: Must be >= 0
- ImageUrl: Required, max 500 characters
- CategoryId: Must be > 0

**Response**: 201 Created with ActivityDto and Location header

### 4. Update Activity
```
PUT /api/Activities/{id}
```
**Request Body**: Same as Create Activity

**Response**: 
- 200 OK with updated ActivityDto
- 404 Not Found if activity doesn't exist

### 5. Delete Activity
```
DELETE /api/Activities/{id}
```
**Response**: 
- 204 No Content on success
- 404 Not Found if activity doesn't exist

## Security

All endpoints are protected with the `AdminOnly` policy which requires:
1. Valid JWT token in Authorization header: `Bearer <token>`
2. User must have the "Admin" role claim

Unauthorized requests will receive:
- 401 Unauthorized (missing or invalid token)
- 403 Forbidden (valid token but not Admin role)

## Configuration

### Database Connection
Configure in `appsettings.json`:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=...;Database=PeachActiviGo;..."
  }
}
```

### JWT Settings
Configure in `appsettings.json`:
```json
{
  "Jwt": {
    "Key": "YourSecretKey...",
    "Issuer": "PeachActiviGoApi",
    "Audience": "PeachActiviGoClient"
  }
}
```

## Testing

### Using Swagger UI
1. Start the API: `dotnet run`
2. Navigate to: `http://localhost:5194/swagger`
3. Click "Authorize" and enter your JWT token
4. Test the endpoints

### Using cURL
```bash
# Get all activities
curl -H "Authorization: Bearer YOUR_TOKEN" http://localhost:5194/api/Activities

# Create an activity
curl -X POST -H "Authorization: Bearer YOUR_TOKEN" \
  -H "Content-Type: application/json" \
  -d '{"name":"Yoga","price":50,"imageUrl":"https://...","categoryId":1}' \
  http://localhost:5194/api/Activities
```

## Database Migrations

To create and apply migrations:
```bash
# Add migration
dotnet ef migrations add InitialCreate --project Peach_ActiviGo.Infrastructure --startup-project Peach_ActiviGo.Api

# Update database
dotnet ef database update --project Peach_ActiviGo.Infrastructure --startup-project Peach_ActiviGo.Api
```

## Dependencies Registered

The following services are registered in `Program.cs`:

```csharp
// Database
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Repositories
builder.Services.AddScoped<IActivityRepository, ActivityRepository>();

// Services
builder.Services.AddScoped<IActivityService, ActivityService>();

// FluentValidation
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<CreateActivityDtoValidator>();
```

## Error Handling

The API includes comprehensive error handling:
- 400 Bad Request: Invalid input data (validation errors)
- 401 Unauthorized: Missing or invalid JWT token
- 403 Forbidden: Valid token but insufficient permissions
- 404 Not Found: Resource doesn't exist
- 500 Internal Server Error: Unexpected server errors (logged)

All errors are logged for debugging and monitoring purposes.
