using EmployeePortal.Application.Employees.Queries;
using EmployeePortal.Domain.Employees;
using EmployeePortal.Infrastructure.Persistence;
using EmployeePortal.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// EF Core
builder.Services.AddDbContext<EmployeePortalDbContext>(options =>
    options.UseInMemoryDatabase("EmployeePortalDb"));

// Repositories
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();

// Application services
builder.Services.AddScoped<GetEmployeesQuery>();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Swagger UI
app.UseSwagger();
app.UseSwaggerUI();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<EmployeePortalDbContext>();

    if (!db.Employees.Any())
    {
      db.Employees.AddRange(
        new Employee("John", "Doe", "john@example.com", DateTime.UtcNow),
        new Employee("Jane", "Smith", "jane@example.com", DateTime.UtcNow)
    );

        db.SaveChanges();
    }
}


// Endpoints
app.MapGet("/api/employees", async (GetEmployeesQuery query) =>
{
    var employees = await query.ExecuteAsync();
    return Results.Ok(employees);
});

app.Run();
