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
using System.IO;
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
            loadData();
        }
        private void loadData()
        {
            for (int i = 0; i < categoryContoller.GetAllCategoryData().Count; i++)
            {
                listBoxCategory.Items.Add(categoryContoller.GetAllCategoryData()[i].namn);
                comboBoxCategory.Items.Add(categoryContoller.GetAllCategoryData()[i].namn);
            }

            foreach (Podcast pod in podcastController.GetPodcastData())
            {
                dataGridPodcast.Rows.Add(pod.name, pod.updatingInterval, pod.amountOfEpisodes, pod.category.namn);
            }
        }
        private void createControllers()
        {
            this.categoryContoller = new CategoryContoller();
            this.podcastController = new PodcastController();
        }
        private void createInformationMessage(string message)
        {
            MessageBox.Show(message, "Some title",
            MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                dataGridPodcast.Rows.Add(aPodcast.name, aPodcast.updatingInterval, 1, aPodcast.category.namn);
            }
        }
        //Podcast https://api.sr.se/api/rss/pod/3795
        private async void newPodcastBtn_Click(object sender, EventArgs e)
        {
            if (!validator.TextBoxisNullorEmpty(textBoxURL))
            {
                if (!validator.TextBoxisNullorEmpty(textBoxNamn))
                {
                    if (validator.ComboBoxHasSelected(comboBoxInterval) && validator.ComboBoxHasSelected(comboBoxCategory))
                    {
                        int interval = Int32.Parse(comboBoxInterval.SelectedItem.ToString());

                        //Validera!
                        Podcast podcast = await podcastController.CreatePodcastObject(textBoxURL.Text, textBoxNamn.Text, interval, comboBoxCategory.SelectedItem.ToString());

                        insertRows();

                        foreach (Episode episode in podcast.episodes)
                        {
                            textBoxPodcast.Items.Add(episode.description);
                        }
                    }
                    else
                    {
                        createInformationMessage("Select interval and category.");
                    }
                }
                else
                {
                    createInformationMessage("Enter name.");
                }
            }
            else
            {
                createInformationMessage("Enter URL");
            }
        }
        private void savePodcastBtn_Click(object sender, EventArgs e)
        {
            if(validator.ComboBoxHasSelected(comboBoxCategory) && validator.ComboBoxHasSelected(comboBoxInterval))
            {
                if (!validator.TextBoxisNullorEmpty(textBoxNamn))
                {
                    if (validator.DataGridViewHasSelected(dataGridPodcast))
                    {
                        string category = comboBoxCategory.SelectedItem.ToString();
                        int interval = Int32.Parse(comboBoxInterval.SelectedItem.ToString());
                        string name = textBoxNamn.Text;
                        int selectedPodcast = dataGridPodcast.CurrentRow.Index;

                        podcastController.UpdatePodcast(name, interval, new Category(category), selectedPodcast);
                        podcastController.SavePodcastData();
                        insertRows();
                    }
                    else
                    {
                        createInformationMessage("Select a podcast.");
                    }
                }
                else
                {
                    createInformationMessage("Enter name.");
                }
            }
            else
            {
                createInformationMessage("Select interval and category.");
            }
        }
        private void removePodcastBtn_Click(object sender, EventArgs e)
        {
            if (validator.DataGridViewHasSelected(dataGridPodcast))
            {
                int selectedPodcast = dataGridPodcast.CurrentRow.Index;

                podcastController.DeletePodcast(selectedPodcast);
                podcastController.SavePodcastData();
                insertRows();
            }
            else
            {
                createInformationMessage("Select a podcast.");
            }
        }
        private void newCategoryBtn_Click(object sender, EventArgs e)
        {
            if (!validator.TextBoxisNullorEmpty(categoryTextBox))
            {
                listBoxCategory.Items.Clear();
                categoryContoller.CreateCategoryObject(categoryTextBox.Text);

                foreach(Category cat in categoryContoller.RetrieveAllCategories())
                {
                    listBoxCategory.Items.Add(cat.namn);
                }
                categoryContoller.saveCategoryData();
                insertCategories();
            }
            else
            {
                createInformationMessage("Enter a category");
            }
        }
        private void removeCategoryBtn_Click(object sender, EventArgs e)
        {
            if (validator.ListBoxHasSelected(listBoxCategory))
            {
                string selectedCategory = listBoxCategory.GetItemText(listBoxCategory.SelectedItem);

                categoryContoller.DeleteCategory(selectedCategory, podcastController);
                comboBoxCategory.Items.Clear();
                insertRows();
                update();
            }
            else
            {
                createInformationMessage("Select a category.");
            }
        }
        private void renameBtn_Click(object sender, EventArgs e)
        {
            if (validator.ListBoxHasSelected(listBoxCategory))
            {
                string selectedCategory = listBoxCategory.GetItemText(listBoxCategory.SelectedItem);
                string newCategory = Interaction.InputBox("Prompt", "Title", "Default", 100, 100);

                if (!newCategory.Equals(""))
                {
                    categoryContoller.RenameCategory(selectedCategory, newCategory);
                    podcastController.UpdatePodcast(selectedCategory, newCategory);
                    comboBoxCategory.Items.Clear();
                    comboBoxCategory.SelectedIndex = comboBoxCategory.FindStringExact(newCategory);
                    insertRows();
                    insertCategories();
                    update();
                }
                else
                {
                    createInformationMessage("Enter a valid name.");
                }
            }
            else
            {
                createInformationMessage("Select a category.");
            }
        }
    }
}
