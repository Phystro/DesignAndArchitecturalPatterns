using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CQRSMediatRDemo.Queries;
using CQRSMediatRDemo.Commands;
using Microsoft.AspNetCore.Mvc;

namespace CQRSMediatRDemo.Controllers
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
            var student = await _mediator.Send(new GetStudentByIdQuery() { Id = id });
            return student;
        }

        [HttpPost]
        public async Task<StudentDetails> AddStudentAsync(StudentDetails studentDetails)
        {
            var student = await _mediator.Send(
                new CreateStudentCommand(
                    studentDetails.StudentName,
                    studentDetails.StudentEmail,
                    studentDetails.StudentAddress,
                    studentDetails.StudentAge
                )
            );

            return student;
        }

        [HttpPut]
        public async Task<int> UpdateStudentAsync(StudentDetails studentDetails)
        {
            var student = await _mediator.Send(
                new UpdateStudentCommand(
                    studentDetails.Id,
                    studentDetails.StudentName,
                    studentDetails.StudentEmail,
                    studentDetails.StudentAddress,
                    studentDetails.StudentAge
                )
            );

            return student;
        }

        [HttpDelete]
        public async Task<int> DeleteStudentAsync(int id)
        {
            return await _mediator.Send(new DeleteStudentCommand());
        }

    }
}