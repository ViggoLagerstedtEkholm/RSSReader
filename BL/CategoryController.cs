using DAL;
using DAL.Repositories;
using Model;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BL
{
    public class CategoryContoller
    {
        private readonly CategoryRepository categoryRepository;
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
        public void RenameCategory(string currentNamne, string newName)
        {
            categoryRepository.Update(currentNamne, newName);
        }
        public void DeleteCategory(string name, PodcastController podcastController)
        {
            List<Category> categories = categoryRepository.GetAll();

            //Check if the podcast collection is empty, if so we should just delete all categories that match the selected category.
            if (podcastController.RetrieveAllPodcasts().Count > 0)
            {
                var confirmResult = MessageBox.Show("Are you sure you want to delete all podcasts with selected category?", "Confirm Delete.", MessageBoxButtons.YesNo);

                if (confirmResult == DialogResult.Yes)
                {
                    foreach (Podcast aPodcast in podcastController.RetrieveAllPodcasts().ToList())
                    {
                        if (aPodcast.category.Namn.Equals(name))
                        {
                            podcastController.DeletePodcast(aPodcast);
                            foreach(Category aCategory in categories.ToList())
                            {
                                if (aCategory.Namn.Equals(name))
                                {
                                    categoryRepository.Delete(aCategory);
                                }
                            }
                            podcastController.SavePodcastData();
                            categoryRepository.SaveChanges();
                        }
                    }
                }
            }
            else
            {
                //Delete all categories with specified name because there are no podcasts that can have this category.
                foreach (Category aCategory in categories)
                {
                    if (aCategory.Namn.Equals(name))
                    {
                        categoryRepository.Delete(aCategory);
                    }
                }
            }
            
        }

        public void SaveCategoryData()
        {
            categoryRepository.SaveChanges();
        }

        public List<Category> GetAllCategoryData()
        {
            return categoryRepository.GetAllData();
        }
    }
}
