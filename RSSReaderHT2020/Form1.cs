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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RSSReaderHT2020
{
    public partial class Form1 : Form
    {
        private PodcastController podcastController;
        private CategoryContoller categoryContoller;
        private XMLSerializer<Podcast> serializer;
        public Form1()
        {
            InitializeComponent();
            
            serializer = new XMLSerializer<Podcast>();
        }

        private void btnFetch_Click(object sender, EventArgs e)
        {
            if (!Validator.isNullorEmpty(textBoxURL))
            {
                this.podcastController = new PodcastController(textBoxURL.Text);
                this.categoryContoller = new CategoryContoller(textBoxURL.Text);
            }
        }

        private void createFeed()
        {
            
        }
    }
}
