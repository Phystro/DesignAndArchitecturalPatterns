using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GenericRepositoryPattern.Contracts;

namespace GenericRepositoryPattern.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private DataContext _context;
        private IOwnerRepository _owner;
        private IAccountRepository _account;
        private IDepartmentRepository _department;
        private IStudentRepository _student;

        public RepositoryWrapper(DataContext context, IOwnerRepository owner, IAccountRepository account, IDepartmentRepository department, IStudentRepository student)
        {
            _context = context;
            _owner = owner;
            _account = account;
            _department = department;
            _student = student;
        }

        public IOwnerRepository Owner
        {
            get
            {
                if (_owner == null) _owner = new OwnerRepository(_context);

                return _owner;
            }
        }

        public IAccountRepository Account
        {
            get
            {
                if (_account == null) _account = new AccountRepository(_context);

                return _account;
            }
        }

        IDepartmentRepository IRepositoryWrapper.Department
        {
            get
            {
                if(_department == null) _department = new DepartmentRepository(_context);

                return _department;
            }
        }

        IStudentRepository IRepositoryWrapper.Student
        {
            get
            {
                if(_student == null) _student = new StudentRepository(_context);

                return _student;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}