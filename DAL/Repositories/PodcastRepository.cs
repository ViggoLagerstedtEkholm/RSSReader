using DAL.Serialize;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class PodcastRepository : Feed<Podcast>
    {
        public PodcastRepository() : base(new List<Podcast>())
        {
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
        public override void Update(string newName, int interval, Category category, int index)
        {
            list[index].setName(newName);
            list[index].setCategory(category);
            list[index].SetupdatingInterval(interval);
        }

        public override void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
