using DataAccessLayer.Entities;
using System.Data.Entity;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IBlogDbContext
    {
        IDbSet<Post> Posts { get; }

        IDbSet<Comment> Comments { get; }

        int SaveChanges();

        Task<int> SaveChangesAsync();

        Task MarkAsModified<T>(T item) where T : Entity;

        DbSet<T> Set<T>() where T : class;
    }
}
