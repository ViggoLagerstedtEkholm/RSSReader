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

            XDocument urlDocument = new XDocument();
            urlDocument = XDocument.Load(url);
            await Task.Run(() =>
            {
                episodeList = (from x in urlDocument.Descendants("item")

                               select new Episode
                               {
                                   
                                   name = x.Element("title").Value,
                                   description = x.Element("description").Value,

                                   soundFile = x.Descendants("link").Any() ? x.Element("link").Value : x.Descendants("enclosure").Any() ? x.Element("enclosure").Attribute("url").Value : "None"
                                   

                               }).ToList();
            });
            

            return episodeList;
        }
    }
}
