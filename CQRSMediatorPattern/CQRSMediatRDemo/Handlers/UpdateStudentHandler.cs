using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CQRSMediatRDemo.Commands;

namespace CQRSMediatRDemo.Handlers
{
    public class UpdateStudentHandler : IRequestHandler<UpdateStudentCommand, int>
    {
        private readonly StudentRepository _repository;

        public UpdateStudentHandler(StudentRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await _repository.GetStudentByIdAsync(request.Id);
            if(student is null) return default;

            student.StudentName = request.StudentName;
            student.StudentEmail = request.StudentEmail;
            student.StudentAddress = request.StudentAddress;
            student.StudentAge = request.StudentAge;

            return await _repository.UpdateStudentAsync(student);
        }
    }
}