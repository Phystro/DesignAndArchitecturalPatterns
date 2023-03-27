using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GenericRepositoryPattern.Contracts;
using GenericRepositoryPattern.Models;

namespace GenericRepositoryPattern.Repositories
{
    public class OwnerRepository : RepositoryBase<Owner>, IOwnerRepository
    {
        public OwnerRepository(DataContext _context) : base(_context)
        {
        }
    }
}