using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using System;
using System.Data.Entity;
using System.Threading.Tasks;

namespace BlogAPI.Tests
{
    class TestBlogDbContext : IBlogDbContext
    {
        public TestBlogDbContext()
        {
            this.Posts = new TestPostDbSet();
            this.Comments = new TestCommentDbSet();
        }

        public IDbSet<Post> Posts { get; set; }

        public IDbSet<Comment> Comments { get; set; }

        public int SaveChanges()
        {
            return 0;
        }

        public void MarkAsModified<T>(T item) { }

        public void Dispose() { }

        public async Task<int> SaveChangesAsync()
        {
            return await Task.Run(() => 0);
        }

        async Task IBlogDbContext.MarkAsModified<T>(T item)
        {
            await Task.Run(() => { });
        }

        public DbSet<T> Set<T>() where T : class
        {
            if (typeof(T) == typeof(Post))
            {
                return (DbSet<T>)Posts;
            }
            else if(typeof(T) == typeof(Comment))
            {
                return (DbSet<T>)Comments;
            }
            else
            {
                throw new NotImplementedException();
            }
        }
    }
}
