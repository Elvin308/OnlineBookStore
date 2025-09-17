using Microsoft.EntityFrameworkCore;
using Rakas_BookStore.DataAccess.Data;
using Rakas_BookStore.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Rakas_BookStore.DataAccess
{
    internal class Repository<T> : IRepository<T> where T : class //Generic class that implements generic Repository interface
    {
        private readonly ApplicationDbContext _context;
        internal DbSet<T> _dbSet; //Only accessible in this project

        //Get database from DI
        public Repository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> expression)
        {
            return _dbSet.FirstOrDefault(expression);
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }
    }
}
