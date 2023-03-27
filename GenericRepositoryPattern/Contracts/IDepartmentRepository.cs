using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericRepositoryPattern.Contracts
{
    public interface IDepartmentRepository
    {
        IEnumerable<Department> GetAllDepartments();
        void CreateDepartment(Department department);
    }
}