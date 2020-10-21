using DAL;
using DAL.Repositories;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class CategoryContoller
    {
        private CategoryRepository categoryRepository;

        public CategoryContoller(string url)
        {
            categoryRepository = new CategoryRepository(url);
        }

        public void CreateCategoryObject(string name, string pn, string address, string objectType)
        {
        }
        public List<Podcast> RetrieveAllCategories()
        {
            return null;
        }
        public void UpdateCategoryName(string name)
        {

        }
        public void DeleteCategory(string name)
        {

        }
    }
}
