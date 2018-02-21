using IDataAccessLayer;
using IDataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class BaseRepository<T> : IRepository<T> where T : Entity
    {
        private BlogDbContext _dbContex = new BlogDbContext();

        public void Create(T entity)
        {
            _dbContex.Set<T>().Add(entity);
            _dbContex.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = Get(id);
            if (entity != null)
            {
                _dbContex.Set<T>().Remove(entity);
                _dbContex.SaveChanges();
            }
        }

        public T Get(int id)
        {
            return _dbContex.Set<T>().FirstOrDefault(x => x.Id == id);
        }

        public List<T> GetAll()
        {
            return _dbContex.Set<T>().ToList();
        }

        public void Update(T entity)
        {
            _dbContex.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            _dbContex.SaveChanges();
        }
    }
}
