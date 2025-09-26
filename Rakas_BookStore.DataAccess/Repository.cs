using Microsoft.EntityFrameworkCore;
using Rakas_BookStore.DataAccess.Data;
using Rakas_BookStore.DataAccess.Interfaces;
using Rakas_BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Rakas_BookStore.DataAccess
{
    public class Repository<T> : IRepository<T> where T : class //Generic class that implements generic Repository interface
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

        //Allow include functionality for loading additional tables through foreign keys
        /// <summary>
        /// Retrieve all records in a table with or without instances of foreign tables
        /// </summary>
        /// <param name="connectingTables">Foreign tables to load in [Comma seperated]</param>
        /// <returns>Returns all records for a table</returns>
        public IEnumerable<T> GetAll(string? connectingTables = null)
        {
            IQueryable<T> query = _dbSet;

            if (!string.IsNullOrEmpty(connectingTables))
            {
                //Include each table into the dataset
                foreach(var table in connectingTables.Split(',',StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(table);
                }
            }

            return query.ToList();
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> expression, string? connectingTables = null)
        {
            IQueryable<T> query = _dbSet;

            if (!string.IsNullOrEmpty(connectingTables))
            {
                //Include each table into the dataset
                foreach (var table in connectingTables.Split(',', StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(table);
                }
            }

            return query.FirstOrDefault(expression);
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
