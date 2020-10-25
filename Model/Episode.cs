using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
    public class Episode
    {
        public string name { get; set; }
        public string description { get; set; }
        public string soundFile { get; set; }
        public Episode(string name, string description, string soundFile)
        {
            this.name = name;
            this.description = description;
            this.soundFile = soundFile;
        }

        public Episode()
        {

        }
    }
}
