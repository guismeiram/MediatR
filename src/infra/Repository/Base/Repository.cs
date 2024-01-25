using application.Common.Interfaces.Repository;
using application.Common.Models;
using domain.Common;
using domain.Entities;
using infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace infra.Repository.Base
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        private readonly ApplicationDbContext _dbContext;

        public Repository(ApplicationDbContext dbContext)
        {
           _dbContext = dbContext;
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

        public async Task<T> GetAsyncById(Guid id)
        {
            var result = await _dbContext.Set<T>().FirstOrDefaultAsync(x => x.Id == id);

           

            return result;
        }

        public async Task<IEnumerable<T>> GetAsyncList()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

   
    }
}
