using Entities.IDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Comment : IComment
    {
        public int PostId { get; set; }

        public string Text { get; set; }

        public string UserName { get; set; }
    }
}
