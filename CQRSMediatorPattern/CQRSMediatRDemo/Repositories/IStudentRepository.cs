using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRSMediatRDemo.Repositories
{
    public interface IStudentRepository
    {
        Task<List<StudentDetails>> GetStudentListAsync();
        Task<StudentDetails> GetStudentByIdAsync(int Id);
        Task<StudentDetails> AddStudentAsync(StudentDetails studentDetails);
        Task<int> UpdateStudentAsync(StudentDetails studentDetails);
        Task<int> DeleteStudentAsync(int Id);
    }
}