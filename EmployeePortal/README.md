# EmployeePortal

A full Clean Architecture enterprise application demonstrating:

- Blazor
- .NET 10
- Clean Architecture
- DDD
- Repository Pattern
- EF Core + SQL Server
- REST APIs
- Authentication-ready
- Unit Testing
- CI/CD (GitHub Actions)
- Azure deployment ready

## Architecture
See /docs/architecture.png

## Database
See /docs/database.png
## Start 
dotnet clean
dotnet build
dotnet run --project src/EmployeePortal.Blazor
dotnet run --project src/EmployeePortal.Api

http://localhost:5284/api/employees
