using DAL.Repositories;
using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Serialize
{
    public class BINARYSerializer<T> : ISerializers<T>
    {
        private BinaryFormatter formatter;
        private string designatedFileFolder;
        public BINARYSerializer()
        {
            formatter = new BinaryFormatter();

            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            designatedFileFolder = projectDirectory + @"\SavedFiles";
        }
        public void Serialize<T>(T serializeObject, string name, bool append)
        {
            Console.WriteLine("File content: " + serializeObject.GetType());
            using(FileStream outFile = new FileStream(designatedFileFolder + @"\" + name + ".bin", FileMode.Create, FileAccess.Write))
            {
                formatter.Serialize(outFile, serializeObject);
            }
        }
        public List<T> DeserializeList(string name)
        {
            List<T> objectReturned;

            using (FileStream outFile = new FileStream(designatedFileFolder + @"\" + name + ".bin", FileMode.Open, FileAccess.Read))
            {
                objectReturned = (List<T>)formatter.Deserialize(outFile);
            }

            return objectReturned;
        }

        public T DeserializeLister(string name)
        {
            T objectReturned;

            using (FileStream outFile = new FileStream(designatedFileFolder + @"\" + name + ".bin", FileMode.Open, FileAccess.Read))
            {
                objectReturned = (T)formatter.Deserialize(outFile);
            }

            return objectReturned;
        }
    }
}
