using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Models;
using System.Threading.Tasks;
using IServices;
using AutoMapper;

namespace BlogAPI.Controllers
{
    public class PostsController : ApiController
    {
        private IPostService _postService;

        public PostsController(IPostService postService)
        {
            _postService = postService;
        }

        public async Task<IEnumerable<Post>> GetAllPosts()
        {
            var posts = await _postService.GetAll();

            return Mapper.Map<List<Post>>(posts);
        }

        public async Task<IHttpActionResult> GetPosts(int id)
        {
            var post = await _postService.Get(id);
            if (post == null)
            {
                return NotFound();
            }

            return Ok(post);
        }
    }
}
