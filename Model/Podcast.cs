using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
    public class Podcast
    {
        //Serialize can only see public!
        public string URL { get; set; }
        public Category category { get; set; }
        public int updatingInterval{ get; set; }
        public List<Episode> episodes{ get; set; }
        public string name { get; set; }
        public int amountOfEpisodes { get; set; }
        public Podcast(string URL, Category category,int updatingInterval, List<Episode> episodes, string name, int amountOfEpisodes)
        {
            this.URL = URL;
            this.category = category;
            this.updatingInterval = updatingInterval;
            this.episodes = episodes;
            this.name = name;
            this.amountOfEpisodes = amountOfEpisodes;
        }

        public Podcast()
        {

        }
    }
}
