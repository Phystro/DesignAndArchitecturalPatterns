using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRSMediatRStudent.Commands
{
    public class CreateStudentCommand : IRequest<StudentDetails>
    {
        public CreateStudentCommand(string name, string email, string address, int age)
        {
            Name = name;
            Email = email;
            Address = address;
            Age = age;
        }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
    }
}