using IDataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class BlogDbInitializer : DropCreateDatabaseIfModelChanges<BlogDbContext>
    {
        private static List<Post> _posts = new List<Post>
        {
            new Post { Text = "Text1", Title = "Title1" },
            new Post { Text = "Text2", Title = "Title2", Comments = new List<Comment>
            {
                new Comment { Text = "Comment21" },
                new Comment { Text = "Comment22" },
            }},
            new Post { Text = "Text3", Title = "Title3", Comments = new List<Comment>
            {
                new Comment { Text = "Comment31" },
                new Comment { Text = "Comment32" },
                new Comment { Text = "Comment33" },
            }},
        };

        protected override void Seed(BlogDbContext context)
        {
            base.Seed(context);
            InitializeData(context);
        }

        public static void InitializeData(BlogDbContext context)
        {
            foreach (var item in _posts)
            {
                context.Posts.Add(item);
            }

            context.SaveChanges();
        }
    }
}
