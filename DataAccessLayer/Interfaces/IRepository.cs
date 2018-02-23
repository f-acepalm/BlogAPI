using DataAccessLayer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IRepository<T> where T : Entity
    {
        Task<T> Create(T entity);

        Task Update(T entity);

        Task Delete(int id);

        Task<List<T>> GetAll();

        Task<T> Get(int id);
    }
}
