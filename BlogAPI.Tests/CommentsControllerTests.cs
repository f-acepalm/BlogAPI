using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlogAPI.Controllers;
using Services;
using DataAccessLayer;
using System.Web.Http.Results;
using Models;
using System.Threading.Tasks;
using Mapping;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Routing;
using System.Web.Http.Controllers;
using System.Web.Http.Hosting;

namespace BlogAPI.Tests
{
    [TestClass]
    public class CommentsControllerTests
    {
        [AssemblyInitialize]
        public static void AssemblyInit(TestContext context)
        {
            MapperInitializer.Initialize();
        }

        [TestMethod]
        public async Task PostCommentTest()
        {
            var controller = new CommentsController(new CommentService(new CommentRepository(new TestBlogDbContext())));

            var config = new HttpConfiguration();
            var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost/api/posts");
            var route = config.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{id}");
            var routeData = new HttpRouteData(route, new HttpRouteValueDictionary { { "controller", "posts" } });

            controller.ControllerContext = new HttpControllerContext(config, routeData, request);
            controller.Request = request;
            controller.Request.Properties[HttpPropertyKeys.HttpConfigurationKey] = config;
            controller.Url = new UrlHelper(request);

            var item = GetTestComment();

            var x = await controller.PostComment(item);
            var result = x as ResponseMessageResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Response.StatusCode, System.Net.HttpStatusCode.Created);
        }

        private Comment GetTestComment()
        {
            return new Comment() { Id = 1, Text = "Test", PostId = 1 };
        }
    }
}
