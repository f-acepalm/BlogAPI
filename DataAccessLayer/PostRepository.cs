using IDataAccessLayer;
using IDataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class PostRepository : BaseRepository<Post>, IPostRepository
    {
    }
}
