using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRSMediatRStudent.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly DataContext _context;

        public StudentRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<StudentDetails> AddStudentAsync(StudentDetails studentDetails)
        {
            var result = _context.Students.Add(studentDetails);
            await _context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<int> DeleteStudentAsync(int id)
        {
            var filteredData = _context.Students.Where(x => x.Id == id).FirstOrDefault();
            _context.Students.Remove(filteredData);

            return await _context.SaveChangesAsync();
        }

        public async Task<StudentDetails> GetStudentByIdAsync(int id)
        {
            return await _context.Students.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<StudentDetails>> GetStudentListAsync()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<int> UpdateStudentAsync(StudentDetails studentDetails)
        {
            _context.Students.Update(studentDetails);
            return await _context.SaveChangesAsync();
        }
    }
}