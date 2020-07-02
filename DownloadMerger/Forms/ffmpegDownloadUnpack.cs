using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace DownloadMerger.Forms
{
    public partial class ffmpegDownloadUnpack : MetroForm
    {
        MainForm mf;
        readonly bool allowExit = true;

        public object Webclient { get; private set; }

        public ffmpegDownloadUnpack(MainForm mainform, bool allow_exit)
        {
            mf = mainform;
            allowExit = allow_exit;

            InitializeComponent();

            StartDownload();
        }

        private void StartDownload()
        {
            string ffmpegPath = @AppDomain.CurrentDomain.BaseDirectory + "\\ffmpeg";
            if (!Directory.Exists(ffmpegPath))
                Directory.CreateDirectory(ffmpegPath);


            using (WebClient wc = new WebClient())
            {
                wc.DownloadProgressChanged += wc_DownloadProgressChanged;
                wc.DownloadFileCompleted += wc_DownloadFileCompleted;
                wc.DownloadFileAsync(new Uri("https://ffmpeg.zeranoe.com/builds/win64/static/ffmpeg-latest-win64-static.zip"), ffmpegPath + "\\ffmpeg-latest-win64-static.zip");
            }
        }

        private void wc_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            metroProgressBar1.Value = 0;

            if (e.Cancelled)
            {
                MessageBox.Show("The download has been cancelled");
                return;
            }

            if (e.Error != null) // We have an error! Retry a few times, then abort.
            {
                MessageBox.Show("An error ocurred while trying to download file");

                return;
            }

            StartUnpackingFile();
        }

        private void StartUnpackingFile()
        {
            string path = @AppDomain.CurrentDomain.BaseDirectory + "\\ffmpeg";
            string zipPath = path + "\\ffmpeg-latest-win64-static.zip";
            string ffmpegPath = path + "\\ffmpeg.exe";

            metroProgressBar1.Value = 0;
            using (ZipArchive archive = ZipFile.OpenRead(zipPath))
            {
                foreach (ZipArchiveEntry entry in archive.Entries.Where(e => e.FullName.Contains("ffmpeg.exe")))
                {
                    File.Create(ffmpegPath).Close();                    
                    entry.ExtractToFile(ffmpegPath, true);
                }
            }
            File.Delete(zipPath);

            if (File.Exists(ffmpegPath))
            {
                mf.settings.ffmpeg_location = ffmpegPath;
                mf.settings.SaveSettingsData(mf.settings.ffmpeg_location, mf.settings.output_location, mf.settings.sequentialDownload, mf.settings.addPause);
            }

            metroProgressBar1.Value = 100;

            Thread.Sleep(1000);
            DialogResult = DialogResult.OK;
            this.Close();
        }

        //MessageBox.Show((string)e.UserState + "    downloaded " + e.BytesReceived.ToString() + " of " + e.TotalBytesToReceive.ToString() + " bytes. " + e.ProgressPercentage.ToString() + " % complete...");

        private void wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            metroProgressBar1.Value = e.ProgressPercentage;
            label1.Text = e.BytesReceived.ToString() + " / " + e.TotalBytesToReceive.ToString();
            //Convert.ToInt32(e.BytesReceived / e.TotalBytesToReceive * 100)
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //MessageBox.Show("Fail :/");
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //MessageBox.Show(e.ProgressPercentage.ToString() + " percentage...");
            metroProgressBar1.Value = e.ProgressPercentage;
        }

        private void ffmpegDownloadUnpack_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!allowExit)
            {
                if (this.DialogResult == DialogResult.OK)
                    return;

                e.Cancel = true;
            }
        }
    }
}
