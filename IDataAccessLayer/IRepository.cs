using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDataAccessLayer
{
    public interface IRepository<T>
    {
        void Create(T entity);

        void Update(T entity);

        void Delete(int id);

        List<T> GetAll();

        T Get(int id);
    }
}
