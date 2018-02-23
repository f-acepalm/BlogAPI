using DataAccessLayer.Interfaces;
using Services.Interfaces;
using Services.Models;

namespace Services
{
    public class CommentService : BaseService<Comment, DataAccessLayer.Entities.Comment>, ICommentService
    {
        public CommentService(ICommentRepository repository) : base(repository)
        {
        }
    }
}
