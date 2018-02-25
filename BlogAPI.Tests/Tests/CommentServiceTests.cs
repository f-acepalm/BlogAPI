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

namespace BlogAPI.Tests
{
    [TestClass]
    public class CommentServiceTests
    {
        private Mock<DbSet<Comment>> _mockSet;
        private Mock<BlogDbContext> _mockContext;
        private CommentService _service;
        private IQueryable<Comment> _data;

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            AutoMapperInitializer.Initialize();
        }

        [TestInitialize]
        public void TestInit()
        {
            _data = new List<Comment>
            {
                new Comment() { Id = 1, Text = "Test", PostId = 1 },
                new Comment() { Id = 2, Text = "Test2", PostId = 1 },
                new Comment() { Id = 3, Text = "Test3", PostId = 1 },
            }.AsQueryable();

            _mockSet = new Mock<DbSet<Comment>>();
            _mockSet.As<IDbAsyncEnumerable<Comment>>()
                .Setup(m => m.GetAsyncEnumerator())
                .Returns(new TestDbAsyncEnumerator<Comment>(_data.GetEnumerator()));

            _mockSet.As<IQueryable<Comment>>()
                .Setup(m => m.Provider)
                .Returns(new TestDbAsyncQueryProvider<Comment>(_data.Provider));

            _mockSet.As<IQueryable<Comment>>().Setup(m => m.Expression).Returns(_data.Expression);
            _mockSet.As<IQueryable<Comment>>().Setup(m => m.ElementType).Returns(_data.ElementType);
            _mockSet.As<IQueryable<Comment>>().Setup(m => m.GetEnumerator()).Returns(_data.GetEnumerator());

            _mockContext = new Mock<BlogDbContext>();
            _mockContext.Setup(m => m.Set<Comment>()).Returns(_mockSet.Object);
            _service = new CommentService(new CommentRepository(_mockContext.Object));
        }

        [TestMethod]
        public async Task Create_ValidModel_SuccessfullyAdded()
        {
            var comment = GetTestModel();
            var result = await _service.Create(comment);

            _mockSet.Verify(m => m.Add(It.IsAny<Comment>()), Times.Once());
            _mockContext.Verify(m => m.SaveChangesAsync(), Times.Once());
            Assert.AreEqual(comment.PostId, result.PostId);
            Assert.AreEqual(comment.Text, result.Text);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task Create_ModelIsNull_ArgumentNullException()
        {
            Models.Comment comment = null;
            var result = await _service.Create(comment);
        }

        [TestMethod]
        public async Task Update_ValidModel_SuccessfullyUpdated()
        {
            var comment = GetTestModel();
            await _service.Update(_data.First().Id, comment);

            _mockContext.Verify(m => m.MarkAsModified(It.IsAny<Comment>()), Times.Once());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task Update_ModelIsNull_ArgumentNullException()
        {
            Models.Comment comment = null;
            await _service.Update(0, comment);
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public async Task Update_IdDoesNotExist_KeyNotFoundException()
        {
            _mockContext.Setup(x => x.MarkAsModified(It.IsAny<Comment>())).Throws<DbUpdateConcurrencyException>();

            var comment = GetTestModel();
            await _service.Update(0, comment);
        }

        [TestMethod]
        public async Task GetAll_ReturnedThreeElements()
        {
            var result = await _service.GetAll();

            Assert.AreEqual(3, result.Count);
            Assert.AreEqual(1, result[0].Id);
            Assert.AreEqual(2, result[1].Id);
            Assert.AreEqual(3, result[2].Id);
        }

        [TestMethod]
        public async Task Get_First_IdsAreEqual()
        {
            var result = await _service.Get(1);

            Assert.AreEqual(1, result.Id);
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public async Task Get_IdDoesNotExist_KeyNotFoundExceptionTest()
        {
            var result = await _service.Get(0);
        }

        [TestMethod]
        public async Task Delete_ValidId_RemoveWasCalled()
        {
            await _service.Delete(1);

            _mockSet.Verify(m => m.Remove(It.IsAny<Comment>()), Times.Once());
            _mockContext.Verify(m => m.SaveChangesAsync(), Times.Once());
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public async Task Delete_IdDoesNotExist_KeyNotFoundException()
        {
            await _service.Delete(0);
        }

        private Models.Comment GetTestModel()
        {
            return new Models.Comment() { Text = "Test4", PostId = 1 };
        }
    }
}
