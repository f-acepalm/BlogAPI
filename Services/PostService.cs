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
    public class PostService : BaseService<Post, IDataAccessLayer.Entities.Post>, IPostService
    {
        public PostService(IRepository<IDataAccessLayer.Entities.Post> repository) : base(repository)
        {
        }
    }
}
