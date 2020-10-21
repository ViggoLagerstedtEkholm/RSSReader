using DAL;
using DAL.Repositories;
using Model;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace BL
{
    public class PodcastController
    {
        private PodcastRepository podcastRepository;

        public PodcastController()
        {
            podcastRepository = new PodcastRepository();
        }
        public void CreatePodcastObject(string url, string name, int interval, Category category, List<Episode> episodes)
        {
            podcastRepository.Create(new Podcast(url, category, interval, episodes, name));
        }
        public List<Podcast> RetrieveAllPodcasts()
        {
            return podcastRepository.GetAll();
        }
        public void UpdatePodcastName(string newName, string currentName)
        {
            podcastRepository.Update(newName, currentName);
        }
        public void DeletePodcast(int index)
        {
            podcastRepository.Delete(index);
        }

        public void DeletePodcast(Podcast podcast)
        {
            podcastRepository.Delete(podcast);
        }
    }
}
