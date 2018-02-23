using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;

namespace DataAccessLayer
{
    public class CommentRepository : BaseRepository<Comment>, ICommentRepository
    {
        public CommentRepository(IBlogDbContext context) : base(context)
        {
        }
    }
}
