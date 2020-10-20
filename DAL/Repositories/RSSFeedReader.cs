using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class RSSFeedReader : IRequestedData
    {
        private readonly string URL;
        public RSSFeedReader(string url)
        {
            this.URL = url;
        }

        public string description()
        {
            return "";
        }

        public int episodes()
        {
            return 0; 
        }
    }
}
