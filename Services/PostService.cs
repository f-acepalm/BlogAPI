using DataAccessLayer.Interfaces;
using Services.Interfaces;
using Models;

namespace Services
{
    public class PostService : BaseService<Post, DataAccessLayer.Entities.Post>, IPostService
    {
        public PostService(IPostRepository repository) : base(repository)
        {
        }
    }
}
