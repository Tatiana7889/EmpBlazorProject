namespace EmployeePortal.Domain.Employees;

public class Employee
{
    public int Id { get; private set; }
    public string FirstName { get; private set; } = string.Empty;
    public string LastName { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;
    public DateTime HireDate { get; private set; }

    public Employee(string firstName, string lastName, string email, DateTime hireDate)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        HireDate = hireDate;
    }
}

