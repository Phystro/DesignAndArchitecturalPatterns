using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace GenericRepositoryPattern.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly IRepositoryWrapper _wrapper;

        public StudentsController(IRepositoryWrapper wrapper)
        {
            _wrapper = wrapper;
        }

        [HttpGet]
        public IActionResult GetStudents()
        {
            var students = _wrapper.Student.GetAllStudents();
            return Ok(students);
        }

        [HttpPost]
        public IActionResult CreateStudents()
        {
            var student = new Student{Name = "Karoki"};

            _wrapper.Student.CreateStudent(student);
            _wrapper.Save();

            return Ok();
        }
    }
}