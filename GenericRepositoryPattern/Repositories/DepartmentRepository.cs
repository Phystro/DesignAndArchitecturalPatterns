using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GenericRepositoryPattern.Contracts;

namespace GenericRepositoryPattern.Repositories
{
    public class DepartmentRepository : RepositoryBase<Department>, IDepartmentRepository
    {
        public DepartmentRepository(DataContext _context) : base(_context)
        {
        }

        public void CreateDepartment(Department department) => Create(department);

        public IEnumerable<Department> GetAllDepartments() => FindAll().OrderBy(c => c.Name).ToList();
    }
}