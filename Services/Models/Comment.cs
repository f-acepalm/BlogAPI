using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models
{
    public class Comment : Entity
    {
        public int PostId { get; set; }

        public string Text { get; set; }
    }
}
