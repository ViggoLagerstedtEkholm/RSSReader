using DAL.Serialize;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAL.Repositories
{
    public class PodcastRepository : Feed<Podcast>, IDataHandler<Podcast>
    {
        private readonly XMLSerializer objectSerializer;
        public PodcastRepository() : base(new List<Podcast>())
        {
            objectSerializer = new XMLSerializer();
        }
        public override void Create(Podcast entity)
        {
            base.Create(entity);
        }
        public override void Delete(Podcast entity)
        {
            base.Delete(entity);
        }
        public override void Delete(int index)
        {
            base.Delete(index);
        }
        public override List<Podcast> GetAll()
        {
            return base.GetAll();
        }
        public void Update(string URL, string newName, int interval, Category category, int index, List<Episode> episodes, int episodeAmount)
        {
            list[index].URL = URL;
            list[index].name = newName;
            list[index].category = category;
            list[index].updatingInterval = interval;
            list[index].episodes = episodes;
            list[index].amountOfEpisodes = episodeAmount;
        }
        public async Task Update(List<Podcast> podcasts, IProgress<int> progress, ListBox console)
        {
            List<List<Episode>> episodes = new List<List<Episode>>();
            List<Episode> updatedEpisodes = new List<Episode>();

            foreach (Podcast podcast in podcasts)
            {
                updatedEpisodes = await Task.Run(() => reader.GetEpisodes(podcast.URL));
                episodes.Add(updatedEpisodes);
                console.Items.Add($"{podcast.URL} downloaded: {updatedEpisodes.Count} characters long.\n");
                progress.Report(episodes.Count * 100 / podcasts.Count);

                podcast.episodes = updatedEpisodes;
                podcast.amountOfEpisodes = reader.GetAmountOfEpisodes(podcast.URL);
            }

            SaveChanges();
        }
        public override void Update(string currentCategory, string newCategory)
        {
            foreach(Podcast aPodcast in list)
            {
                if (aPodcast.category.Namn.Equals(currentCategory))
                {
                    aPodcast.category.Namn = newCategory;
                }
            }
        }
        public void SaveChanges()
        {
            objectSerializer.Serialize(list, Constants.podcast.Value);
        }
        public List<Podcast> GetAllData()
        {
            List<Podcast> test = objectSerializer.DeserializeList(Constants.podcast.Value);
            list = test.ToList();

            return test;
        }
    }
}
