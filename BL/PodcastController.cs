using DAL;
using DAL.Repositories;
using Model;
using System.Collections.Generic;

namespace BL
{
    public class PodcastController
    {
        private IPodcastRepository<Podcast> podcastRepository;

        public PodcastController(string url)
        {
            podcastRepository = new PodcastRepository(url);
        }

        public void CreatePodcastObject(string name, string pn, string address, string objectType)
        {
        }

        public List<Podcast> RetrieveAllPodcasts()
        {

            return null;
        }

        public void UpdatePodcastName(string name)
        {

        }


        public void DeletePodcast(string name)
        {

        }
    }
}
