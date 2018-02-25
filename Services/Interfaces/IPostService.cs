using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IPostService
    {
        Task<Post> Create(Post model);

        Task Update(int id, Post model);

        Task Delete(int id);

        Task<List<Post>> GetAll();

        Task<Post> Get(int id);
    }
}
