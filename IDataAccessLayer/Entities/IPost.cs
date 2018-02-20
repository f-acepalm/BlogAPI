using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.IDataAccessLayer
{
    public interface IPost
    {
        int Id { get; set; }

        string Title { get; set; }

        string Text { get; set; }

        IComment Comments { get; set; }

        string UserName { get; set; }
    }
}
