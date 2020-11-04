using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Employees_Manager.Data
{
    public interface IRepository<T>
    {

        Task<List<T>> GetAll(Expression<Func<T, object>> filter);
        Task<T> Get(int id, Expression<Func<T, object>> filter);
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(int id);
        Task<bool> Exists(int id);
    }
}
