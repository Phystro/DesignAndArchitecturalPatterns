using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GenericRepositoryPattern.Contracts;

namespace GenericRepositoryPattern.Repositories
{
    public class StudentRepository : RepositoryBase<Student>, IStudentRepository
    {
        public StudentRepository(DataContext _context) : base(_context)
        {
        }

        public void CreateStudent(Student student) => Create(student);

        public IEnumerable<Student> GetAllStudents() => FindAll().OrderBy(c => c.Name).ToList();
    }
}