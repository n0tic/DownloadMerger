using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DownloadMerger.Core;
using MetroFramework.Forms;

namespace DownloadMerger.Forms
{
    public partial class SettingsWindow : MetroForm
    {
        MainForm mainForm;

        public SettingsWindow(MainForm mf, string str = "")
        {
            mainForm = mf;
            if(str != "")
            {
                button1_Click(null, EventArgs.Empty);
            }

            InitializeComponent();
        }

        private void SettingsWindow_Load(object sender, EventArgs e)
        {
            mainForm.settings.LoadSettingsData();
            ffmpegLocationInput.Text = mainForm.settings.ffmpeg_location;
            outputLocationInput.Text = mainForm.settings.output_location;
            addPause.Checked = mainForm.settings.addPause;
            sequentialBox.Checked = mainForm.settings.sequentialDownload;
        }

        private void ffmpegFindButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "ffmpeg*";
            openFileDialog1.Filter = "Exe Files (.exe)|*.exe";
            openFileDialog1.FilterIndex = 1;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ffmpegLocationInput.Text = openFileDialog1.FileName;
            }
        }

        private void OutputLocationButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(outputLocationInput.Text))
            {
                this.folderBrowserDialog1.SelectedPath = outputLocationInput.Text;
            }

            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                outputLocationInput.Text = this.folderBrowserDialog1.SelectedPath;
            }
        }

        private void SaveSettingsButton_Click(object sender, EventArgs e)
        {
            mainForm.settings.SaveSettingsData(ffmpegLocationInput.Text, outputLocationInput.Text, sequentialBox.Checked, addPause.Checked);
            mainForm.FixFFMPEG();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void sequentialBox_CheckedChanged(object sender, EventArgs e)
        {
            if (this.sequentialBox.Checked)
            {
                sequentialBox.Text = "Sequential Download";
                label3.Text = "Sequential = Download one after another...";
            }
            else
            {
                sequentialBox.Text = " Parallel  Download";
                label3.Text = "Parallel = Download all simultaneously...";
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://ffmpeg.zeranoe.com/builds/");
        }

        private void ClearDataButton_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("This will completely reset all settings and data. \n\rSoftware will restart once reset has completed the process.", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
            {
                mainForm.settings.ResetSettings();
                BinarySave.ResetData("");

                Application.Restart();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = @AppDomain.CurrentDomain.BaseDirectory + "\\ffmpeg";
            string ffmpegPath = path + "\\ffmpeg.exe";

            if (!File.Exists(ffmpegPath))
            {
                ffmpegDownloadUnpack du = new ffmpegDownloadUnpack(mainForm, false);
                if (du.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("Setup was successfull!\n\rffmpeg is now installed and referenced.");
                    mainForm.FixFFMPEG();
                    //SettingsWindow_Load(null, EventArgs.Empty);
                }
            }
            else
                MessageBox.Show("ffmpeg is already installed. Reference it using the button to the left.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
