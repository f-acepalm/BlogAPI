using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services;
using DataAccessLayer;
using System.Threading.Tasks;
using Mapping;
using System;
using Moq;
using System.Data.Entity;
using DataAccessLayer.Entities;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace BlogAPI.Tests.Tests
{
    [TestClass]
    public class PostServiceTests
    {
        private Mock<DbSet<Post>> _mockSet;
        private Mock<BlogDbContext> _mockContext;
        private PostService _service;
        private IQueryable<Post> _data;

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            AutoMapperInitializer.Initialize();
        }

        [TestInitialize]
        public void TestInit()
        {
            _data = new List<Post>
            {
                new Post() { Id = 1, Text = "Test", Title = "Test" },
                new Post() { Id = 2, Text = "Test2", Title = "Test" },
                new Post() { Id = 3, Text = "Test3", Title = "Test" },
            }.AsQueryable();

            _mockSet = new Mock<DbSet<Post>>();
            _mockSet.As<IDbAsyncEnumerable<Post>>()
                .Setup(m => m.GetAsyncEnumerator())
                .Returns(new TestDbAsyncEnumerator<Post>(_data.GetEnumerator()));

            _mockSet.As<IQueryable<Post>>()
                .Setup(m => m.Provider)
                .Returns(new TestDbAsyncQueryProvider<Post>(_data.Provider));

            _mockSet.As<IQueryable<Post>>().Setup(m => m.Expression).Returns(_data.Expression);
            _mockSet.As<IQueryable<Post>>().Setup(m => m.ElementType).Returns(_data.ElementType);
            _mockSet.As<IQueryable<Post>>().Setup(m => m.GetEnumerator()).Returns(_data.GetEnumerator());

            _mockContext = new Mock<BlogDbContext>();
            _mockContext.Setup(m => m.Set<Post>()).Returns(_mockSet.Object);
            _service = new PostService(new PostRepository(_mockContext.Object));
        }

        [TestMethod]
        public async Task CreateTest()
        {
            var post = GetTestModel();
            var result = await _service.Create(post);

            _mockSet.Verify(m => m.Add(It.IsAny<Post>()), Times.Once());
            _mockContext.Verify(m => m.SaveChangesAsync(), Times.Once());
            Assert.AreEqual(post.Title, result.Title);
            Assert.AreEqual(post.Text, result.Text);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task CreateWithNullArgumentTest()
        {
            Models.Post post = null;
            var result = await _service.Create(post);
        }

        [TestMethod]
        public async Task UpdateTest()
        {
            var post = GetTestModel();
            await _service.Update(_data.First().Id, post);

            _mockContext.Verify(m => m.MarkAsModified(It.IsAny<Post>()), Times.Once());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task UpdateWithNullArgumentTest()
        {
            Models.Post post = null;
            await _service.Update(0, post);
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public async Task UpdateWithKeyNotFoundExceptionTest()
        {
            _mockContext.Setup(x => x.MarkAsModified(It.IsAny<Post>())).Throws<DbUpdateConcurrencyException>();

            var post = GetTestModel();
            await _service.Update(0, post);
        }

        [TestMethod]
        public async Task GetAllTest()
        {
            var result = await _service.GetAll();

            Assert.AreEqual(3, result.Count);
            Assert.AreEqual(1, result[0].Id);
            Assert.AreEqual(2, result[1].Id);
            Assert.AreEqual(3, result[2].Id);
        }

        [TestMethod]
        public async Task GetTest()
        {
            var result = await _service.Get(1);

            Assert.AreEqual(1, result.Id);
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public async Task GetKeyNotFoundExceptionTest()
        {
            var result = await _service.Get(0);
        }

        [TestMethod]
        public async Task DeleteTest()
        {
            await _service.Delete(1);

            _mockSet.Verify(m => m.Remove(It.IsAny<Post>()), Times.Once());
            _mockContext.Verify(m => m.SaveChangesAsync(), Times.Once());
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public async Task DeleteKeyNotFoundExceptionTest()
        {
            await _service.Delete(0);
        }

        private Models.Post GetTestModel()
        {
            return new Models.Post() { Text = "Test4", Title = "Test" };
        }
    }
}
