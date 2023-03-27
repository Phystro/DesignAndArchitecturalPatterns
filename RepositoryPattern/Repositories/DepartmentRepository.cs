using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepositoryPattern.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly DataContext context;

        public DepartmentRepository(DataContext context)
        {
            this.context = context;
        }

        public Department GetDepartment(int departmentId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Department> GetDepartments()
        {
            throw new NotImplementedException();
        }
    }
}