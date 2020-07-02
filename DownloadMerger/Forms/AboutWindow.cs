using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace DownloadMerger.Forms
{
    public partial class AboutWindow : MetroForm
    {
        public AboutWindow()
        {
            InitializeComponent();

            metroLabel1.Text = DownloadMerger.softwareName + " " + DownloadMerger.GetVersion();
            metroLabel3.Text = "A software created by " + DownloadMerger.authorRealName + " AKA " + DownloadMerger.authorName;
            metroLabel2.Text = "Email: " + DownloadMerger.GetContact();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show(Properties.Resources.MetroFramework);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Process.Start("https://bytevaultstudio.se/ByteVaultPortal/portfolio/downloadmerger-m3u8-ffmpeg/");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://ffmpeg.zeranoe.com/builds/");
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://iconfinder.com/");
        }

        private void AboutWindow_Load(object sender, EventArgs e)
        {
            this.FocusMe();
        }
    }
}
