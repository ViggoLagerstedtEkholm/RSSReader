using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public interface IPodcastRepository<T>
    {
        T GetByName(string name);
        int GetIndex(string name);
    }
}
