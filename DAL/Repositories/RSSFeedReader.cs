using DAL.Repositories;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    //Delegate here?
    public class RSSFeedReader
    {
        private readonly string URL;
        public RSSFeedReader()
        {
        }

        public string GetDescription()
        {
            return "";
        }

        public int GetAmountOfEpisodes()
        {
            return 0; 
        }

        public async Task<List<Episode>> GetEpisodes()
        {
            List<Episode> episodeList = new List<Episode>();
            await Task.Run(() =>
            {
                //Get episodes from feed.

                //Use lambda expressions.

            });

            return episodeList;
        }
    }
}
