using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace GenericRepositoryPattern.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentController : ControllerBase
    {
        private readonly IRepositoryWrapper _wrapper;

        public DepartmentController(IRepositoryWrapper wrapper)
        {
            _wrapper = wrapper;
        }

        [HttpGet]
        public IActionResult GetDepartments()
        {
            var departments = _wrapper.Department.GetAllDepartments();
            return Ok(departments);
        }

        [HttpPost]
        public IActionResult CreateDepartment()
        {
            var department = new Department{Name = "KAM"};

            _wrapper.Department.CreateDepartment(department);
            _wrapper.Save();

            return Ok();
        }
    }
}