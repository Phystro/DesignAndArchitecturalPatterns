using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRSMediatRStudent.Handlers
{
    public class CreateStudentHandler : IRequestHandler<CreateStudentCommand, StudentDetails>
    {
        private readonly IStudentRepository _studentRepository;

        public CreateStudentHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<StudentDetails> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            var studentDetails = new StudentDetails()
            {
                Name = request.Name,
                Email = request.Email,
                Address = request.Address,
                Age = request.Age
            };

            return await _studentRepository.AddStudentAsync(studentDetails);
        }
    }
}