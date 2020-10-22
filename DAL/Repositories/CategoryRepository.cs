using DAL.Serialize;
using Microsoft.SqlServer.Server;
using Model;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class CategoryRepository : Feed<Category>, IDataHandler<Category>
    {
        public CategoryRepository() : base(new List<Category>())
        {
            objectSerializer = new JSONSerializer<Category>();
        }
        public override void Create(Category entity)
        {
            list.Add(entity);
        }
        public override void Delete(Category entity)
        {
            base.Delete(entity);
        }
        public override void Delete(int index)
        {
            base.Delete(index);
        }
        public override List<Category> GetAll()
        {
            return base.GetAll();
        }
        public void SaveChanges()
        {
            objectSerializer.Serialize(list, "Category", true);
        }
        public List<Category> GetAllData()
        {
            List<Category> test = objectSerializer.DeserializeList("Category");
            list = test.ToList();

            return test;
        }
    }
}
