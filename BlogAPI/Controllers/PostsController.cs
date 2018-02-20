using BlogAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BlogAPI.Controllers
{
    public class PostsController : ApiController
    {
        Post[] posts = new Post[]
        {
            new Post { Id = 1, Title = "Title1", Text = "Text1", UserName = "User1" },
            new Post { Id = 2, Title = "Title2", Text = "Text2", UserName = "User2" },
            new Post { Id = 3, Title = "Title3", Text = "Text3", UserName = "User3" },
        };

        public IEnumerable<Post> GetAllPosts()
        {
            return posts;
        }

        public IHttpActionResult GetPosts(int id)
        {
            var post = posts.FirstOrDefault((p) => p.Id == id);
            if (post == null)
            {
                return NotFound();
            }

            return Ok(post);
        }
    }
}
