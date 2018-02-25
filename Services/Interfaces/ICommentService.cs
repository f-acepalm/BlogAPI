using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface ICommentService
    {
        Task<Comment> Create(Comment model);

        Task Update(int id, Comment model);

        Task Delete(int id);

        Task<List<Comment>> GetAll();

        Task<Comment> Get(int id);
    }
}
