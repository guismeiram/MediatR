using application.Common.Interfaces.Repository;
using domain.Common;
using domain.Entities;
using infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace infra.Repository.Base
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        private readonly ApplicationDbContext _dbContext;

        public Repository(ApplicationDbContext _dbContext)
        {
            this._dbContext = _dbContext;
        }

        public async Task<T> AddAsync(T entity)
        {
            try
            {
                entity.CreatedAt = DateTime.UtcNow;
                var result = await _dbContext.AddAsync(entity);
            }
            catch (System.Exception)
            {
                throw;
            }

            return entity;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                var entity = await _dbContext.Set<T>().SingleOrDefaultAsync(x => x.Id == id);
                if (entity == null)
                    return false;

                var result = _dbContext.Set<T>().Remove(entity);
                return true;
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<T>> GetWhere(Expression<Func<T, bool>> predicate)
            => await _dbContext.Set<T>().Where(predicate).ToListAsync();

        public IQueryable<T> AsQueryable(Expression<Func<T, bool>> predicate = null)
            => predicate == null ? _dbContext.Set<T>().AsQueryable() : _dbContext.Set<T>().Where(predicate).AsQueryable();


        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _dbContext.Set<T>().FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            try
            {
                var result = await _dbContext.Set<T>().SingleOrDefaultAsync(x => x.Id == entity.Id);
                if (result == null)
                    return null;

                entity.UpdatedAt = DateTime.UtcNow;
                entity.CreatedAt = result.CreatedAt;

                _dbContext.Entry(result).State = EntityState.Detached;
                _dbContext.Set<T>().Update(entity);
            }
            catch (System.Exception)
            {
                throw;
            }

            return entity;
        }
    }
}
