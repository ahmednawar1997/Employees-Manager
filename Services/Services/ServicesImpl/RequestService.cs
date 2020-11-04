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
    public class RequestService : IService<Request>
    {

        private readonly IRepository<Request> _reqRepository;

        public RequestService(RequestRepository _reqRepository)
        {
            this._reqRepository = _reqRepository;
        }
        public Task<Request> Add(Request entity)
        {
            return _reqRepository.Add(entity);
        }

        public Task<Request> Delete(int id)
        {
            return _reqRepository.Delete(id);
        }

        public Task<bool> Exists(int id)
        {
            return _reqRepository.Exists(id);
        }

        public Task<Request> Get(int id, Expression<Func<Request, object>> filter)
        {
            return _reqRepository.Get(id, filter);
        }

        public Task<List<Request>> GetAll(Expression<Func<Request, object>> filter)
        {
            return _reqRepository.GetAll(filter);
        }

        public Task<Request> Update(Request entity)
        {
            return _reqRepository.Update(entity);
        }
    }
}
