using IDataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDataAccessLayer
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
