using DAL.Repositories;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DAL
{
    //Delegate here?
    public class RSSFeedReader
    {
        public RSSFeedReader()
        {}
        public string GetTitle(string url)
        {
            XmlReader xmlReader = XmlReader.Create(url);
            SyndicationFeed feed = SyndicationFeed.Load(xmlReader);

            return feed.Title.Text;
        }
        public string GetDescription(string url)
        {
            XmlReader xmlReader = XmlReader.Create(url);
            SyndicationFeed feed = SyndicationFeed.Load(xmlReader);

            return feed.Description.Text;
        }
        public int GetAmountOfEpisodes(string url)
        {
            XmlReader xmlReader = XmlReader.Create(url);
            SyndicationFeed feed = SyndicationFeed.Load(xmlReader);

            return 0; 
        }
        public async Task<List<Episode>> GetEpisodes(string url)
        {
            List<Episode> episodeList = new List<Episode>();

            XmlReader xmlReader = XmlReader.Create(url);
            SyndicationFeed feed = SyndicationFeed.Load(xmlReader);

            await Task.Run(() =>
            {
                foreach(SyndicationItem item in feed.Items)
                {
                    episodeList.Add(new Episode(item.Title.Text, item.Summary.Text));
                }
            });

            return episodeList;
        }
    }
}
