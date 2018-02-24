using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using System.Data.Entity;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class BlogDbContext : DbContext, IBlogDbContext
    {
        public BlogDbContext() : base("DefaultConnection")
        {
            Database.SetInitializer(new BlogDbInitializer()); 
        }

        public virtual IDbSet<Post> Posts { get; set; }

        public virtual IDbSet<Comment> Comments { get; set; }

        public virtual async Task MarkAsModified<T>(T item) where T : Entity
        {
            Entry(item).State = EntityState.Modified;
            await SaveChangesAsync();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Post>()
                .HasMany(x => x.Comments)
                .WithRequired(x => x.Post)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Post>()
                .Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Post>()
                .Property(x => x.Text)
                .IsRequired()
                .HasMaxLength(1000);

            modelBuilder.Entity<Comment>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Comment>()
                .Property(x => x.Text)
                .IsRequired()
                .HasMaxLength(1000);

            base.OnModelCreating(modelBuilder);
        }
    }
}
