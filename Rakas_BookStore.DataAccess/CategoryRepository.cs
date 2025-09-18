using Rakas_BookStore.DataAccess.Data;
using Rakas_BookStore.DataAccess.Interfaces;
using Rakas_BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rakas_BookStore.DataAccess
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Update(Category cat)
        {
            _context.Update(cat);
        }
    }
}
