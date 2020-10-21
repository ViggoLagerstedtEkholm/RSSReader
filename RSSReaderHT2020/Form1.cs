using BL;
using DAL;
using DAL.Repositories;
using DAL.Serialize;
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
        private readonly int[] intervalNumbers = new int[] { 1, 2, 5, 10, 20, 30, 60};
        public Form1()
        {
            InitializeComponent();
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

        private void btnFetch_Click(object sender, EventArgs e)
        {
        

        }

        //Podcast 
        private void newPodcastBtn_Click(object sender, EventArgs e)
        {
            XmlReader xmlReader = XmlReader.Create("https://api.sr.se/api/rss/pod/3795");
            SyndicationFeed feed = SyndicationFeed.Load(xmlReader);
            Console.WriteLine("Title: " + feed.Title.Text);
            Console.WriteLine("Description: " + feed.Description.Text);
            dataGridPodcast.Columns.Add("1", "Test 1");
            dataGridPodcast.Columns.Add("2", "Test 2");
            dataGridPodcast.Columns.Add("3", "Test 3");
            dataGridPodcast.Rows.Add("Test", 1, 15);

            if (!Validator.isNullorEmpty(textBoxURL))
            {
                //this.podcastController = new PodcastController(textBoxURL.Text);
                //this.categoryContoller = new CategoryContoller(textBoxURL.Text);
                //Podcast podcast = new Podcast(textBoxURL, );
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
            if (!Validator.isNullorEmpty(categoryTextBox))
            {
                //Podcast podcast = new Podcast(textBoxURL, );
                categoryContoller.CreateCategoryObject(categoryTextBox.Text);

                foreach(Category cat in categoryContoller.RetrieveAllCategories())
                {
                    listBoxCategory.Items.Add(cat.namn);
                }
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
            string category = listBoxCategory.GetItemText(listBoxCategory.SelectedItem);
            Console.WriteLine("Category: " + category);
            //Validering

            categoryContoller.DeleteCategory(category);

            listBoxCategory.Items.Clear();

            foreach (Category cat in categoryContoller.RetrieveAllCategories())
            {
                listBoxCategory.Items.Add(cat.namn);
            }
        }
    }
}
