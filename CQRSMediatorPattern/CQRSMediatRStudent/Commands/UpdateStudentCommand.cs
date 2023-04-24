using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRSMediatRStudent.Commands
{
    public class UpdateStudentCommand : IRequest<int>
    {
        public UpdateStudentCommand(int id, string name, string email, string address, int age)
        {
            Id = id;
            Name = name;
            Email = email;
            Address = address;
            Age = age;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
    }
}