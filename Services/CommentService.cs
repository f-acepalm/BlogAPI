using DataAccessLayer.Interfaces;
using Services.Interfaces;
using Models;

namespace Services
{
    public class CommentService : BaseService<Comment, DataAccessLayer.Entities.Comment>, ICommentService
    {
        public CommentService(ICommentRepository repository) : base(repository)
        {
        }
    }
}
