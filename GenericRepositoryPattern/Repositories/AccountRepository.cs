using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GenericRepositoryPattern.Contracts;

namespace GenericRepositoryPattern.Repositories
{
    public class AccountRepository : RepositoryBase<Account>, IAccountRepository
    {
        public AccountRepository(DataContext _context) : base(_context)
        {
        }
    }
}