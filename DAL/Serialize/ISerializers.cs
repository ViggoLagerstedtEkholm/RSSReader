using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Serialize
{
    public interface ISerializers<T>
    {
        void Serialize<T>(T serializeObject,string name, bool append);
        List<T> DeserializeList(string name);
    }
}
