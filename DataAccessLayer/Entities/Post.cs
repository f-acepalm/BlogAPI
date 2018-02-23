using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Post : Entity
    {
        public Post()
        {
            Comments = new List<Comment>();
        }

        public string Title { get; set; }

        public string Text { get; set; }

        public virtual List<Comment> Comments { get; set; }
    }
}
