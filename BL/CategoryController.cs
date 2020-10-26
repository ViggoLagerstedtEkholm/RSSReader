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
        public bool DeleteCategory(string name, PodcastController podcastController)
        {
            List<Category> list = categoryRepository.GetAll();
            bool deletedPodcast = true;

            foreach(Category aCategory in list.ToList())
            {
                if (aCategory.Namn.Equals(name))
                {
                    if (podcastController.RetrieveAllPodcasts().Count > 0)
                    {
                        foreach(Podcast podcast in podcastController.RetrieveAllPodcasts().ToList())
                        {
                            if (podcast.category.Namn.Equals(name))
                            {
                                var confirmResult = MessageBox.Show("Are you sure you want to delete all podcasts with selected category?",
                                         "Confirm Delete!!",
                                         MessageBoxButtons.YesNo);
                                if (confirmResult == DialogResult.Yes)
                                {
                                    podcastController.DeletePodcast(podcast);
                                    podcastController.SavePodcastData();
                                    categoryRepository.Delete(aCategory);
                                }
                            }
                            else
                            {
                                categoryRepository.Delete(aCategory);
                            }
                        }
                    }
                    else
                    {
                        categoryRepository.Delete(aCategory);
                    }
                }
            }
            return deletedPodcast;
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
