using Services.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IService<T> where T : Entity
    {
        Task<T> Create(T entity);

        Task<bool> Update(T entity);

        Task<bool> Delete(int id);

        Task<List<T>> GetAll();

        Task<T> Get(int id);
    }
}
