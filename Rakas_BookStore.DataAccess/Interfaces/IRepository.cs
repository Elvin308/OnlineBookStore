using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Rakas_BookStore.DataAccess.Interfaces
{
    public interface IRepository<T> where T : class //Generetic interface that takes in a class
    {
        //Get first item // Allow use of Linq expressions
        T GetFirstOrDefault(Expression<Func<T, bool>> expression);

        //Get all items
        IEnumerable<T> GetAll();

        //Add Item
        void Add(T entity);

        //Remove Item
        void Remove(T entity);

        void RemoveRange(IEnumerable<T> entities);
    }
}
