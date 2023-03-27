using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericRepositoryPattern.Contracts
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetAllStudents();
        void CreateStudent(Student student);
    }
}