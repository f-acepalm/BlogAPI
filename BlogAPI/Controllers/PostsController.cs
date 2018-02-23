using System.Web.Http;
using Models;
using System.Threading.Tasks;
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

        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            return Ok(await _postService.GetAll());
        }

        [HttpGet]
        public async Task<IHttpActionResult> Get(int id)
        {
            return Ok(await _postService.Get(id));
        }

        [HttpPost]
        public async Task<IHttpActionResult> Post([FromBody] Post model)
        {
            return Ok(await _postService.Create(model));
        }

        [HttpPut]
        public async Task<IHttpActionResult> Put(int id, [FromBody] Post model)
        {
            await _postService.Update(id, model);

            return Ok();
        }

        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            await _postService.Delete(id);

            return Ok();
        }
    }
}
