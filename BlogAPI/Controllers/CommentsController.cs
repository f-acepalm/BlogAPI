using Models;
using Services.Interfaces;
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

        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            return Ok(await _commentService.GetAll());
        }

        [HttpGet]
        public async Task<IHttpActionResult> Get(int id)
        {
            return Ok(await _commentService.Get(id));
        }

        [HttpPost]
        public async Task<IHttpActionResult> Post([FromBody] Comment model)
        {
            return Ok(await _commentService.Create(model));
        }

        [HttpPut]
        public async Task<IHttpActionResult> Put(int id, [FromBody] Comment model)
        {
            await _commentService.Update(id, model);

            return Ok();
        }

        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            await _commentService.Delete(id);

            return Ok();
        }
    }
}
