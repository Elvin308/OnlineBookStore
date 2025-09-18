using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rakas_BookStore.DataAccess.Interfaces
{
    public interface IRepositoryWork
    {
        ICategoryRepository CategoryRepository { get; }

        void Save();
    }
}
