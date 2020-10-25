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
using System.Xml.Linq;

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
            XDocument urlDocument = new XDocument();
            int amountOfEpisodes = 0;

            urlDocument = XDocument.Load(url);
            var items = (from x in urlDocument.Descendants("item")select new 
                        { 
                            title = x.Element("title") 
                        });

            if (items != null)
            {
                foreach (var i in items)
                {
                    amountOfEpisodes++;
                }
            }
            return amountOfEpisodes;
        }

        //https://www.c-sharpcorner.com/UploadFile/70dbe6/fetch-rss-feed-content-from-linq-to-xml/
        public async Task<List<Episode>> GetEpisodes(string url, IProgress<int> progress)
        {
            List<Episode> episodeList = new List<Episode>();

            XmlReader xmlReader = XmlReader.Create(url);
            SyndicationFeed feed = SyndicationFeed.Load(xmlReader);

            await Task.Run(() =>
            {
                foreach (SyndicationItem item in feed.Items)
                {
                    episodeList.Add(new Episode(item.Title.Text, item.Summary.Text));
                }
            });

            return episodeList;
        }
    }
}
