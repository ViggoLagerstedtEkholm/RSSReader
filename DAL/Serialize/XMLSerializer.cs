using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace DAL.Serialize
{
    public class XMLSerializer<T> : ISerializers<T>
    {
        private string designatedFileFolder;
        public XMLSerializer()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            designatedFileFolder = projectDirectory + @"\SavedFiles";
        }

         
        public void Serialize<T>(T serializeObject, string name, bool append)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(serializeObject.GetType());
            using (FileStream outFile = new FileStream(designatedFileFolder + @"\" + name + ".xml",
                FileMode.Create, FileAccess.Write))
            {
                xmlSerializer.Serialize(outFile, serializeObject);
            }
        }

        public List<T> DeserializeList(string name)
        {
            List<T> objects;
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<T>));
            using(FileStream inFile = new FileStream(designatedFileFolder + @"\" + name + ".xml", 
                FileMode.Open, FileAccess.Read))
            {
                objects = (List<T>) xmlSerializer.Deserialize(inFile);
            }
            return objects;
        }
    }
}
