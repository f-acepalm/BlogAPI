using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;

namespace DataAccessLayer
{
    public class PostRepository : BaseRepository<Post>, IPostRepository
    {
        public PostRepository(IBlogDbContext context) : base(context)
        {
        }
    }
}
