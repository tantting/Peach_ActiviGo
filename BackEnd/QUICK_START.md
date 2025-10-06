# Quick Start Guide - Activities CRUD API

## Prerequisites
- .NET 8.0 SDK
- SQL Server (or SQL Server LocalDB)
- An admin user with JWT token (for testing)

## Setup Steps

### 1. Configure Database
Edit `Peach_ActiviGo.Api/appsettings.json` and update the connection string if needed:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=PeachActiviGo;Trusted_Connection=true;MultipleActiveResultSets=true"
  }
}
```

### 2. Create Database
Run migrations to create the database:
```bash
cd BackEnd
dotnet ef migrations add InitialCreate --project Peach_ActiviGo.Infrastructure --startup-project Peach_ActiviGo.Api
dotnet ef database update --project Peach_ActiviGo.Infrastructure --startup-project Peach_ActiviGo.Api
```

### 3. Run the API
```bash
cd BackEnd/Peach_ActiviGo.Api
dotnet run
```

The API will start at: `http://localhost:5194`

### 4. Access Swagger UI
Open your browser and navigate to:
```
http://localhost:5194/swagger
```

## Testing the API

### Option 1: Using Swagger UI (Recommended)

1. Open Swagger UI at `http://localhost:5194/swagger`
2. Click the "Authorize" button at the top
3. Enter your JWT token in the format: `Bearer YOUR_TOKEN_HERE`
4. Click "Authorize"
5. Test any endpoint by clicking "Try it out"

### Option 2: Using cURL

First, set your JWT token as an environment variable:
```bash
export TOKEN="your_jwt_token_here"
```

Then test the endpoints:

**Get all activities:**
```bash
curl -H "Authorization: Bearer $TOKEN" http://localhost:5194/api/Activities
```

**Get activity by ID:**
```bash
curl -H "Authorization: Bearer $TOKEN" http://localhost:5194/api/Activities/1
```

**Create an activity:**
```bash
curl -X POST -H "Authorization: Bearer $TOKEN" \
  -H "Content-Type: application/json" \
  -d '{
    "name": "Yoga Class",
    "description": "Relaxing yoga session",
    "environment": "Indoor",
    "timeLenght": "2024-01-01T10:00:00Z",
    "price": 50.00,
    "imageUrl": "https://example.com/yoga.jpg",
    "categoryId": 1
  }' \
  http://localhost:5194/api/Activities
```

**Update an activity:**
```bash
curl -X PUT -H "Authorization: Bearer $TOKEN" \
  -H "Content-Type: application/json" \
  -d '{
    "name": "Advanced Yoga Class",
    "description": "Advanced yoga session",
    "environment": "Indoor",
    "timeLenght": "2024-01-01T10:00:00Z",
    "price": 75.00,
    "imageUrl": "https://example.com/yoga-advanced.jpg",
    "categoryId": 1
  }' \
  http://localhost:5194/api/Activities/1
```

**Delete an activity:**
```bash
curl -X DELETE -H "Authorization: Bearer $TOKEN" \
  http://localhost:5194/api/Activities/1
```

### Option 3: Using Postman

1. Create a new request
2. Add a header: `Authorization: Bearer YOUR_TOKEN`
3. Set the appropriate HTTP method and URL
4. For POST/PUT requests, set `Content-Type: application/json` and add the request body

## Expected Responses

### Without Authentication
All endpoints will return:
```
HTTP 401 Unauthorized
```

### Without Admin Role
With a valid token but without Admin role:
```
HTTP 403 Forbidden
```

### With Admin Authentication

**GET /api/Activities** (empty database):
```json
[]
```

**POST /api/Activities** (success):
```json
{
  "id": 1,
  "name": "Yoga Class",
  "description": "Relaxing yoga session",
  "environment": "Indoor",
  "timeLenght": "2024-01-01T10:00:00Z",
  "price": 50.00,
  "imageUrl": "https://example.com/yoga.jpg",
  "categoryId": 1,
  "categoryName": "Fitness"
}
```
HTTP Status: `201 Created`

**GET /api/Activities/1** (found):
```json
{
  "id": 1,
  "name": "Yoga Class",
  ...
}
```
HTTP Status: `200 OK`

**GET /api/Activities/999** (not found):
```json
"Activity with id 999 not found"
```
HTTP Status: `404 Not Found`

**PUT /api/Activities/1** (success):
```json
{
  "id": 1,
  "name": "Advanced Yoga Class",
  ...
}
```
HTTP Status: `200 OK`

**DELETE /api/Activities/1** (success):
No body
HTTP Status: `204 No Content`

## Troubleshooting

### Cannot connect to database
- Ensure SQL Server is running
- Check the connection string in appsettings.json
- Verify migrations have been applied

### 401 Unauthorized
- Ensure you have a valid JWT token
- Check that the token is not expired
- Verify the JWT configuration in appsettings.json matches the token

### 403 Forbidden
- Ensure your user has the "Admin" role
- Check that the role claim is included in the JWT token

### Validation errors (400 Bad Request)
- Check the request body matches the DTO structure
- Ensure required fields are provided
- Verify field lengths don't exceed maximum limits
- Ensure price and categoryId are positive numbers

## Next Steps

1. Create users and assign Admin roles
2. Set up authentication endpoints (if not already done)
3. Create additional controllers for Categories, Locations, etc.
4. Add integration tests
5. Configure production database

For more details, see [README_ACTIVITIES_CRUD.md](./README_ACTIVITIES_CRUD.md)
