using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    //Lägg till en ny podcast feed som:
    //• Har en URL(dvs.adressen som feeden är tillgänglig via).
    //• Hör till en kategori
    //• Har ett uppdateringsintervall(dvs hur ofta applikationen ska kolla på länken för att se
    //om det publicerats några nya podcasts).
    //• Har ett antal avsnitt
    //• Har ett namn(tex.SVT-nyheter) som kan användaren skriva in.
    //• Användaren skall kunna klicka på en podcast för att sedan göra följande
    public class Podcast
    {
        private readonly string URL;
        private Category category;
        private int updatingInterval;
        private List<Episode> episodes;
        private string name;
        public Podcast(string URL, Category category,int updatingInterval, List<Episode> episodes, string name)
        {
            this.URL = URL;
            this.category = category;
            this.updatingInterval = updatingInterval;
            this.episodes = episodes;
            this.name = name;
        }
        public void setName(string name)
        {
            this.name = name;
        }
        public void setCategory(Category category)
        {
            this.category = category;
        }
        public void setEpisode(List<Episode> episodes)
        {
            this.episodes = episodes;
        }
        public string GetName()
        {
            return this.name;
        }
        public List<Episode> GetEpisode()
        {
            return this.episodes;
        }
        public Category GetCategory()
        {
            return this.category;
        }
    }
}
