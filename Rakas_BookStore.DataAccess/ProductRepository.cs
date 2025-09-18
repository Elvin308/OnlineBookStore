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
    public class ProductRepository : Repository<Product>, IProductRepository
    {

        private ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context) : base(context)
        { 
            _context = context;
        }

        public void Update(Product prod)
        {
            _context.Update(prod);
        }

    }
}
