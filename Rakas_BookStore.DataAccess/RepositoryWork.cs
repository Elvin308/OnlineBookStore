using Microsoft.EntityFrameworkCore.Metadata;
using Rakas_BookStore.DataAccess.Data;
using Rakas_BookStore.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rakas_BookStore.DataAccess
{
    public class RepositoryWork : IRepositoryWork
    {
        private ApplicationDbContext _context;

        public ICategoryRepository CategoryRepository { get; private set; }

        public RepositoryWork(ApplicationDbContext context)
        {
            _context = context;
            CategoryRepository = new CategoryRepository(_context);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
