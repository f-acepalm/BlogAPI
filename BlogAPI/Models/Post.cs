using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogAPI.Models
{
    public class Post
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        public Comment Comments { get; set; }

        public string UserName { get; set; }
    }
}