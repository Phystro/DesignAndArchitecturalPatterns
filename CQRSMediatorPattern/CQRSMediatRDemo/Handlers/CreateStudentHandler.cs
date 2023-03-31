using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CQRSMediatRDemo.Commands;

namespace CQRSMediatRDemo.Handlers
{
    public class CreateStudentHandler : IRequestHandler<CreateStudentCommand, StudentDetails>
    {
        private readonly IStudentRepository _repository;

        public CreateStudentHandler(IStudentRepository repository)
        {
            _repository = repository;
        }

        public async Task<StudentDetails> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            var studentDetails = new StudentDetails()
            {
                StudentName = request.StudentName,
                StudentEmail = request.StudentEmail,
                StudentAddress = request.StudentAddress,
                StudentAge = request.StudentAge
            };

            return await _repository.AddStudentAsync(studentDetails);
        }
    }
}