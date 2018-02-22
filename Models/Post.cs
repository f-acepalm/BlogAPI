using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Models
{
    public class Post
    {
        public Post()
        {
            Comments = new List<Comment>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        public List<Comment> Comments { get; set; }
    }
}