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
        public string Name { get; set; }
        public string Description { get; set; }
        public string SoundFile { get; set; }
        public Episode(string name, string description, string soundFile)
        {
            this.Name = name;
            this.Description = description;
            this.SoundFile = soundFile;
        }

        public Episode()
        {

        }
    }
}
