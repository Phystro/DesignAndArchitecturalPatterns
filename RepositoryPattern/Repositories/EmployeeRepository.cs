using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepositoryPattern.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DataContext context;

        public EmployeeRepository(DataContext context)
        {
            this.context = context;
        }

        public Task<Employee> AddEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }

        public void DeleteEmployee(int employeeId)
        {
            throw new NotImplementedException();
        }

        public Task<Employee> GetEmployee(int employeeId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Employee>> GetEmployees()
        {
            throw new NotImplementedException();
        }

        public Task<Employee> UpdateEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}