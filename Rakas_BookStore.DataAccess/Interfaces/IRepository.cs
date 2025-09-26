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
        //Allow include functionality for loading additional tables through foreign keys
        T GetFirstOrDefault(Expression<Func<T, bool>> expression, string? connectingTables = null);

        //Get all items
        //Allow include functionality for loading additional tables through foreign keys
        IEnumerable<T> GetAll(string? connectingTables = null);

        //Add Item
        void Add(T entity);

        //Remove Item
        void Remove(T entity);

        void RemoveRange(IEnumerable<T> entities);
    }
}
