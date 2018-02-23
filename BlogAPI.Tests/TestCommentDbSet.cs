using DataAccessLayer.Entities;
using System.Linq;

namespace BlogAPI.Tests
{
    class TestCommentDbSet : TestDbSet<Comment>
    {
        public override Comment Find(params object[] keyValues)
        {
            return this.SingleOrDefault(x => x.Id == (int)keyValues.Single());
        }
    }
}
