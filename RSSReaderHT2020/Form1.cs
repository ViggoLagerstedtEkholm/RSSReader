using BL;
using DAL;
using DAL.Repositories;
using DAL.Serialize;
using Microsoft.VisualBasic;
using Model;
using RSSReader;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        private readonly int[] intervalNumbers = new int[] { 1, 2, 3};
        private BindingSource podcastBindingSource = new BindingSource();
        private Timer timer;
        private List<List<Podcast>> lista = new List<List<Podcast>>();
        private List<Podcast> Interval1 = new List<Podcast>();
        private List<Podcast> Interval2 = new List<Podcast>();
        private List<Podcast> Interval3 = new List<Podcast>();
        private bool canBind = true;
        public Form1()
        {
            InitializeComponent();
            validator = new Validator();
            this.Size = new Size(1400, 700);
            createControllers();
            setComponentStates();
            loadData();
            createTimerData();
            //createEventBinders();
        }
        private void loadData()
        {
            for (int i = 0; i < categoryContoller.GetAllCategoryData().Count; i++)
            {
                listBoxCategory.Items.Add(categoryContoller.GetAllCategoryData()[i].namn);
                comboBoxCategory.Items.Add(categoryContoller.GetAllCategoryData()[i].namn);
            }
            LoadPodcasts();
        }
        private void LoadPodcasts()
        {
            foreach (Podcast pod in podcastController.GetPodcastData())
            {
                podcastBindingSource.Add(pod);
            }
            dataGridPodcast.DataSource = podcastBindingSource;
        }

        private void clearTimer()
        {
            lista.Clear();
            Interval1.Clear();
            Interval2.Clear();
            Interval3.Clear();
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
            insertCommandConsole("Waiting...");
        }
        private void insertCommandConsole(string text)
        {
            string time = DateTime.Now.ToString("h:mm:ss tt");
            listBoxConsole.Items.Add(time + "- " + text);
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
                //dataGridPodcast.Rows.Add(aPodcast.name, aPodcast.updatingInterval, 1, aPodcast.category.namn);
                podcastBindingSource.Add(aPodcast);
            }

            dataGridPodcast.DataSource = podcastBindingSource;
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
                        var progress = new Progress<int>();
                        var watch = Stopwatch.StartNew();
                        progress.ProgressChanged += ProgressReported;
                        await podcastController.CreatePodcastObject(textBoxURL.Text, textBoxNamn.Text, interval, comboBoxCategory.SelectedItem.ToString(), progress);
                        watch.Stop();
                        podcastController.SavePodcastData();
                        insertRows();
                        clearTimer();
                        createTimerData();
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
                        string URL = textBoxURL.Text;

                        int index = dataGridPodcast.CurrentCell.RowIndex;

                        podcastController.UpdatePodcast(URL, name, interval, new Category(category), index);
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
                insertCommandConsole("Item removed.");
                Podcast currentObject = (Podcast)dataGridPodcast.CurrentRow.DataBoundItem;
                podcastController.DeletePodcast(selectedPodcast);
                podcastController.SavePodcastData();
                podcastBindingSource.Clear();
                clearTimer();
                createTimerData();
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
                categoryContoller.saveCategoryData();
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
                    categoryContoller.saveCategoryData();
                    podcastController.SavePodcastData();
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
        private void dataGridPodcast_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxPodcast.Items.Clear();

            Podcast currentObject = (Podcast)dataGridPodcast.CurrentRow.DataBoundItem;

            foreach(Episode episode in currentObject.episodes)
            {
                textBoxPodcast.Items.Add(episode.name);
                textBoxPodcast.Items.Add(episode.description);
            }

            textBoxNamn.Text = currentObject.name;
            textBoxURL.Text = currentObject.URL;
            comboBoxInterval.SelectedItem = currentObject.updatingInterval;
            comboBoxCategory.SelectedItem = currentObject.category.namn;
        }
        private void FilterList(string findStr, BindingSource bs)
        {
            List<Podcast> podcasts = podcastController.GetPodcastData();

            List<Podcast> filteredList = podcasts.FindAll(delegate (Podcast obj)
            {
                return obj.category.namn.Contains(findStr);
            });

            bs.DataSource = filteredList;

            dataGridPodcast.DataSource = bs;
        }
        private void textBoxFilterCategory_TextChanged(object sender, EventArgs e)
        {
            string text = textBoxFilterCategory.Text;
            if (text.Equals(""))
            {
                podcastBindingSource.Clear();

                LoadPodcasts();
            }
            else
            {
                BindingSource bs = new BindingSource();
                FilterList(text, bs);
            }
        }

        private void createTimerData()
        {
            //clearTimer();
            List<Podcast> podcasts = podcastController.GetPodcastData();
            Console.WriteLine("Timer: " + podcasts.Count);
            int selectedInterval = 0;
            foreach (Podcast podcast in podcasts)
            {
                switch (podcast.updatingInterval)
                {
                    case 1:
                        Interval1.Add(podcast);
                        break;
                    case 2:
                        Interval2.Add(podcast);
                        break;
                    case 3:
                        Interval3.Add(podcast);
                        break;
                }
            }

            lista.Add(Interval1);
            lista.Add(Interval2);
            lista.Add(Interval3);

            for (int i = 0; i < lista.Count; i++)
            {
                switch (i + 1)
                {
                    case 1:
                        selectedInterval = 60000;
                        break;
                    case 2:
                        selectedInterval = 120000;
                        break;
                    case 3:
                        selectedInterval = 180000;
                        break;
                }

                timer = new Timer
                {

                    Interval = selectedInterval,
                    Enabled = true,
                    Tag = lista[i],
                };

                if (canBind)
                {
                    timer.Tick += new EventHandler(timeTracker_Tick);
                    timer.Start();
                    canBind = false;
                }
            }
        }
        private void timeTracker_Tick(object sender, EventArgs e)
        {
            Timer timer = (Timer)sender;
            List<Podcast> batch = (List<Podcast>)timer.Tag;
            batchUpdate(batch);
        }

        private async void batchUpdate(List<Podcast> batch)
        {
            var progress = new Progress<int>();
            var watch = Stopwatch.StartNew();
            progress.ProgressChanged += ProgressReported;

            if(batch.Count > 0)
            {
                try
                {
                    insertCommandConsole("Loading...");
                    await podcastController.UpdatePodcastBatch(batch, progress, listBoxConsole);
                    watch.Stop();
                    insertCommandConsole("Feed updated successfully...");
                    insertCommandConsole($"Total execution time: " + (watch.ElapsedMilliseconds));
                    insertRows();
                }
                catch(Exception e)
                {
                    listBoxConsole.Items.Add("Can't add items while updating.");
                }
            }
        }

        private void ProgressReported(object sender, int progress)
        {
            loadProgressBar.Value = progress;
        }
    }
}
