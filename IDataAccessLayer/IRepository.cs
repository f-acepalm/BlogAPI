using IDataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDataAccessLayer
{
    public interface IRepository<T> where T : Entity
    {
        Task Create(T entity);

        Task Update(T entity);

        Task Delete(int id);

        Task<List<T>> GetAll();

        Task<T> Get(int id);
    }
}
