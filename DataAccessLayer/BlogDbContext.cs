using IDataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext() : base("DefaultConnection")
        {
        }

        public IDbSet<Post> Posts { get; set; }

        public IDbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Post>()
                .HasMany(x => x.Comments)
                .WithRequired(x => x.Post)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Post>()
                .Property(x => x.Title).HasMaxLength(30);

            modelBuilder.Entity<Comment>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Comment>()
                .Property(x => x.Text).HasMaxLength(10000);

            base.OnModelCreating(modelBuilder);
        }
    }
}
