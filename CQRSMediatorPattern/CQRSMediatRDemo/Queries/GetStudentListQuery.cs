using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace CQRSMediatRDemo.Queries
{
    public class GetStudentListQuery : IRequest<List<StudentDetails>>
    {
    }
}