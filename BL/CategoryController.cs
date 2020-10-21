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

        public void RenameCategory(string currentNamne, string newName)
        {
            foreach (Category aCategory in categoryRepository.GetAll().ToList())
            {
                if (aCategory.namn.Equals(currentNamne))
                {
                    aCategory.namn = newName;
                }
            }
        }
        public void DeleteCategory(string name, PodcastController podcastController)
        {
            Console.WriteLine("Selected name to remove: " + name);
            List<Category> list = categoryRepository.GetAll();

            //Gå igenom varje kategori
            foreach(Category aCategory in list.ToList())
            {
                if (aCategory.namn.Equals(name))
                {
                    if (podcastController.RetrieveAllPodcasts().ToList().Count > 0)
                    {
                        foreach (Podcast podcast in podcastController.RetrieveAllPodcasts().ToList())
                        {
                            if (podcast.GetCategory().namn.Equals(name))
                            {
                                var confirmResult = MessageBox.Show("Are you sure you want to delete all podcasts with selected category?",
                                         "Confirm Delete!!",
                                         MessageBoxButtons.YesNo);
                                if (confirmResult == DialogResult.Yes)
                                {
                                    categoryRepository.Delete(aCategory);
                                    podcastController.DeletePodcast(podcast);
                                }
                            }
                        }
                    }
                    else
                    {
                        categoryRepository.Delete(aCategory);
                    }
                }
            }
        }
    }
}
