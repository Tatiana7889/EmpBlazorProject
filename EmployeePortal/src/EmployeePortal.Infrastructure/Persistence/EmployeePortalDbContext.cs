namespace EmployeePortal.Infrastructure.Persistence;

using EmployeePortal.Domain.Employees;
using Microsoft.EntityFrameworkCore;

public class EmployeePortalDbContext : DbContext
{
    public EmployeePortalDbContext(DbContextOptions<EmployeePortalDbContext> options)
        : base(options)
    {
    }

    public DbSet<Employee> Employees => Set<Employee>();
}
