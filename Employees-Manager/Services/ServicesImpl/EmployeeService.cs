using Employees_Manager.Data;
using Employees_Manager.Data.EFCore;
using Employees_Manager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Employees_Manager.Services.ServicesImpl
{
    public class EmployeeService : IService<Employee>
    {

        private readonly IRepository<Employee> _empRepository;

        public EmployeeService(EmployeeRepository _empRepository)
        {
            this._empRepository = _empRepository;
        }

        public Task<Employee> Add(Employee entity)
        {
           return _empRepository.Add(entity);
        }

        public Task<Employee> Delete(int id)
        {
            return _empRepository.Delete(id);
        }

        public Task<bool> Exists(int id)
        {
            return _empRepository.Exists(id);
        }

        public Task<Employee> Get(int id, Expression<Func<Employee, object>> filter)
        {
            return _empRepository.Get(id, filter);
        }

        public Task<List<Employee>> GetAll(Expression<Func<Employee, object>> filter)
        {
            return _empRepository.GetAll(filter);
        }

        public Task<Employee> Update(Employee entity)
        {
            return _empRepository.Update(entity);
        }
    }
}
