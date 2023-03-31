using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CQRSMediatRDemo.Queries;

namespace CQRSMediatRDemo.Handlers
{
    public class GetStudentListHandler : IRequestHandler<GetStudentListQuery, List<StudentDetails>>
    {
        private readonly IStudentRepository _repository;

        public GetStudentListHandler(IStudentRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<StudentDetails>> Handle(GetStudentListQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetStudentListAsync();
        }
    }
}