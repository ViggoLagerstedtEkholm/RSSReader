using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public interface IDataHandler<T>
    {
        void SaveChanges();
        List<T> GetAllData();
    }
}
