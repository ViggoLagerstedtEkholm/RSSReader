using DAL.Serialize;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class PodcastRepository : Feed<Podcast>
    {
        private List<Podcast> podcastList;
        public PodcastRepository(string url) : base(url)
        {
            podcastList = new List<Podcast>();
            podcastList = GetAll();
        }
        public void Create(Podcast entity)
        {
            podcastList.Add(entity);
            SaveChanges();
        }
        public override void Delete(int index)
        {
            podcastList.RemoveAt(index);
            SaveChanges();
        }
        public void UpdatePodcastName(int podcast, string name)
        {
            podcastList[podcast].setName(name);
        }
        public void UpdatePodcastCategory(int podcast, Category category)
        {
            podcastList[podcast].setCategory(category);
        }

        public List<Episode> GetEpisodes(int podcast)
        {
            return podcastList[podcast].GetEpisode();
        }
        public List<Podcast> GetAll()
        {
            return podcastList;
        }
        public void Update(int index, Podcast entity)
        {
            //Update code.
        }

        public void SaveChanges()
        {
            //Save code.
        }
        public Podcast GetByName(string name)
        {
            //Get podcast by name.
            return null;
        }

        public int GetIndex(string name)
        {
            //Get podcast by index.
            return 0;
        }
        
    }
}
