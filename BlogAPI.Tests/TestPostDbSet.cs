using DataAccessLayer.Entities;
using System.Linq;

namespace BlogAPI.Tests
{
    class TestPostDbSet : TestDbSet<Post>
    {
        public override Post Find(params object[] keyValues)
        {
            return this.SingleOrDefault(x => x.Id == (int)keyValues.Single());
        }
    }
}
