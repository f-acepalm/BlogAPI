using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Models;
using System.Threading.Tasks;
using AutoMapper;
using BlogAPI.Filters;
using Services.Interfaces;

namespace BlogAPI.Controllers
{
    [ValidateModel]
    public class PostsController : ApiController
    {
        private IPostService _postService;

        public PostsController(IPostService postService)
        {
            _postService = postService;
        }

        public async Task<IHttpActionResult> GetAllPosts()
        {
            var posts = await _postService.GetAll();

            return Ok(Mapper.Map<List<Post>>(posts));
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

        public async Task<IHttpActionResult> PostPost(Post item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            item = Mapper.Map<Post>(await _postService.Create(Mapper.Map<Services.Models.Post>(item)));
            var response = Request.CreateResponse(HttpStatusCode.Created, item);

            string uri = Url.Link("DefaultApi", new { id = item.Id });
            response.Headers.Location = new Uri(uri);

            return ResponseMessage(response);
        }

        public async Task<IHttpActionResult> PutPost(int id, Post post)
        {
            if (post == null)
            {
                return BadRequest();
            }

            post.Id = id;
            var isUpdated = await _postService.Update(Mapper.Map<Services.Models.Post>(post));
            if (!isUpdated)
            {
                return NotFound();
            }

            return Ok();
        }

        public async Task<IHttpActionResult> DeletePost(int id)
        {
            var isDeleted = await _postService.Delete(id);
            if (!isDeleted)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
