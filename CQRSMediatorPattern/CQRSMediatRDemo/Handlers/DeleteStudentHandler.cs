using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CQRSMediatRDemo.Commands;

namespace CQRSMediatRDemo.Handlers
{
    public class DeleteStudentHandler : IRequestHandler<DeleteStudentCommand, int>
    {
        private readonly StudentRepository _repository;

        public DeleteStudentHandler(StudentRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await _repository.GetStudentByIdAsync(request.Id);
            if(student is null) return default;

            return await _repository.DeleteStudentAsync(student.Id);
        }
    }
}