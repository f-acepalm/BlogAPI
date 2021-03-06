﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models
{
    public class Post : BaseModel
    {
        public Post()
        {
            Comments = new List<Comment>();
        }

        public string Title { get; set; }

        public string Text { get; set; }

        public List<Comment> Comments { get; set; }
    }
}
