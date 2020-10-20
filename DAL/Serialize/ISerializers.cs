using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Serialize
{
    interface ISerializers<T>
    {
        void Serialize<T>(T serializeObject, string filePath, bool append, string fileName);
        T Deserialize(string path);
        T[] DeserializeList();
        T[] SerializeList(List<T> list);

    }
}
