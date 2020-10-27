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
            bool shouldUpdate = false;
            var confirmResult = DialogResult.None;

            //Check if the podcast collection is empty, if so we should just delete all categories that match the selected category.
            if (podcastController.RetrieveAllPodcasts().Count > 0)
            {
                //For every category that matches the category name do...
                list.ToList().Where(aCategory => aCategory.Namn.ToString().Equals(name))
                .ToList()
                .ForEach(aCategory =>
                {
                    //For every podcast that matches the category do...
                    podcastController.RetrieveAllPodcasts().ToList().ToList().Where(podcast => podcast.category.Namn.ToString().Equals(name))
                    .ToList()
                    .ForEach(podcast =>
                    {
                        confirmResult = MessageBox.Show("Are you sure you want to delete all podcasts with selected category?",
                        "Confirm Delete!!",
                        MessageBoxButtons.YesNo);

                        if (confirmResult == DialogResult.Yes)
                        {
                            podcastController.DeletePodcast(podcast);
                            podcastController.SavePodcastData();
                            categoryRepository.Delete(aCategory);
                            shouldUpdate = true;
                        }
                    });

                    //For every podcast that doesnt match the category do...
                    podcastController.RetrieveAllPodcasts().ToList().ToList().Where(podcast => !podcast.category.Namn.ToString().Equals(name))
                    .ToList()
                    .ForEach(podcast =>
                    {
                        //Don't delete the category if the user pressed no.
                        if (confirmResult == DialogResult.Yes)
                        {
                            shouldUpdate = true;
                            categoryRepository.Delete(aCategory);
                        }
                    });
                });
            }
            else
            {
                //Delete all categories with specified name because there are no podcasts that can have this category.
                list.ToList().Where(aCategory => aCategory.Namn.ToString().Equals(name))
                .ToList()
                .ForEach(aCategory =>
                {
                    shouldUpdate = true;
                    categoryRepository.Delete(aCategory);
                });
            }

            return shouldUpdate;
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
