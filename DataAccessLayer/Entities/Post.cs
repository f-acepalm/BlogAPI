using Entities.IDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Post : IPost
    {
        public int Id { get ; set ; }

        public string Title { get; set; }

        public string Text { get; set; }

        public IComment Comments { get; set; }

        public string UserName { get; set; }
    }
}
