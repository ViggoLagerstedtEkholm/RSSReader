using Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Serialize
{
    public class JSONSerializer
    {
        private readonly JsonSerializerSettings settings;
        private readonly string designatedFileFolder;
        public JSONSerializer()
        {
            settings = new JsonSerializerSettings { Formatting = Newtonsoft.Json.Formatting.Indented };

            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            designatedFileFolder = projectDirectory + @"\SavedFiles";
        }
        public void Serialize(object serializeObject, string name)
        {
            string jsonData = JsonConvert.SerializeObject(serializeObject, settings);

            using (StreamWriter writer = new StreamWriter(designatedFileFolder + @"\" + name + ".json"))
            {
                writer.Write(jsonData);
            }

            Console.WriteLine(jsonData);
        }
        public List<Category> DeserializeList(string name)
        {
            List<Category> objectReturned = new List<Category>();

            using (StreamReader r = new StreamReader(designatedFileFolder + @"\" + name + ".json"))
            {
                string json = r.ReadToEnd();
                objectReturned = JsonConvert.DeserializeObject<List<Category>>(json);
            }

            return objectReturned;
        }
    }
}
