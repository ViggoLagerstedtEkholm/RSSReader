using DAL.Repositories;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DAL
{
    abstract public class Feed<T> : IRepositories<T>
    {
        RSSFeedReader reader;
        public Feed(string url)
        {
            reader = new RSSFeedReader(url);
        }

        public void Create(T entity)
        {
            throw new NotImplementedException();
        }

        public virtual void Delete(T podcast) { }

        public void Delete(int index)
        {
            throw new NotImplementedException();
        }

        public List<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void Update(int index, T entity)
        {
            throw new NotImplementedException();
        }
    }
}
