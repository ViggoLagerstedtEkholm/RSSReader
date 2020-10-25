using Model;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RSSReaderHT2020
{
    public partial class episodePlayerForm : Form
    {
        private Episode selectedEpisode;
        private string designatedFileFolder;
        private IWavePlayer waveOutDevice = new WaveOut();
        private AudioFileReader audioFileReader;
        private bool isCreated = false;
        private CancellationTokenSource source;
        private WebClient client = new WebClient();
        public episodePlayerForm(Episode episode)
        {
            InitializeComponent();
            this.selectedEpisode = episode;
            btnRetry.Enabled = false;
            linkLabelLink.Text = selectedEpisode.soundFile;
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            designatedFileFolder = projectDirectory + @"\SavedFiles";
            lblName.Text = episode.name;
            richTextBoxDescription.Text = episode.description;
       
            downLoadEpisode(validStringNameGenerator(selectedEpisode.name));
        }

        private string validStringNameGenerator(string name)
        {
            foreach (char c in System.IO.Path.GetInvalidFileNameChars())
            {
                name = name.Replace(c, '_');
            }

            return name;
        }
        private void downLoadEpisode(string fileName)
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
                if (!selectedEpisode.soundFile.Equals("NONE"))
                {
                    using (client)
                    {
                        client.DownloadProgressChanged += wc_DownloadProgressChanged;
                        client.DownloadFileCompleted += wc_DownloadFileCompleted;
                        client.DownloadFileAsync(
                            // Param1 = Link of file
                            new System.Uri(selectedEpisode.soundFile),
                            // Param2 = Path to save
                            filePath,
                                source
                        );
                    }
                }
                else
                {
                    Console.WriteLine("No sound file exist for object.");
                }
               
            }
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (progressBar1.Value == progressBar1.Maximum)
            {
                try
                {
                    audioFileReader = new AudioFileReader(designatedFileFolder + @"\" + validStringNameGenerator(selectedEpisode.name) + ".mp3");

                    waveOutDevice.Init(audioFileReader);
                    waveOutDevice.Play();
                    isCreated = true;
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Could not play sound.");
                }

            }
        }
        void wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            //Console.WriteLine(e.ProgressPercentage + "% | " + e.BytesReceived + " bytes out of " + e.TotalBytesToReceive + " bytes retrieven.");
            lblProgress.Text = e.ProgressPercentage + "% | " + e.BytesReceived + " bytes out of " + e.TotalBytesToReceive + " bytes retrieven.";
        }

        private void wc_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                MessageBox.Show("The download has been cancelled");
                File.Delete(designatedFileFolder + @"\" + validStringNameGenerator(selectedEpisode.name) + ".mp3");
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
        private void btnStop_Click(object sender, EventArgs e)
        {
            waveOutDevice.Stop();
        }
        private void episodePlayerForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            client.CancelAsync();
            waveOutDevice.Stop();
            if (isCreated)
            {
                audioFileReader.Dispose();
            }
            waveOutDevice.Dispose();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            client.CancelAsync();
        }
        private void btnRetry_Click(object sender, EventArgs e)
        {
            downLoadEpisode(validStringNameGenerator(selectedEpisode.name));
            btnRetry.Enabled = false;
        }

        private void linkLabelLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(selectedEpisode.soundFile);
        }
    }
}
