using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IService<TModel> where TModel : BaseModel
    {
        Task<TModel> Create(TModel model);

        Task Update(int id, TModel model);

        Task Delete(int id);

        Task<List<TModel>> GetAll();

        Task<TModel> Get(int id);
    }
}
