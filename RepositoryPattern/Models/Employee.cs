using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepositoryPattern.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime DateOfBrith { get; set; }
        // public Gender Gender { get; set; }
        public int DepartmentId { get; set; }
        public string PhotoPath { get; set; } = string.Empty;
    }
}