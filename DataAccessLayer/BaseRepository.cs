using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public abstract class BaseRepository<T> : IRepository<T> where T : Entity
    {
        private IBlogDbContext _dbContex;

        public BaseRepository(IBlogDbContext context)
        {
            _dbContex = context;
        }

        public virtual async Task<T> Create(T entity)
        {
            _dbContex.Set<T>().Add(entity);
            await _dbContex.SaveChangesAsync();

            return entity;
        }

        public virtual async Task Delete(int id)
        {
            var entity = await Get(id);
            if (entity != null)
            {
                _dbContex.Set<T>().Remove(entity);
                await _dbContex.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"{id} is invalid Id.");
            }
        }

        public virtual async Task<T> Get(int id)
        {
            return await _dbContex.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public virtual async Task<List<T>> GetAll()
        {
            return await _dbContex.Set<T>().ToListAsync();
        }

        public virtual async Task Update(T entity)
        {
            try
            {
                await _dbContex.MarkAsModified(entity);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new KeyNotFoundException($"{entity.Id} is invalid Id.");
            }
        }
    }
}
