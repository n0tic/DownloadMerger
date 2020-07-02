using DownloadMerger.Data;
using DownloadMerger.Forms;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using System.IO;
using DownloadMerger.Properties;
using DownloadMerger.Core;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Text.RegularExpressions;

namespace DownloadMerger
{
    public partial class MainForm : MetroForm
    {
        internal DMData data = new DMData();
        internal SettingsData settings = new SettingsData();

        internal string[] lastEditedData = new string[3];

        public MainForm()
        {
            InitializeComponent();
            this.Text = DownloadMerger.softwareName + " " + DownloadMerger.GetVersion();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            settings.LoadSettingsData();
            ApplySettings();

            DMData tmpData = BinarySave.ReadFromBinaryFile("");

            if (tmpData != null)
            {
                data = tmpData;

                #pragma warning disable IDE0059 // Unnecessary assignment of a value
                tmpData = null;
                #pragma warning restore IDE0059 // Unnecessary assignment of a value

                data.BuildCollectionHolderList(this);

                if (CollectionsHolder.Items.Count > 0)
                    CollectionsHolder.SelectedIndex = CollectionsHolder.Items.Count - 1;

                CollectionsHolder_SelectedIndexChanged(null, EventArgs.Empty);
            }

            if (CollectionsHolder.Items.Count <= 0)
            {
                MessageBox.Show("No collection was found.\n\rYou will need to create one now.\n\r\n\rInitial setup must be finished.", "Initial setup needed!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                AddSeasonMethod(false);
            }

            VerifyHelpButton.Visible = false;
            VerifyAllButton.Visible = false;
            VerifyButton.Visible = false;

            FixFFMPEG();
        }

        internal void FixFFMPEG()
        {
            string path = @AppDomain.CurrentDomain.BaseDirectory + "\\ffmpeg";
            string ffmpegPath = path + "\\ffmpeg.exe";

            if(settings.ffmpeg_location != "")
            {
                if(File.Exists(settings.ffmpeg_location))
                {
                    this.Controls.Remove(FixffmpegButton);
                    return;
                }
            }

            if (File.Exists(ffmpegPath))
            {
                settings.ffmpeg_location = ffmpegPath;
                this.Controls.Remove(FixffmpegButton);
            }
        }

        private void ApplySettings()
        {
            outputLocationInput.Text = settings.output_location;
        }

        private void AddSeasonMethod(bool allowExit = false, bool load = false)
        {
            AddCollectionWindow acw = new AddCollectionWindow(this, allowExit, load);
            if (acw.ShowDialog() == DialogResult.OK)
            {
                if (acw.collectionName != "" && !string.IsNullOrEmpty(acw.collectionName) && acw.outputFolderPath != "" && !string.IsNullOrEmpty(acw.outputFolderPath))
                {
                    data.AddCollection(CollectionsHolder.Items.Count, acw.collectionName, acw.outputFolderPath);

                    CollectionsHolder.Items.Add(acw.collectionName);
                    CollectionsHolder.SelectedIndex = CollectionsHolder.Items.Count - 1;

                    SaveData();
                }
            }
        }

        private void SaveData()
        {
            BinarySave.WriteToBinaryFile("", data);
        }

        private void AddSeasonButton_Click(object sender, EventArgs e)
        {
            AddCollectionWindow acw = new AddCollectionWindow(this, true);
            if (acw.ShowDialog() == DialogResult.OK)
            {
                if (acw.collectionName != "" && !string.IsNullOrEmpty(acw.collectionName) && acw.outputFolderPath != "" && !string.IsNullOrEmpty(acw.outputFolderPath))
                {
                    data.AddCollection(CollectionsHolder.Items.Count, acw.collectionName, acw.outputFolderPath);

                    CollectionsHolder.Items.Add(acw.collectionName);
                    CollectionsHolder.SelectedIndex = CollectionsHolder.Items.Count - 1;

                    SaveData();
                }
            }
        }

        private void CollectionsHolder_SelectedIndexChanged(object sender, EventArgs e)
        {
            CollectionData cd = data.GetCollectionData(CollectionsHolder.SelectedIndex);
            
            if (cd != null)
            {
                GridView.Rows.Clear();

                List<RowData> _rd = cd.rowData;
                
                foreach (RowData rd in _rd)
                {
                    GridView.Rows.Add(rd.number, rd.name, rd.url);
                }

                outputLocationInput.Text = cd.collectionOutputLocationPath;

                GridView.Refresh();
            }
        }

        private void AddUrls(IEnumerable<string> urls)
        {
            List<string> existedUrls = new List<string>();
            for (int i = 0; i < GridView.Rows.Count; i++)
            {
                string url = GridView.Rows[i].Cells["Url"].Value?.ToString();
                if (!string.IsNullOrEmpty(url))
                {
                    existedUrls.Add(url);
                }
            }

            foreach (string url in urls)
            {
                if (!existedUrls.Contains(url) && IsM3u8(url))
                {
                    int order = this.GridView.Rows.Count + 1;
                    bool isValidUrl = IsValidUrl(url);

                    string fileName = "";
                    
                    if (chkUseNoAsFileName.Checked)
                    {
                        fileName = order.ToString();
                    }
                    else
                    {
                        fileName = isValidUrl ? Path.GetFileNameWithoutExtension(new Uri(url).LocalPath) : (File.Exists(url) ? Path.GetFileNameWithoutExtension(url) : order.ToString());
                    }

                    this.GridView.Rows.Add(order, fileName, url);
                    data.AddRowData(order, fileName, url, CollectionsHolder.SelectedIndex);
                }
            }

            SaveData();
        }

        public static bool IsValidUrl(string url)
        {
            return !string.IsNullOrEmpty(url) && (url.StartsWith("www") || url.StartsWith("http"));
        }

        public static bool IsM3u8(string url)
        {
            return !string.IsNullOrEmpty(url) && url.ToLower().Contains("m3u8");
        }

        private void OutputLocationButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(outputLocationInput.Text))
            {
                this.folderBrowserDialog1.SelectedPath = outputLocationInput.Text;
            }

            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                if(outputLocationInput.Text != this.folderBrowserDialog1.SelectedPath)
                {
                    foreach(CollectionData cd in data.collectionData)
                    {
                        if(cd.collectionID == CollectionsHolder.SelectedIndex)
                        {
                            cd.collectionOutputLocationPath = this.folderBrowserDialog1.SelectedPath;
                            break;
                        }
                    }

                    outputLocationInput.Text = this.folderBrowserDialog1.SelectedPath;
                }
                else
                    outputLocationInput.Text = this.folderBrowserDialog1.SelectedPath;
            }
        }

        private void AboutButton_Click(object sender, EventArgs e)
        {
            AboutWindow aw = new AboutWindow();
            aw.ShowDialog();
        }

        private void GridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (CollectionsHolder.SelectedIndex != -1 || e.RowIndex != -1)
            {
                CollectionData cd = data.GetCollectionData(CollectionsHolder.SelectedIndex);

                foreach (RowData rd in cd.rowData)
                {
                    if(rd.number.ToString() == lastEditedData[0] || rd.name == lastEditedData[1] || rd.url == lastEditedData[2])
                    {
                        rd.number = Int32.Parse(GridView.Rows[e.RowIndex].Cells[0].Value.ToString());
                        rd.name = GridView.Rows[e.RowIndex].Cells[1].Value.ToString();
                        rd.url = GridView.Rows[e.RowIndex].Cells[2].Value.ToString();

                        SaveData();

                        break;
                    }
                }
            }
        }

        private void DownloadAllButton_Click(object sender, EventArgs e)
        {
            if (!File.Exists(settings.ffmpeg_location))
            {
                MessageBox.Show("ffmpeg.exe was not found at this location. Try again...");
                return;
            }

            if (!Directory.Exists(outputLocationInput.Text))
            {
                MessageBox.Show("Output location does not exist. Try again...");
                return;
            }

            string itemPath = @AppDomain.CurrentDomain.BaseDirectory + "\\Items";

            if (!Directory.Exists(itemPath))
            {
                Directory.CreateDirectory(itemPath);
            }

            if (settings.sequentialDownload)
            {
                string path = itemPath + "\\DownloadSequential.bat";

                using (StreamWriter sw = File.CreateText(path)) { }

                List<string> existedNames = new List<string>();
                List<string> existedUrls = new List<string>();

                List<string> acceptedDownloads = new List<string>();

                //MessageBox.Show("There are " + data.collectionData.Count + " collections and total of " + data.GetTotalRows().ToString() + " rows to process.");

                foreach(CollectionData cd in data.collectionData)
                {
                    foreach(RowData rd in cd.rowData)
                    {
                        string name = rd.name;
                        string url = rd.url;
                        if ((!string.IsNullOrEmpty(name) && existedNames.Contains(name)) || (!string.IsNullOrEmpty(url) && existedUrls.Contains(url)))
                        {
                            MessageBox.Show("Name and/or url can't be duplicated.");
                            return;
                        }

                        if (!string.IsNullOrEmpty(name))
                        {
                            existedNames.Add(name);
                        }

                        if (!string.IsNullOrEmpty(url))
                        {
                            existedUrls.Add(url);
                        }

                        if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(url) && (IsValidUrl(url) || File.Exists(url)))
                        {
                            if (settings.addPause)
                                acceptedDownloads.Add("Title " + name + " download... \n\"" + settings.ffmpeg_location + "\" -y -i \"" + url + "\" -acodec copy -vcodec copy -absf aac_adtstoasc \"" + cd.collectionOutputLocationPath + "\\" + name + ".mp4\"\npause");
                            else
                                acceptedDownloads.Add("Title " + name + " download... \n\"" + settings.ffmpeg_location + "\" -y -i \"" + url + "\" -acodec copy -vcodec copy -absf aac_adtstoasc \"" + cd.collectionOutputLocationPath + "\\" + name + ".mp4\"\n");
                        }

                        using (StreamWriter sw = File.AppendText(path))
                        {
                            for (int i = 0; i < acceptedDownloads.Count; i++)
                            {
                                if (i >= acceptedDownloads.Count - 1)
                                {
                                    sw.WriteLine(acceptedDownloads[i]);
                                    sw.WriteLine("pause");
                                }
                                else
                                    sw.WriteLine(acceptedDownloads[i]);
                            }
                        }

                        try
                        {
                            System.Diagnostics.Process.Start(path);
                        }
                        catch (Exception) { }
                    }
                }
            }
            else
            {
                List<string> existedNames = new List<string>();
                List<string> existedUrls = new List<string>();

                List<string> filenames = new List<string>();
                List<string> acceptedDownloads = new List<string>();

                //MessageBox.Show("There are " + data.collectionData.Count + " collections and total of " + data.GetTotalRows().ToString() + " rows to process.");

                foreach (CollectionData cd in data.collectionData)
                {
                    foreach (RowData rd in cd.rowData)
                    {
                        string name = rd.name;
                        string url = rd.url;
                        if ((!string.IsNullOrEmpty(name) && existedNames.Contains(name)) || (!string.IsNullOrEmpty(url) && existedUrls.Contains(url)))
                        {
                            MessageBox.Show("Name and/or url can't be duplicated.");
                            return;
                        }

                        if (!string.IsNullOrEmpty(name))
                        {
                            existedNames.Add(name);
                        }

                        if (!string.IsNullOrEmpty(url))
                        {
                            existedUrls.Add(url);
                        }

                        if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(url) && (IsValidUrl(url) || File.Exists(url)))
                        {
                            filenames.Add(name);
                            if (settings.addPause)
                                acceptedDownloads.Add("Title " + name + " download... \n\"" + settings.ffmpeg_location + "\" -y -i \"" + url + "\" -acodec copy -vcodec copy -absf aac_adtstoasc \"" + outputLocationInput.Text + "\\" + name + ".mp4\"\npause");
                            else
                                acceptedDownloads.Add("Title " + name + " download... \n\"" + settings.ffmpeg_location + "\" -y -i \"" + url + "\" -acodec copy -vcodec copy -absf aac_adtstoasc \"" + outputLocationInput.Text + "\\" + name + ".mp4\"");
                        }

                        for (int i = 0; i < filenames.Count; i++)
                        {
                            filenames[i] = (new Regex(@"[<>:""/\|?*]")).Replace(filenames[i], "_");

                            using (StreamWriter sw = File.CreateText(itemPath + "\\" + filenames[i] + ".bat"))
                            {
                                sw.WriteLine(acceptedDownloads[i]);
                            }
                        }

                        foreach (string names in filenames)
                        {
                            System.Diagnostics.Process.Start(itemPath + "\\" + names + ".bat");
                        }
                    }
                }
            }
        }

        private void DownloadButton_Click(object sender, EventArgs e)
        {
            if (!File.Exists(settings.ffmpeg_location))
            {
                MessageBox.Show("ffmpeg.exe was not found at this location. Try again...");
                return;
            }

            if (!Directory.Exists(outputLocationInput.Text))
            {
                MessageBox.Show("Output location does not exist. Try again...");
                return;
            }

            string itemPath = @AppDomain.CurrentDomain.BaseDirectory + "\\Items";

            if (!Directory.Exists(itemPath))
            {
                Directory.CreateDirectory(itemPath);
            }

            if (settings.sequentialDownload)
            {
                string path = itemPath + "\\DownloadSequential.bat";

                using (StreamWriter sw = File.CreateText(path)) { }

                List<string> existedNames = new List<string>();
                List<string> existedUrls = new List<string>();

                List<string> acceptedDownloads = new List<string>();

                for (int i = 0; i < GridView.Rows.Count; i++)
                {
                    string name = GridView.Rows[i].Cells["FileName"].Value?.ToString();
                    string url = GridView.Rows[i].Cells["URL"].Value?.ToString();
                    if ((!string.IsNullOrEmpty(name) && existedNames.Contains(name)) || (!string.IsNullOrEmpty(url) && existedUrls.Contains(url)))
                    {
                        MessageBox.Show("Name and/or url can't be duplicated.");
                        return;
                    }

                    if (!string.IsNullOrEmpty(name))
                    {
                        existedNames.Add(name);
                    }

                    if (!string.IsNullOrEmpty(url))
                    {
                        existedUrls.Add(url);
                    }

                    if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(url) && (IsValidUrl(url) || File.Exists(url)))
                    {
                        if (settings.addPause)
                            acceptedDownloads.Add("Title " + name + " download... \n\"" + settings.ffmpeg_location + "\" -y -i \"" + url + "\" -acodec copy -vcodec copy -absf aac_adtstoasc \"" + outputLocationInput.Text + "\\" + name + ".mp4\"\npause");
                        else
                            acceptedDownloads.Add("Title " + name + " download... \n\"" + settings.ffmpeg_location + "\" -y -i \"" + url + "\" -acodec copy -vcodec copy -absf aac_adtstoasc \"" + outputLocationInput.Text + "\\" + name + ".mp4\"");
                    }
                }

                using (StreamWriter sw = File.AppendText(path))
                {
                    for (int i = 0; i < acceptedDownloads.Count; i++)
                    {
                        if (i >= acceptedDownloads.Count - 1)
                        {
                            sw.WriteLine(acceptedDownloads[i]);
                            sw.WriteLine("pause");
                        }
                        else
                            sw.WriteLine(acceptedDownloads[i]);
                    }
                }

                try
                {
                    System.Diagnostics.Process.Start(path);
                }
                catch (Exception) { }
            }
            else
            {
                List<string> existedNames = new List<string>();
                List<string> existedUrls = new List<string>();

                List<string> filenames = new List<string>();
                List<string> acceptedDownloads = new List<string>();

                for (int i = 0; i < GridView.Rows.Count; i++)
                {
                    string name = GridView.Rows[i].Cells["FileName"].Value?.ToString();
                    string url = GridView.Rows[i].Cells["URL"].Value?.ToString();
                    if ((!string.IsNullOrEmpty(name) && existedNames.Contains(name)) || (!string.IsNullOrEmpty(url) && existedUrls.Contains(url)))
                    {
                        MessageBox.Show("Name and/or url can't be duplicated.");
                        return;
                    }

                    if (!string.IsNullOrEmpty(name))
                    {
                        existedNames.Add(name);
                    }

                    if (!string.IsNullOrEmpty(url))
                    {
                        existedUrls.Add(url);
                    }

                    if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(url) && (IsValidUrl(url) || File.Exists(url)))
                    {
                        filenames.Add(name);
                        if(settings.addPause)
                            acceptedDownloads.Add("Title " + name + " download... \n\"" + settings.ffmpeg_location + "\" -y -i \"" + url + "\" -acodec copy -vcodec copy -absf aac_adtstoasc \"" + outputLocationInput.Text + "\\" + name + ".mp4\"\npause");
                        else
                            acceptedDownloads.Add("Title " + name + " download... \n\"" + settings.ffmpeg_location + "\" -y -i \"" + url + "\" -acodec copy -vcodec copy -absf aac_adtstoasc \"" + outputLocationInput.Text + "\\" + name + ".mp4\"");
                    }
                }

                for (int i = 0; i < filenames.Count; i++)
                {
                    filenames[i] = (new Regex(@"[<>:""/\|?*]")).Replace(filenames[i], "_");

                    using (StreamWriter sw = File.CreateText(itemPath + "\\" + filenames[i] + ".bat"))
                    {
                        sw.WriteLine(acceptedDownloads[i]);
                    }
                }

                foreach (string name in filenames)
                {
                    System.Diagnostics.Process.Start(itemPath + "\\" + name + ".bat");
                }
            }
        }

        private void EditSeasonButton_Click(object sender, EventArgs e)
        {
            AddSeasonMethod(true, true);
        }

        private void GridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            lastEditedData[0] = "";
            lastEditedData[1] = "";
            lastEditedData[2] = "";

            lastEditedData[0] = GridView.Rows[e.RowIndex].Cells[0].Value.ToString();
            lastEditedData[1] = GridView.Rows[e.RowIndex].Cells[1].Value.ToString();
            lastEditedData[2] = GridView.Rows[e.RowIndex].Cells[2].Value.ToString();
        }

        private void GridView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            lastEditedData[0] = "";
            lastEditedData[1] = "";
            lastEditedData[2] = "";

            lastEditedData[0] = GridView.Rows[e.Row.Index].Cells[0].Value.ToString();
            lastEditedData[1] = GridView.Rows[e.Row.Index].Cells[1].Value.ToString();
            lastEditedData[2] = GridView.Rows[e.Row.Index].Cells[2].Value.ToString();
        }

        private void GridView_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            if (CollectionsHolder.SelectedIndex != -1 || e.Row.Index != -1)
            {
                CollectionData cd = data.GetCollectionData(CollectionsHolder.SelectedIndex);

                int deleteID = -1;
                bool delete = false;

                for(int i = 0; i < cd.rowData.Count; i++)
                {
                    if (cd.rowData[i].number.ToString() == lastEditedData[0] || cd.rowData[i].name == lastEditedData[1] || cd.rowData[i].url == lastEditedData[2])
                    {
                        deleteID = i;
                        delete = true;
                        break;
                    }
                }

                if(delete)
                {
                    cd.rowData.RemoveAt(deleteID);

                    SaveData();
                }

                CollectionsHolder_SelectedIndexChanged(null, EventArgs.Empty);
            }
        }

        private void URLButton_Click(object sender, EventArgs e)
        {
            DownloadLinksWindow dlw = new DownloadLinksWindow();
            if (dlw.ShowDialog() == DialogResult.OK)
            {
                if (dlw.Content != null)
                {
                    string[] urls = dlw.Content.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                    if (urls.Length > 0)
                    {
                        this.AddUrls(urls);
                    }
                }
            }
        }

        private void VerifyHelpButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sometimes the m3u8 file itself may change location or the m3u8's information may change making the link invalid, which in return makes the download fail. This option can then check if the file exist and offer you an option to try again. \n\r\n\rVerify Download Button\n\rThis option will check items in the currently selected collection. \n\r\n\r Verify Downloads All\n\rThis option will check all collections and go through all items.\n\r\n\rNOTE: HLS/m3u8 files does not store total filesize information so " + DownloadMerger.softwareName + " has no way of matching any filesize to a specific video. It can however check if a specific file exist and if it doesn't exist it can \"mark\" the file as failed and try again. If the file exist it will be skipped. Manually checking video is recommended.");
        }

        private void VerifyButton_Click(object sender, EventArgs e)
        {
            if (GridView.Rows.Count > 0)
            {
                List<string> filename = new List<string>();
                List<string> filePath = new List<string>();
                List<string> filePathURL = new List<string>();

                List<string> existedNames = new List<string>();
                List<string> existedUrls = new List<string>();

                for (int i = 0; i < GridView.Rows.Count; i++)
                {
                    string name = GridView.Rows[i].Cells["FileName"].Value?.ToString();
                    string url = GridView.Rows[i].Cells["URL"].Value?.ToString();
                    if ((!string.IsNullOrEmpty(name) && existedNames.Contains(name)) || (!string.IsNullOrEmpty(url) && existedUrls.Contains(url)))
                    {
                        MessageBox.Show("Name and/or url can't be duplicated.");
                        return;
                    }

                    if (!string.IsNullOrEmpty(name))
                    {
                        existedNames.Add(name);
                    }

                    if (!string.IsNullOrEmpty(url))
                    {
                        existedUrls.Add(url);
                    }

                    if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(url) && (IsValidUrl(url) || File.Exists(url)))
                    {
                        if (!File.Exists(outputLocationInput.Text + "\\" + name + ".mp4"))
                        {
                            filename.Add(name);
                            filePath.Add(outputLocationInput.Text + "\\" + name + ".mp4");
                            filePathURL.Add(url);
                        }
                    }
                }

                if (filePath.Count > 0 && filePath.Count == filePathURL.Count)
                {
                    if (MessageBox.Show("Verification process found missing videos.\n\rWould you like to download these videos now?\n\r\n\rTotal videos missing: " + filePath.Count.ToString(), "Missing videos", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        //StartDownloadOfVerifiedItems(filename, filePath, filePathURL);
                    }
                }
            }
        }

        /*
        private void StartDownloadOfVerifiedItems(List<string> filename, List<string> filePath, List<string> filePathURL)
        {
            
            string batPath = @AppDomain.CurrentDomain.BaseDirectory + "\\Items";

            if (!Directory.Exists(batPath))
            {
                Directory.CreateDirectory(batPath);
            }

            if (settings.sequentialDownload)
            {
                string path = batPath + "\\DownloadSequential.bat";

                using (StreamWriter sw = File.CreateText(path)) { }
            }
            else
            {

            }



            if (!File.Exists(settings.ffmpeg_location))
            {
                MessageBox.Show("ffmpeg.exe was not found at this location. Try again...");
                return;
            }

            if (!Directory.Exists(outputLocationInput.Text))
            {
                MessageBox.Show("Output location does not exist. Try again...");
                return;
            }

            string itemPath = @AppDomain.CurrentDomain.BaseDirectory + "\\Items";

            if (!Directory.Exists(itemPath))
            {
                Directory.CreateDirectory(itemPath);
            }

            if (settings.sequentialDownload)
            {
                string path = itemPath + "\\DownloadSequential.bat";

                using (StreamWriter sw = File.CreateText(path)) { }

                List<string> existedNames = new List<string>();
                List<string> existedUrls = new List<string>();

                List<string> acceptedDownloads = new List<string>();

                for (int i = 0; i < GridView.Rows.Count; i++)
                {
                    string name = GridView.Rows[i].Cells["FileName"].Value?.ToString();
                    string url = GridView.Rows[i].Cells["URL"].Value?.ToString();
                    if ((!string.IsNullOrEmpty(name) && existedNames.Contains(name)) || (!string.IsNullOrEmpty(url) && existedUrls.Contains(url)))
                    {
                        MessageBox.Show("Name and/or url can't be duplicated.");
                        return;
                    }

                    if (!string.IsNullOrEmpty(name))
                    {
                        existedNames.Add(name);
                    }

                    if (!string.IsNullOrEmpty(url))
                    {
                        existedUrls.Add(url);
                    }

                    if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(url) && (IsValidUrl(url) || File.Exists(url)))
                    {
                        if (settings.addPause)
                            acceptedDownloads.Add("Title " + name + " download... \n\"" + settings.ffmpeg_location + "\" -y -i \"" + url + "\" -acodec copy -vcodec copy -absf aac_adtstoasc \"" + outputLocationInput.Text + "\\" + name + ".mp4\"\npause");
                        else
                            acceptedDownloads.Add("Title " + name + " download... \n\"" + settings.ffmpeg_location + "\" -y -i \"" + url + "\" -acodec copy -vcodec copy -absf aac_adtstoasc \"" + outputLocationInput.Text + "\\" + name + ".mp4\"");
                    }
                }

                using (StreamWriter sw = File.AppendText(path))
                {
                    for (int i = 0; i < acceptedDownloads.Count; i++)
                    {
                        if (i >= acceptedDownloads.Count - 1)
                        {
                            sw.WriteLine(acceptedDownloads[i]);
                            sw.WriteLine("pause");
                        }
                        else
                            sw.WriteLine(acceptedDownloads[i]);
                    }
                }

                try
                {
                    System.Diagnostics.Process.Start(path);
                }
                catch (Exception) { }
            }
            else
            {
                List<string> existedNames = new List<string>();
                List<string> existedUrls = new List<string>();

                List<string> filenames = new List<string>();
                List<string> acceptedDownloads = new List<string>();

                for (int i = 0; i < GridView.Rows.Count; i++)
                {
                    string name = GridView.Rows[i].Cells["FileName"].Value?.ToString();
                    string url = GridView.Rows[i].Cells["URL"].Value?.ToString();
                    if ((!string.IsNullOrEmpty(name) && existedNames.Contains(name)) || (!string.IsNullOrEmpty(url) && existedUrls.Contains(url)))
                    {
                        MessageBox.Show("Name and/or url can't be duplicated.");
                        return;
                    }

                    if (!string.IsNullOrEmpty(name))
                    {
                        existedNames.Add(name);
                    }

                    if (!string.IsNullOrEmpty(url))
                    {
                        existedUrls.Add(url);
                    }

                    if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(url) && (IsValidUrl(url) || File.Exists(url)))
                    {
                        filenames.Add(name);
                        if (settings.addPause)
                            acceptedDownloads.Add("Title " + name + " download... \n\"" + settings.ffmpeg_location + "\" -y -i \"" + url + "\" -acodec copy -vcodec copy -absf aac_adtstoasc \"" + outputLocationInput.Text + "\\" + name + ".mp4\"\npause");
                        else
                            acceptedDownloads.Add("Title " + name + " download... \n\"" + settings.ffmpeg_location + "\" -y -i \"" + url + "\" -acodec copy -vcodec copy -absf aac_adtstoasc \"" + outputLocationInput.Text + "\\" + name + ".mp4\"");
                    }
                }

                for (int i = 0; i < filenames.Count; i++)
                {
                    filenames[i] = (new Regex(@"[<>:""/\|?*]")).Replace(filenames[i], "_");

                    using (StreamWriter sw = File.CreateText(itemPath + "\\" + filenames[i] + ".bat"))
                    {
                        sw.WriteLine(acceptedDownloads[i]);
                    }
                }

                foreach (string name in filenames)
                {
                    System.Diagnostics.Process.Start(itemPath + "\\" + name + ".bat");
                }
            }









            List<string> acceptedDownloads = new List<string>();

            for (int i = 0; i < filePath.Count; i++)
            {
                using (StreamWriter sw = File.CreateText(filePath[i])) { }

                if (settings.sequentialDownload)
                {
                    if (IsValidUrl(filePathURL[i]) || File.Exists(filePathURL[i]))
                    {
                        if (settings.addPause)
                            acceptedDownloads.Add("Title " + filename[i] + " download... \n\"" + settings.ffmpeg_location + "\" -y -i \"" + filePathURL[i] + "\" -acodec copy -vcodec copy -absf aac_adtstoasc \"" + outputLocationInput.Text + "\\" + filename[i] + ".mp4\"\npause");
                        else
                            acceptedDownloads.Add("Title " + filename[i] + " download... \n\"" + settings.ffmpeg_location + "\" -y -i \"" + filePathURL[i] + "\" -acodec copy -vcodec copy -absf aac_adtstoasc \"" + outputLocationInput.Text + "\\" + filename[i] + ".mp4\"");
                    }

                    using (StreamWriter sw = File.AppendText(filePath[i]))
                    {
                        for (int x = 0; x < acceptedDownloads.Count; x++)
                        {
                            if (x >= acceptedDownloads.Count - 1)
                            {
                                sw.WriteLine(acceptedDownloads[x]);
                                sw.WriteLine("pause");
                            }
                            else
                                sw.WriteLine(acceptedDownloads[x]);
                        }
                    }

                    try
                    {
                        System.Diagnostics.Process.Start(filePath[i]);
                    }
                    catch (Exception) { }
                }

            }
        }

        */
        private void SettingsButton_Click(object sender, EventArgs e)
        {
            SettingsWindow sw = new SettingsWindow(this);
            if (sw.ShowDialog() == DialogResult.OK)
            {
                ApplySettings();
            }
        }

        private void FixffmpegButton_Click(object sender, EventArgs e)
        {
            SettingsWindow sw = new SettingsWindow(this, "other");
            if (sw.ShowDialog() == DialogResult.OK)
            {
                ApplySettings();
            }
        }

        private void VerifyAllButton_Click(object sender, EventArgs e)
        {

        }
    }
}
