# Repository Pattern

Repository Pattern is an abstraction of the Data Access Layer. It hides the details of how exactly the data is saved or retrieved from the underlying data source.

The details of how the data is stored and retrieved is in the respective repository e.g. you may have a repository that stores and retrieves data from an in-memory collection, You may have another repository that stores and retrieves data from a database like SQL Server, Yet another repository that stores and retrieves data from an XML file.

## Repository Pattern Interface

```cs
public interface IEmployeeRepository
{
    Task<IEnumerable<Employee>> GetEmployees();
    Task<Employee> GetEmployee(int employeeId);
    Task<Employee> AddEmployee(Employee employee);
    Task<Employee> UpdateEmployee(Employee employee);
    void DeleteEmployee(int employeeId);
}
```

The details of how these operations are implmented are in the repository class that implments this IEmployeeRepository interface.

## Repository Pattern Interface Implementation

```cs
namespace EmployeeManagement.Api.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext appDbContext;

        public EmployeeRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await appDbContext.Employees.ToListAsync();
        }

        public async Task<Employee> GetEmployee(int employeeId)
        {
            return await appDbContext.Employees
                .FirstOrDefaultAsync(e => e.EmployeeId == employeeId);
        }

        public async Task<Employee> AddEmployee(Employee employee)
        {
            var result = await appDbContext.Employees.AddAsync(employee);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            var result = await appDbContext.Employees
                .FirstOrDefaultAsync(e => e.EmployeeId == employee.EmployeeId);

            if (result != null)
            {
                result.FirstName = employee.FirstName;
                result.LastName = employee.LastName;
                result.Email = employee.Email;
                result.DateOfBrith = employee.DateOfBrith;
                result.Gender = employee.Gender;
                result.DepartmentId = employee.DepartmentId;
                result.PhotoPath = employee.PhotoPath;

                await appDbContext.SaveChangesAsync();

                return result;
            }

            return null;
        }

        public async void DeleteEmployee(int employeeId)
        {
            var result = await appDbContext.Employees
                .FirstOrDefaultAsync(e => e.EmployeeId == employeeId);
            if (result != null)
            {
                appDbContext.Employees.Remove(result);
                await appDbContext.SaveChangesAsync();
            }
        }
    }
}
```

## Implementation

Provides an instance of EmployeeRepository class when an instance of IEmployeeRepository is requested.

AddScoped() so that the instance will be alive and available for the entire scope of the given HTTP request.

```cs
public void ConfigureServices(IServiceCollection services)
{
    // Rest of the code
    services.AddScoped<IDepartmentRepository, DepartmentRepository>();
    services.AddScoped<IEmployeeRepository, EmployeeRepository>();
}
```

## Pros


* The code is cleaner, and easier to reuse and maintain.
* Enables us to create loosely coupled systems. For example, if we want our application to work with oracle instead of sql server, implement an OracleRepository that knows how to read and write to Oracle database and register OracleRepository with the dependency injection system.
* In an unit testing project, it is easy to replace a real repository with a fake implementation for testing.
