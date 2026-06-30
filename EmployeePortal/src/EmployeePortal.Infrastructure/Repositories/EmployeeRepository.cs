namespace EmployeePortal.Infrastructure.Repositories;

using EmployeePortal.Domain.Employees;
using EmployeePortal.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly EmployeePortalDbContext _db;

    public EmployeeRepository(EmployeePortalDbContext db)
    {
        _db = db;
    }

    public Task<Employee?> GetByIdAsync(int id)
    {
        return _db.Employees.FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<IReadOnlyList<Employee>> GetAllAsync()
    {
        return await _db.Employees.AsNoTracking().ToListAsync();
    }

    public async Task AddAsync(Employee employee)
    {
        _db.Employees.Add(employee);
        await _db.SaveChangesAsync();
    }

    public async Task UpdateAsync(Employee employee)
    {
        _db.Employees.Update(employee);
        await _db.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await GetByIdAsync(id);
        if (entity is null) return;

        _db.Employees.Remove(entity);
        await _db.SaveChangesAsync();
    }
}
