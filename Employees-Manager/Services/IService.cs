using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Employees_Manager.Services
{
    public interface IService<T>
    {
        Task<List<T>> GetAll(Expression<Func<T, object>> filter);
        Task<T> Get(int id, Expression<Func<T, object>> filter);
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(int id);
        Task<bool> Exists(int id);
    }
}
