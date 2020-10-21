using DAL;
using DAL.Repositories;
using Model;
using System.Collections.Generic;

namespace BL
{
    public class PodcastController
    {
        private PodcastRepository podcastRepository;

        public PodcastController(string url)
        {
            podcastRepository = new PodcastRepository(url);
        }

        public void CreatePodcastObject(string name, string pn, string address, string objectType)
        {
            //podcastRepository.Create(new Podcast(""));
        }

        public List<Podcast> RetrieveAllPodcasts()
        {

            return null;
        }

        public void UpdatePodcastName(Podcast podcast, string name)
        {
            podcastRepository.UpdatePodcastName(6, name);

        }


        public void DeletePodcast(string name)
        {

        }
    }
}
