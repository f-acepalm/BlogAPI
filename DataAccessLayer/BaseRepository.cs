using IDataAccessLayer;
using IDataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class BaseRepository<T> : IRepository<T> where T : Entity
    {
        private BlogDbContext _dbContex = new BlogDbContext();

        public async Task Create(T entity)
        {
            _dbContex.Set<T>().Add(entity);
            await _dbContex.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await Get(id);
            if (entity != null)
            {
                _dbContex.Set<T>().Remove(entity);
                await _dbContex.SaveChangesAsync();
            }
        }

        public async Task<T> Get(int id)
        {
            return await _dbContex.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<T>> GetAll()
        {
            return await _dbContex.Set<T>().ToListAsync();
        }

        public async Task Update(T entity)
        {
            try
            {
                _dbContex.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                await _dbContex.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new ArgumentException($"{entity.Id} is invalid Id.");
            }
        }
    }
}
