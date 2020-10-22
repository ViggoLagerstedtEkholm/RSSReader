using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Serialize
{
    public interface ISerializers<T>
    {
        void Serialize<T>(T serializeObject, string filePath, bool append, string fileName);
        T Deserialize(string path);
        T[] DeserializeList();
        void SerializeList(List<T> list, string filePath, string fileName, bool append);

    }
}
