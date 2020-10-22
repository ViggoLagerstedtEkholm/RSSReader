using Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Serialize
{
    class JSONSerializer<T> : ISerializers<T>
    {
        private JsonSerializer jsonSerializer;
        private JsonSerializerSettings settings;
        private string designatedFileFolder;
        public JSONSerializer()
        {
            jsonSerializer = new JsonSerializer();
            settings = new JsonSerializerSettings { Formatting = Newtonsoft.Json.Formatting.Indented };

            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            designatedFileFolder = projectDirectory + @"\SavedFiles";
        }

        public void Serialize<T>(T serializeObject, string name, bool append)
        {
            string jsonData = JsonConvert.SerializeObject(serializeObject, settings);

            using (StreamWriter writer = new StreamWriter(designatedFileFolder + @"\" + name + ".json"))
            {
                writer.Write(jsonData);
            }
        }
        public List<T> DeserializeList(string name)
        {
            List<T> objectReturned = new List<T>();

            using (StreamReader r = new StreamReader(designatedFileFolder + @"\" + name + ".json"))
            {
                string json = r.ReadToEnd();
                objectReturned = JsonConvert.DeserializeObject<List<T>>(json);
            }

            return objectReturned;
        }
    }
}
