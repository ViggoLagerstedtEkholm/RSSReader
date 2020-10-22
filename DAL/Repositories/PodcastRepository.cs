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
    public class PodcastRepository : Feed<Podcast>, IDataHandler<Podcast>
    {
        public PodcastRepository() : base(new List<Podcast>())
        {
            objectSerializer = new JSONSerializer<Podcast>();
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
            list[index].name= newName;
            list[index].category = category;
            list[index].updatingInterval = interval;
        }

        public void SaveChanges()
        {
            objectSerializer.Serialize(list, Constants.podcast.Value, true);
        }

        public List<Podcast> GetAllData()
        {
            List<Podcast> test = objectSerializer.DeserializeList(Constants.podcast.Value);
            list = test.ToList();

            return test;
        }
    }
}
