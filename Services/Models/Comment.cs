using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models
{
    public class Comment : BaseModel
    {
        public int PostId { get; set; }

        public string Text { get; set; }
    }
}
