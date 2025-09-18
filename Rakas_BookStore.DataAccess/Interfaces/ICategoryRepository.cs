using Rakas_BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rakas_BookStore.DataAccess.Interfaces
{
    public interface ICategoryRepository : IRepository<Category>
    {
        public void Update(Category cat);
    }
}
