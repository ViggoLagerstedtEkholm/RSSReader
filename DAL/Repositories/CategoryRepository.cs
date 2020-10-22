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
    public class CategoryRepository : Feed<Category>
    {
        


        public CategoryRepository() : base(new List<Category>())
        {
            objectSerializer = new BINARYSerializer<Category>();
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
        //public override void Update(string t, string a)
        //{
            
        //}
        public override void SaveChanges(List<Category> categoryList)
        {
            Console.WriteLine(list.Count);
            foreach(Category cat in list)
            {
                Console.WriteLine(cat.namn);
            }
            objectSerializer.Serialize(new Category("test"), "C:\\Users\\Filip\\Desktop\\Sparade filer", true, "test");
        }
    }
}
