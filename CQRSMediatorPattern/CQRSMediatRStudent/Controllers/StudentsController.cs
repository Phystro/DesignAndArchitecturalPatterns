using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CQRSMediatRStudent.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StudentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<StudentDetails>> GetStudentListAsync()
        {
            var studentDetails = await _mediator.Send(new GetStudentListQuery());

            return studentDetails;
        }

        [HttpGet("{id}")]
        public async Task<StudentDetails> GetStudentByIdAsync(int id)
        {
            var studentDetails = await _mediator.Send( new GetStudentByIdQuery()
            {
                Id = id
            } );

            return studentDetails;
        }

        [HttpPost]
        public async Task<StudentDetails> AddStudentAsync(StudentDetails studentDetails)
        {
            var studentDetail = await _mediator.Send( new CreateStudentCommand(
                name: studentDetails.Name,
                email: studentDetails.Email,
                address: studentDetails.Address,
                age: studentDetails.Age
            ) );

            return studentDetail;
        }

        [HttpPut]
        public async Task<int> UpdateStudentAsync(StudentDetails studentDetails)
        {
            var isUpdated = await _mediator.Send( new UpdateStudentCommand(
                id: studentDetails.Id,
                name: studentDetails.Name,
                email: studentDetails.Email,
                address: studentDetails.Address,
                age: studentDetails.Age
            ) );

            return isUpdated;
        }

        [HttpDelete]
        public async Task<int> DeleteStudentAsync(int id)
        {
            return await _mediator.Send( new DeleteStudentCommand() );
        }
    }
}