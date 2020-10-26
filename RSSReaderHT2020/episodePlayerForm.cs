using DAL;
using Model;
using NAudio.Wave;
using RSSReader;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RSSReaderHT2020
{
    public partial class EpisodePlayerForm : Form
    {
        private readonly Episode selectedEpisode;
        private readonly string designatedFileFolder;
        private readonly IWavePlayer waveOutDevice = new WaveOut();
        private AudioFileReader audioFileReader;
        private bool isCreated = false;
        private readonly WebClient client = new WebClient();
        private readonly Validator validator;
        public EpisodePlayerForm(Episode episode, Validator validator)
        {
            InitializeComponent();
            this.validator = validator;
            selectedEpisode = episode;
            SetComponentStates();
            
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            designatedFileFolder = projectDirectory + @"\SavedFiles";

            DownLoadEpisode(ValidStringNameGenerator(selectedEpisode.Name));
        }

        private void SetComponentStates()
        {
            btnRetry.Enabled = false;
            linkLabelLink.Text = selectedEpisode.SoundFile;
            lblName.Text = selectedEpisode.Name;
            richTextBoxDescription.Text = selectedEpisode.Description;
        }

        private string ValidStringNameGenerator(string name)
        {
            foreach (char c in System.IO.Path.GetInvalidFileNameChars())
            {
                name = name.Replace(c, '_');
            }

            return name;
        }
        private void DownLoadEpisode(string fileName)
        {
            string filePath = designatedFileFolder + @"\" + fileName + ".mp3";
            bool fileExist = File.Exists(filePath);
            if (fileExist)
            {
                progressBar1.Value = progressBar1.Maximum;
                lblStatusText.Text = "Downloaded!";
            }
            else
            {
                lblStatusText.Text = "Not downloaded!";
                if (!selectedEpisode.SoundFile.Equals("NONE"))
                {
                    using (client)
                    {
                        client.DownloadProgressChanged += Wc_DownloadProgressChanged;
                        client.DownloadFileCompleted += Wc_DownloadFileCompleted;
                        client.DownloadFileAsync(
                            new System.Uri(selectedEpisode.SoundFile),
                            filePath
                        );
                    }
                }
                else
                {
                    Console.WriteLine("No sound file exist for object.");
                }
               
            }
        }
        void Wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            lblProgress.Text = e.ProgressPercentage + "% | " + e.BytesReceived + " bytes out of " + e.TotalBytesToReceive + " bytes retrieven.";
        }

        private void Wc_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                MessageBox.Show("The download has been cancelled");
                File.Delete(designatedFileFolder + @"\" + ValidStringNameGenerator(selectedEpisode.Name) + ".mp3");
                Console.WriteLine("File deleted.");
                btnRetry.Enabled = true;

                return;
            }

            if (e.Error != null) // We have an error! Retry a few times, then abort.
            {
                MessageBox.Show("An error ocurred while trying to download file, No sound file exists.");

                return;
            }
            lblStatusText.Text = "Downloaded!";
            MessageBox.Show("File succesfully downloaded");
        }
        private void EpisodePlayerForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            client.CancelAsync();
            waveOutDevice.Stop();

            if (isCreated)
            {
                audioFileReader.Dispose();
            }
            
            waveOutDevice.Dispose();
        }
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            client.CancelAsync();
        }
        private void BtnRetry_Click(object sender, EventArgs e)
        {
            DownLoadEpisode(ValidStringNameGenerator(selectedEpisode.Name));
            btnRetry.Enabled = false;
        }
        private void BtnStart_Click(object sender, EventArgs e)
        {
            if (progressBar1.Value == progressBar1.Maximum)
            {
                try
                {
                    audioFileReader = new AudioFileReader(designatedFileFolder + @"\" + ValidStringNameGenerator(selectedEpisode.Name) + ".mp3");

                    waveOutDevice.Init(audioFileReader);
                    waveOutDevice.Play();
                    isCreated = true;
                }
                catch (Exception)
                {
                    Console.WriteLine("Could not play sound.");
                }
            }
        }

        private void LinkLabelLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (validator.URLIsValid(selectedEpisode.SoundFile))
            {
                System.Diagnostics.Process.Start(selectedEpisode.SoundFile);
            }
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            waveOutDevice.Stop();
        }
    }
}
