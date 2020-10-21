using Model;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class CategoryRepository : Feed<Category>
    {
        public CategoryRepository() : base(new List<Category>())
        {}
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
        public override void Update(int index, Category entity)
        {
            base.Update(index, entity);
        }
        public override void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
