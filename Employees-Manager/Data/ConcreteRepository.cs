using Employees_Manager.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Employees_Manager.Data
{
    public abstract class ConcreteRepository<TEntity> : IRepository<TEntity>
        where TEntity : class, IEntity
    {

        private readonly ApplicationDbContext _db;

        public ConcreteRepository(ApplicationDbContext _db)
        {
            this._db = _db;
        }

        public async Task<TEntity> Add(TEntity entity)
        {
            await _db.Set<TEntity>().AddAsync(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> Delete(int id)
        {
            var entity = await _db.Set<TEntity>().FindAsync(id);
            if (entity == null)
            {
                return entity;
            }

            _db.Set<TEntity>().Remove(entity);
            await _db.SaveChangesAsync();

            return entity;
        }

        public async Task<TEntity> Get(int id, Expression<Func<TEntity, object>> filter)
        {
            return await _db.Set<TEntity>().Include(filter).SingleOrDefaultAsync(i => i.Id == id);
        }

        public async Task<List<TEntity>> GetAll(Expression<Func<TEntity, object>> filter)
        {
            return await _db.Set<TEntity>().Include(filter).ToListAsync();
        }


        public async Task<bool> Exists(int id)
        {
            Employee emp = await _db.Employee.FindAsync();

            if (emp != null) return true;
            return false;
        }

        public abstract Task<TEntity> Update(TEntity entity);
    }
}
