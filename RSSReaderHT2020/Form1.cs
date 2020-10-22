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
            this.categoryContoller = new CategoryContoller();
            this.podcastController = new PodcastController();
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

        private void insertRows()
        {
            dataGridPodcast.Rows.Clear();

            foreach(Podcast aPodcast in podcastController.RetrieveAllPodcasts())
            {
                dataGridPodcast.Rows.Add(aPodcast.GetName(), aPodcast.GetUpdatingInterval(), 1, aPodcast.GetCategory().namn);
            }
        }

        private void btnFetch_Click(object sender, EventArgs e)
        {
        
        }

        //Podcast https://api.sr.se/api/rss/pod/3795
        private async void newPodcastBtn_Click(object sender, EventArgs e)
        {
            if (!validator.isNullorEmpty(textBoxURL))
            {
                int interval = Int32.Parse(comboBoxInterval.SelectedItem.ToString());

                //Validera!
                Podcast podcast = await podcastController.CreatePodcastObject(textBoxURL.Text, textBoxNamn.Text, interval, comboBoxCategory.SelectedItem.ToString());

                insertRows();

                foreach (Episode episode in podcast.GetEpisode())
                {
                    textBoxPodcast.Items.Add(episode.description);
                }
            }
            else
            {
                throw new ExceptionHandler("Could not find URL");
            }
        }

        private void savePodcastBtn_Click(object sender, EventArgs e)
        {
            string category = comboBoxCategory.SelectedItem.ToString();
            int interval = Int32.Parse(comboBoxInterval.SelectedItem.ToString());
            string name = textBoxNamn.Text;
            int selectedPodcast = dataGridPodcast.CurrentRow.Index;
            string selectedFolderPath = "";

            podcastController.UpdatePodcast(name, interval, new Category(category), selectedPodcast);

            using (var saveDialog = new SaveFileDialog())
            {
                DialogResult result = saveDialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                     selectedFolderPath = saveDialog.FileName;
                }
            }

            insertRows();

        }

        private void removePodcastBtn_Click(object sender, EventArgs e)
        {
            int selectedPodcast = dataGridPodcast.CurrentRow.Index;

            podcastController.DeletePodcast(selectedPodcast);

            insertRows();

        }

        //Category
        private void newCategoryBtn_Click(object sender, EventArgs e)
        {
            listBoxCategory.Items.Clear();
            Console.WriteLine("Test");
            if (!validator.isNullorEmpty(categoryTextBox))
            {
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
            string selectedFolderPath = "";
            using (var saveDialog = new SaveFileDialog())
            {
                DialogResult result = saveDialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    selectedFolderPath = saveDialog.FileName;
                }
            }
            categoryContoller.saveCategory();
        }

        private void removeCategoryBtn_Click(object sender, EventArgs e)
        {
            string selectedCategory = listBoxCategory.GetItemText(listBoxCategory.SelectedItem);
            Console.WriteLine("Category: " + selectedCategory);
            //Validering

            categoryContoller.DeleteCategory(selectedCategory, podcastController);
            comboBoxCategory.Items.Clear();
            insertRows();
            update();
        }

        private void renameBtn_Click(object sender, EventArgs e)
        {
            string selectedCategory = listBoxCategory.GetItemText(listBoxCategory.SelectedItem);
            string input = Interaction.InputBox("Prompt", "Title", "Default", 100, 100);

            categoryContoller.RenameCategory(selectedCategory, input);
            comboBoxCategory.Items.Clear();
            comboBoxCategory.SelectedIndex = comboBoxCategory.FindStringExact(input);
            insertCategories();
            update();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

            //podcastController.
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

        }
    }
}
