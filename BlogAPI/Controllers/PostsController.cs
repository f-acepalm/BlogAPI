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

        public async Task<HttpResponseMessage> PostPost(Post item)
        {
            item = Mapper.Map<Post>(await _postService.Create(Mapper.Map<IServices.Entities.Post>(item)));
            var response = Request.CreateResponse(HttpStatusCode.Created, item);

            string uri = Url.Link("DefaultApi", new { id = item.Id });
            response.Headers.Location = new Uri(uri);

            return response;
        }

        public async Task PutPost(int id, Post post)
        {
            post.Id = id;
            var isUpdated = await _postService.Update(Mapper.Map<IServices.Entities.Post>(post));
            if (!isUpdated)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        public async Task DeletePost(int id)
        {
            var isDeleted = await _postService.Delete(id);
            if (!isDeleted)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }
    }
}
