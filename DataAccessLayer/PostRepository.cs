using DataAccessLayer.Entities;
using Entities.IDataAccessLayer;
using IDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class PostRepository : IPostRepository
    {
        private List<IPost> Posts = new List<IPost>
        {
            new Post { Id = 1, Title = "Title1", Text = "Text1" },
            new Post { Id = 2, Title = "Title2", Text = "Text2" },
            new Post { Id = 3, Title = "Title3", Text = "Text3" },
        };

        public void Create(IPost post)
        {
            Posts.Add(post);
        }

        public void Delete(int id)
        {
            var post = Get(id);
            if (post != null)
            {
                Posts.Remove(post); 
            }
        }

        public IPost Get(int id)
        {
            return Posts.FirstOrDefault(x => x.Id == id);
        }

        public List<IPost> GetAll()
        {
            return Posts;
        }

        public void Update(IPost post)
        {
            Delete(post.Id);
            Create(post);
        }
    }
}
