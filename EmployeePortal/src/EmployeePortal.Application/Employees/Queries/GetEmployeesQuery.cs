namespace EmployeePortal.Application.Employees.Queries;

using EmployeePortal.Domain.Employees;

public class GetEmployeesQuery
{
    private readonly IEmployeeRepository _repo;

    public GetEmployeesQuery(IEmployeeRepository repo)
    {
        _repo = repo;
    }

    public Task<IReadOnlyList<Employee>> ExecuteAsync()
    {
        return _repo.GetAllAsync();
    }
}
