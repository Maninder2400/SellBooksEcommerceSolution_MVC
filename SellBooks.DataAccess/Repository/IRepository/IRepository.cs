using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SellBooks.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        //T - Product
        IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, string? includeNavProperties = null);
        T Get(Expression<Func<T,bool>>filter, string? includeNavProperties = null,bool tracked = false);
        
        void Add(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entity);
    }
}
