using IServices;
using IServices.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDataAccessLayer;

namespace Services
{
    public class CommentService : BaseService<Comment, IDataAccessLayer.Entities.Comment>, ICommentService
    {
        public CommentService(ICommentRepository repository) : base(repository)
        {
        }
    }
}
