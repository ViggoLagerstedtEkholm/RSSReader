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
        public RSSFeedReader reader;
        //public ISerializers<T> objectSerializer;
        public List<T> list;

        public Feed(List<T> list)
        {
            reader = new RSSFeedReader();
            this.list = list;

        }
        public virtual void Create(T entity) 
        {
            list.Add(entity);
        }
        public virtual void Delete(T entity) 
        {
            list.Remove(entity);        
        }
        public virtual void Delete(int index)
        {
            list.RemoveAt(index);
        }
        public virtual List<T> GetAll() 
        {
            return list;
        }
        public abstract void SaveChanges();
        public virtual void Update(int index, T entity) 
        {
            list[index] = entity;
        }
    }
}
