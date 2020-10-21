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

        public CategoryContoller()
        {
            categoryRepository = new CategoryRepository();
        }

        public void CreateCategoryObject(string name)
        {
            categoryRepository.Create(new Category(name));
        }
        public List<Category> RetrieveAllCategories()
        {
            return categoryRepository.GetAll();
        }
        public void UpdateCategoryName(string name)
        {
            //categoryRepository.Update(name);
        }
        public void DeleteCategory(string name)
        {
            Console.WriteLine("Selected name to remove: " + name);
            List<Category> list = categoryRepository.GetAll();

            foreach(Category aCategory in list.ToList())
            {
                if (aCategory.namn.Equals(name))
                {
                    categoryRepository.Delete(aCategory);
                }
            }

        }
    }
}
