using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class CategoryRepository : Feed<Category>
    {
        private List<Category> categoryList;
        public CategoryRepository(string url) : base(url)
        {
            categoryList = new List<Category>();
            categoryList = GetAll();
        }

        public void Create(Category entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int index)
        {
            //Remove all podcast with this same category!
            //Warn the user!
            throw new NotImplementedException();
        }

        public List<Category> GetAll()
        {
            return categoryList;
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public List<Category> SortByCategory()
        {
            
            throw new NotImplementedException();
        }

        public void Update(int index, Category entity)
        {
            throw new NotImplementedException();
        }
    }
}
