using DataAccessLayer;
using IDataAccessLayer.Entities;
using Mapping;
using Services;
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
            MapperInitializer.Initialize();

            var postRep = new PostRepository();
            var commentRep = new CommentRepository();
            var postServ = new PostService(postRep);
            var post = new IServices.Entities.Post() { Title = "Test2", Text = "Test2" };

            //post.Comments.Add(new Comment() { Text = "WAT" });

            //postRep.Create(post);
            //postRep.Update(post);
            //postRep.Delete(3);

            //var list = postRep.GetAll();
            //var y = postRep.Get(2);
            //var s = y.Comments.ToList();

            //var comment = commentRep.Get(1);
            //postServ.Update(post);
            postServ.Create(post);
            var x = postServ.GetAll();
        }
    }
}
