using Model;
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
    internal class XMLSerializer
    {
        private readonly string designatedFileFolder;
        public XMLSerializer()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            designatedFileFolder = projectDirectory + @"\SavedFiles";
        }

        public void Serialize(List<Podcast> serializeObject, string name)
        {
            Type type = serializeObject.GetType();
            XmlSerializer serializer = new XmlSerializer(type);
            using (FileStream outFile = new FileStream(designatedFileFolder + @"\" + name + ".xml",
                FileMode.Create, FileAccess.Write))
            {
                serializer.Serialize(outFile, serializeObject);
            }
        }
        public List<Podcast> DeserializeList(string name)
        {
            List<Podcast> objects;

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Podcast>));
            using (FileStream inFile = new FileStream(designatedFileFolder + @"\" + name + ".xml",
                FileMode.Open, FileAccess.Read))
            {
                objects = (List<Podcast>)xmlSerializer.Deserialize(inFile);
            }

            return objects;
        }
    }
}