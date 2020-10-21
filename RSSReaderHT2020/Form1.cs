using BL;
using DAL;
using DAL.Repositories;
using DAL.Serialize;
using Microsoft.VisualBasic;
using Model;
using RSSReader;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace RSSReaderHT2020
{
    public partial class Form1 : Form
    {
        private PodcastController podcastController;
        private CategoryContoller categoryContoller;
        private Validator validator;
        private readonly int[] intervalNumbers = new int[] { 1, 2, 5, 10, 20, 30, 60};
        public Form1()
        {
            InitializeComponent();
            validator = new Validator();
            createControllers();
            setComponentStates();
        }

        private void createControllers()
        {
            this.podcastController = new PodcastController();
            this.categoryContoller = new CategoryContoller();
        }

        private void setComponentStates()
        {
            for(int i = 0; i < intervalNumbers.Length; i++)
            {
                comboBoxInterval.Items.Add(intervalNumbers[i]);
            }
        }

        private void update()
        {
            listBoxCategory.Items.Clear();
            
            foreach (Category cat in categoryContoller.RetrieveAllCategories())
            {
                listBoxCategory.Items.Add(cat.namn);
            }

            insertCategories();
        }

        private void insertCategories()
        {
            comboBoxCategory.Items.Clear();

            for (int i = 0; i < listBoxCategory.Items.Count; i++)
            {
                comboBoxCategory.Items.Add(listBoxCategory.Items[i]);
                Console.WriteLine("item:: " + listBoxCategory.Items[i]);
            }
        }

        private void btnFetch_Click(object sender, EventArgs e)
        {
        

        }

        //Podcast 
        private void newPodcastBtn_Click(object sender, EventArgs e)
        {
            if (!validator.isNullorEmpty(textBoxURL))
            {
                podcastController.CreatePodcastObject(textBoxURL.Text, "test", 1, null, null);
            }
            else
            {
                throw new ExceptionHandler("Could not find URL");
            }
        }

        private void savePodcastBtn_Click(object sender, EventArgs e)
        {

        }

        private void removePodcastBtn_Click(object sender, EventArgs e)
        {

        }

        //Category
        private void newCategoryBtn_Click(object sender, EventArgs e)
        {
            listBoxCategory.Items.Clear();
            Console.WriteLine("Test");
            if (!validator.isNullorEmpty(categoryTextBox))
            {
                //Podcast podcast = new Podcast(textBoxURL, );
                categoryContoller.CreateCategoryObject(categoryTextBox.Text);

                foreach(Category cat in categoryContoller.RetrieveAllCategories())
                {
                    listBoxCategory.Items.Add(cat.namn);
                }

                insertCategories();
            }
            else
            {
                throw new ExceptionHandler("Could not add category, enter a name!");
            }
        }

        private void saveCategoryBtn_Click(object sender, EventArgs e)
        {

        }

        private void removeCategoryBtn_Click(object sender, EventArgs e)
        {
            string selectedCategory = listBoxCategory.GetItemText(listBoxCategory.SelectedItem);
            Console.WriteLine("Category: " + selectedCategory);
            //Validering

            categoryContoller.DeleteCategory(selectedCategory, podcastController);

            update();
        }

        private void renameBtn_Click(object sender, EventArgs e)
        {
            string selectedCategory = listBoxCategory.GetItemText(listBoxCategory.SelectedItem);
            string input = Interaction.InputBox("Prompt", "Title", "Default", 100, 100);

            categoryContoller.RenameCategory(selectedCategory, input);


            update();
        }
    }
}
