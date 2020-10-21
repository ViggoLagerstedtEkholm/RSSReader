using DAL.Repositories;
using DAL.Serialize;
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
        private RSSFeedReader reader;
        private ISerializers<Podcast> objectSerializer;
        public Feed(string url)
        {
            reader = new RSSFeedReader(url);
        }
        public virtual void Create(T entity)
        {throw new NotImplementedException();}
        public virtual void Delete(T podcast) { }
        public virtual void Delete(int index){}
        public virtual List<T> GetAll()
        { throw new NotImplementedException();}
        public virtual void SaveChanges()
        {throw new NotImplementedException();}
        public virtual void Update(int index, T entity)
        {throw new NotImplementedException();}
    }
}
