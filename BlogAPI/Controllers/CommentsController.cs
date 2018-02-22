using AutoMapper;
using IServices;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace BlogAPI.Controllers
{
    public class CommentsController : ApiController
    {
        private ICommentService _commentService;

        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public async Task<IEnumerable<Comment>> GetAllComments()
        {
            var comments = await _commentService.GetAll();

            return Mapper.Map<List<Comment>>(comments);
        }

        public async Task<IHttpActionResult> GetComments(int id)
        {
            var comment = await _commentService.Get(id);
            if (comment == null)
            {
                return NotFound();
            }

            return Ok(comment);
        }

        public async Task<HttpResponseMessage> PostComment(Comment item)
        {
            item = Mapper.Map<Comment>(await _commentService.Create(Mapper.Map<IServices.Entities.Comment>(item)));
            var response = Request.CreateResponse(HttpStatusCode.Created, item);

            string uri = Url.Link("DefaultApi", new { id = item.Id });
            response.Headers.Location = new Uri(uri);

            return response;
        }

        public async Task PutComment(int id, Comment comment)
        {
            comment.Id = id;
            var isUpdated = await _commentService.Update(Mapper.Map<IServices.Entities.Comment>(comment));
            if (!isUpdated)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        public async Task DeleteComment(int id)
        {
            var isDeleted = await _commentService.Delete(id);
            if (!isDeleted)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }
    }
}
