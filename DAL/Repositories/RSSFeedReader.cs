using DAL.Repositories;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Messaging;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace DAL
{
    public class RSSFeedReader
    {
        public int GetAmountOfEpisodes(string url)
        {
            XDocument urlDocument = new XDocument();
            int amountOfEpisodes = 0;

            try
            {
                urlDocument = XDocument.Load(url);
                var items = (from x in urlDocument.Descendants("item")
                             select new
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

            }
            catch (ExceptionHandle)
            {
                throw new ExceptionHandle("Could not get amount of episodes");
            }

            return amountOfEpisodes;
        }

        //https://www.c-sharpcorner.com/UploadFile/70dbe6/fetch-rss-feed-content-from-linq-to-xml/
        public async Task<List<Episode>> GetEpisodes(string url)
        {
            List<Episode> episodeList = new List<Episode>();
            XDocument urlDocument = new XDocument();

            try
            {
                urlDocument = XDocument.Load(url);
                await Task.Run(() =>
                {
                    episodeList = (from x in urlDocument.Descendants("item")
                                   select new Episode
                                   {
                                       Name = x.Element("title").Value,
                                       Description = x.Element("description").Value,
                                       SoundFile = x.Descendants("link").Any() ? x.Element("link").Value : x.Descendants("enclosure").Any() ? x.Element("enclosure").Attribute("url").Value : "None"
                                   }).ToList();
                });
            }
            catch (ExceptionHandle)
            {
                throw new ExceptionHandle("Could not get episodes.");
            }


            return episodeList;
        }
    }
}
