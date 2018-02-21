using DataAccessLayer;
using IDataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var postRep = new PostRepository();
            var commentRep = new CommentRopository();

            var post = new Post() { Title = "Title3", Text = "WAT???" };

            post.Comments.Add(new Comment() { Text = "WAT" });

            //postRep.Create(post);
            //postRep.Update(post);
            //postRep.Delete(3);

            var list = postRep.GetAll();
            var y = postRep.Get(2);
            var s = y.Comments.ToList();

            var comment = commentRep.Get(1);
        }
    }
}
