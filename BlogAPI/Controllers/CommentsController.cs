using AutoMapper;
using Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
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

        public async Task<IHttpActionResult> GetAllComments()
        {
            var comments = await _commentService.GetAll();

            return Ok(Mapper.Map<List<Comment>>(comments));
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

        public async Task<IHttpActionResult> PostComment(Comment item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            item = Mapper.Map<Comment>(await _commentService.Create(Mapper.Map<Services.Models.Comment>(item)));
            var response = Request.CreateResponse(HttpStatusCode.Created, item);

            string uri = Url.Link("DefaultApi", new { id = item.Id });
            response.Headers.Location = new Uri(uri);

            return ResponseMessage(response);
        }

        public async Task<IHttpActionResult> PutComment(int id, Comment comment)
        {
            if (comment == null)
            {
                return BadRequest();
            }

            comment.Id = id;
            var isUpdated = await _commentService.Update(Mapper.Map<Services.Models.Comment>(comment));
            if (!isUpdated)
            {
                return NotFound();
            }

            return Ok();
        }

        public async Task<IHttpActionResult> DeleteComment(int id)
        {
            var isDeleted = await _commentService.Delete(id);
            if (!isDeleted)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
