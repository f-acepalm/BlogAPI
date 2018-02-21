using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Models
{
    public class Comment
    {
        public int Id { get; set; }

        public int PostId { get; set; }

        public string Text { get; set; }
    }
}