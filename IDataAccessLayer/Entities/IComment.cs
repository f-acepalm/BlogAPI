using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.IDataAccessLayer
{
    public interface IComment
    {
        int PostId { get; set; }

        string Text { get; set; }

        string UserName { get; set; }
    }
}
