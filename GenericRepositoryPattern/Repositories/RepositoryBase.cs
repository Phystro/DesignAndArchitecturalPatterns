using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using GenericRepositoryPattern.Contracts;
using Microsoft.EntityFrameworkCore;

namespace GenericRepositoryPattern.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected DataContext context { get; set; }
        public RepositoryBase(DataContext _context)
        {
            context = _context;
        }

        public IQueryable<T> FindAll() => context.Set<T>().AsNoTracking();

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression) => context.Set<T>().Where(expression).AsNoTracking();

        public void Create(T entity) => context.Set<T>().Add(entity);

        public void Update(T entity) => context.Set<T>().Update(entity);

        public void Delete(T entity) => context.Set<T>().Remove(entity);
    }
}