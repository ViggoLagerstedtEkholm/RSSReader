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
        private readonly JSONSerializer objectSerializer;
        public CategoryRepository() : base(new List<Category>())
        {
            objectSerializer = new JSONSerializer();
        }
        public override void Create(Category entity)
        {
            base.Create(entity);
        }
        public override void Delete(Category entity)
        {
            base.Delete(entity);
        }
        public override List<Category> GetAll()
        {
            return base.GetAll();
        }
        public override void Update(string currentCategory, string newCategory)
        {
            list.Where(aCategory => aCategory.Namn.ToString().Equals(currentCategory))
            .ToList()
            .ForEach(category =>
            {
                category.Namn = newCategory;
            });
        }
        public void SaveChanges()
        {
            objectSerializer.Serialize(list, Constants.category.Value);
        }
        public List<Category> GetAllData()
        {
            List<Category> test = objectSerializer.DeserializeList(Constants.category.Value);
            list = test.ToList();

            return test;
        }
    }
}
