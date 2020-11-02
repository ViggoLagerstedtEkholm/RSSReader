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
    public partial class MainWindow : Form
    {
        private PodcastController podcastController;
        private CategoryContoller categoryContoller;
        private readonly Validator validator;
        private readonly int[] intervalNumbers = new int[] { 1, 2, 3};
        private readonly BindingSource podcastBindingSource = new BindingSource();
        private readonly BindingSource episodeBindingSource = new BindingSource();
        private Timer timer;
        private readonly List<List<Podcast>> lista = new List<List<Podcast>>();
        private readonly List<Podcast> Interval1 = new List<Podcast>();
        private readonly List<Podcast> Interval2 = new List<Podcast>();
        private readonly List<Podcast> Interval3 = new List<Podcast>();
        private bool canBind = true;
        public MainWindow()
        {
            InitializeComponent();
            validator = new Validator();
            this.Size = new Size(1400, 700);
            CreateControllers();
            SetComponentStates();
            LoadData();
            CreateTimerData();
        }
        private void LoadData()
        {
            for (int i = 0; i < categoryContoller.GetAllCategoryData().Count; i++)
            {
                listBoxCategory.Items.Add(categoryContoller.GetAllCategoryData()[i].Namn);
                comboBoxCategory.Items.Add(categoryContoller.GetAllCategoryData()[i].Namn);
            }
            LoadPodcasts();
        }
        private void LoadPodcasts()
        {
            podcastController.GetPodcastData().ForEach(pod =>
            {
                podcastBindingSource.Add(pod);
            });

            dataGridPodcast.DataSource = podcastBindingSource;
        }

        private void ClearTimer()
        {
            lista.Clear();
            Interval1.Clear();
            Interval2.Clear();
            Interval3.Clear();
        }
        private void CreateControllers()
        {
            this.categoryContoller = new CategoryContoller();
            this.podcastController = new PodcastController();
        }
        private void CreateInformationMessage(string message)
        {
            MessageBox.Show(message, "Some title",
            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void SetComponentStates()
        {
            for(int i = 0; i < intervalNumbers.Length; i++)
            {
                comboBoxInterval.Items.Add(intervalNumbers[i]);
            }
            InsertCommandConsole("Waiting...");
        }
        private void InsertCommandConsole(string text)
        {
            string time = DateTime.Now.ToString("h:mm:ss tt");
            listBoxConsole.Items.Add(time + "- " + text);
        }
        private void InsertCategories()
        {
            comboBoxCategory.Items.Clear();

            for (int i = 0; i < listBoxCategory.Items.Count; i++)
            {
                comboBoxCategory.Items.Add(listBoxCategory.Items[i]);
            }
        }
        private void InsertPodcasts()
        {
            dataGridPodcast.Rows.Clear();

            podcastController.RetrieveAllPodcasts().ForEach(aPodcast =>
            {
                podcastBindingSource.Add(aPodcast);
            });

            dataGridPodcast.DataSource = podcastBindingSource;
        }

        private void UpdateCategoryList()
        {
            listBoxCategory.Items.Clear();

            categoryContoller.RetrieveAllCategories().ForEach(cat =>
            {
                listBoxCategory.Items.Add(cat.Namn);
            });

            InsertCategories();
        }
        
        private async void NewPodcastBtn_Click(object sender, EventArgs e)
        {
            if (!validator.TextBoxisNullorEmpty(textBoxURL) && validator.URLIsValid(textBoxURL.Text))
            {
                if (!validator.TextBoxisNullorEmpty(textBoxNamn))
                {
                    if (validator.ComboBoxHasSelected(comboBoxInterval) && validator.ComboBoxHasSelected(comboBoxCategory))
                    {
                        InsertCommandConsole("Adding item...");

                        int interval = Int32.Parse(comboBoxInterval.SelectedItem.ToString());
                        string category = comboBoxCategory.SelectedItem.ToString();
                        string name = textBoxNamn.Text;
                        string URL = textBoxURL.Text;

                        await podcastController.CreatePodcastObject(URL, name, interval, category);
                        
                        podcastController.SavePodcastData();
                        ClearTimer();
                        CreateTimerData();
                        InsertPodcasts();

                        InsertCommandConsole("Item added.");
                    }
                    else
                    {
                        CreateInformationMessage("Select interval and category.");
                    }
                }
                else
                {
                    CreateInformationMessage("Enter name.");
                }
            }
            else
            {
                CreateInformationMessage("Enter a valid URL.");
            }
        }

        private async void SavePodcastBtn_Click(object sender, EventArgs e)
        {
            if (!validator.TextBoxisNullorEmpty(textBoxURL) && validator.URLIsValid(textBoxURL.Text))
            {
                if (validator.ComboBoxHasSelected(comboBoxCategory) && validator.ComboBoxHasSelected(comboBoxInterval))
                {
                    if (!validator.TextBoxisNullorEmpty(textBoxNamn))
                    {
                        if (validator.DataGridViewHasSelected(dataGridPodcast))
                        {
                            InsertCommandConsole("Starting save...");

                            string category = comboBoxCategory.SelectedItem.ToString();
                            int interval = Int32.Parse(comboBoxInterval.SelectedItem.ToString());
                            string name = textBoxNamn.Text;
                            string URL = textBoxURL.Text;
                            int index = dataGridPodcast.CurrentCell.RowIndex;

                            await podcastController.UpdatePodcast(URL, name, interval, new Category(category), index);

                            podcastController.SavePodcastData();
                            InsertPodcasts();
                            ClearTimer();
                            CreateTimerData();

                            InsertCommandConsole("Item saved.");
                        }
                        else
                        {
                            CreateInformationMessage("Select a podcast.");
                        }

                    }
                    else
                    {
                        CreateInformationMessage("Enter name.");
                    }
                }
                else
                {
                    CreateInformationMessage("Select interval and category.");
                }
            }
            else
            {
                CreateInformationMessage("Enter valid URL.");
            }
        }
        private void RemovePodcastBtn_Click(object sender, EventArgs e)
        {
            if (validator.DataGridViewHasSelected(dataGridPodcast))
            {
                for (int index = 0; index < dataGridPodcast.SelectedRows.Count; index++)
                {
                    var selectedRow = dataGridPodcast.SelectedRows[index];
                    var podcast = (Podcast)selectedRow.DataBoundItem;

                    podcastController.DeletePodcast(podcast);
                }

                podcastController.SavePodcastData();
                ClearTimer();
                CreateTimerData();
                InsertPodcasts();

                InsertCommandConsole("Item removed.");
            }
            else
            {
                CreateInformationMessage("Select a podcast.");
            }
        }
        private void NewCategoryBtn_Click(object sender, EventArgs e)
        {
            if (!validator.TextBoxisNullorEmpty(categoryTextBox))
            {
                listBoxCategory.Items.Clear();
                categoryContoller.CreateCategoryObject(categoryTextBox.Text);

                categoryContoller.RetrieveAllCategories().ForEach(cat =>
                {
                    listBoxCategory.Items.Add(cat.Namn);
                });

                categoryContoller.SaveCategoryData();
                InsertCategories();

                InsertCommandConsole("Category added.");
            }
            else
            {
                CreateInformationMessage("Enter a category");
            }
        }
        private void RemoveCategoryBtn_Click(object sender, EventArgs e)
        {
            if (validator.ListBoxHasSelected(listBoxCategory))
            {
                string selectedCategory = listBoxCategory.GetItemText(listBoxCategory.SelectedItem);

                bool shouldUpdate = categoryContoller.DeleteCategory(selectedCategory, podcastController);
                comboBoxCategory.Items.Clear();
                categoryContoller.SaveCategoryData();
                if (shouldUpdate)
                {
                    InsertCommandConsole("Category removed.");

                    ClearTimer();
                    CreateTimerData();
                }
                InsertPodcasts();
                UpdateCategoryList();
            }
            else
            {
                CreateInformationMessage("Select a category.");
            }
        }
        private void RenameBtn_Click(object sender, EventArgs e)
        {
            if (validator.ListBoxHasSelected(listBoxCategory))
            {
                string selectedCategory = listBoxCategory.GetItemText(listBoxCategory.SelectedItem);
                string newCategory = Interaction.InputBox("Prompt", "Title", "Default", 100, 100);

                if (!validator.StringIsEmpty(newCategory))
                {
                    categoryContoller.RenameCategory(selectedCategory, newCategory);
                    podcastController.UpdatePodcast(selectedCategory, newCategory);

                    comboBoxCategory.Items.Clear();
                    comboBoxCategory.SelectedIndex = comboBoxCategory.FindStringExact(newCategory);

                    categoryContoller.SaveCategoryData();
                    podcastController.SavePodcastData();

                    InsertPodcasts();
                    InsertCategories();
                    UpdateCategoryList();

                    InsertCommandConsole("Category renamed.");
                }
                else
                {
                    CreateInformationMessage("Enter a valid name.");
                }
            }
            else
            {
                CreateInformationMessage("Select a category.");
            }
        }
        private void FilterList(string findStr, BindingSource bs)
        {
            List<Podcast> podcasts = podcastController.GetPodcastData();

            List<Podcast> filteredList = podcasts.FindAll(delegate (Podcast obj)
            {
                return obj.category.Namn.Contains(findStr);
            });

            bs.DataSource = filteredList;

            dataGridPodcast.DataSource = bs;
        }
        private void TextBoxFilterCategory_TextChanged(object sender, EventArgs e)
        {
            string text = textBoxFilterCategory.Text;
            if (validator.StringIsEmpty(text))
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

        private void CreateTimerData()
        {
            List<Podcast> podcasts = podcastController.GetPodcastData();
            int selectedInterval = 0;

            podcasts.ForEach(podcast =>
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
            });

            lista.Add(Interval1);
            lista.Add(Interval2);
            lista.Add(Interval3);

            for (int i = 0; i < lista.Count; i++)
            {
                switch (i + 1)
                {
                    case 1:
                        selectedInterval = 20000;
                        break;
                    case 2:
                        selectedInterval = 60000;
                        break;
                    case 3:
                        selectedInterval = 120000;
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
                    timer.Tick += new EventHandler(TimeTracker_Tick);
                    timer.Start();
                }
            }

            canBind = false;
        }
        private void TimeTracker_Tick(object sender, EventArgs e)
        {
            Timer timer = (Timer)sender;
            List<Podcast> batch = (List<Podcast>)timer.Tag;

            BatchUpdate(batch);
        }

        private async void BatchUpdate(List<Podcast> batch)
        {
            var progress = new Progress<int>();
            var watch = Stopwatch.StartNew();
            progress.ProgressChanged += ProgressReported;

            if(batch.Count > 0)
            {
                try
                {
                    InsertCommandConsole("Loading...");
                    await podcastController.UpdatePodcastBatch(batch.ToList(), progress, listBoxConsole);
                    watch.Stop();
                    InsertCommandConsole("Feed updated successfully...");
                    InsertCommandConsole($"Total execution time (ms): " + (watch.ElapsedMilliseconds));
                    if (validator.TextBoxisNullorEmpty(textBoxFilterCategory))
                    {
                        InsertPodcasts();
                    }
                }
                catch (ExceptionHandle)
                {
                    listBoxConsole.Items.Add("Error, don't add items while its loading.");
                    listBoxConsole.Items.Add("Make sure to be connected to the internet.");
                }
            }
        }
        private void ProgressReported(object sender, int progress)
        {
            loadProgressBar.Value = progress;        
        }

        private void DataGridViewEpisode_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Episode currentObject = (Episode)dataGridViewEpisode.CurrentRow.DataBoundItem;
            Form form = new EpisodePlayerForm(currentObject, validator);
            form.Show();

        }

        private void DataGridPodcast_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            episodeBindingSource.Clear();

            Podcast currentObject = (Podcast)dataGridPodcast.CurrentRow.DataBoundItem;

            currentObject.episodes.ForEach(episode =>
            {
                episodeBindingSource.Add(episode);
            });

            dataGridViewEpisode.DataSource = episodeBindingSource;

            textBoxNamn.Text = currentObject.name;
            textBoxURL.Text = currentObject.URL;
            comboBoxInterval.SelectedItem = currentObject.updatingInterval;
            comboBoxCategory.SelectedItem = currentObject.category.Namn;
        }
    }
}
