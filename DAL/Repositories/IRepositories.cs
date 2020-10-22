using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public interface IRepositories<T>
    {
        void Create(T entity);
        void Delete(int index);
        void Update(string index, string entity);
        List<T> GetAll();
    }
}
