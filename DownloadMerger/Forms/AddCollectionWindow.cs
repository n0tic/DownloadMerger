using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DownloadMerger.Data;
using MetroFramework.Forms;

namespace DownloadMerger.Forms
{
    public partial class AddCollectionWindow : MetroForm
    {
        readonly MainForm mainForm = null;
        readonly CollectionData editData = null;
        public string collectionName = "";
        public string outputFolderPath = "";
        readonly bool allowExit = true;

        public AddCollectionWindow(MainForm mf, bool allow_exit, bool load = false)
        {
            mainForm = mf;
            InitializeComponent();

            allowExit = allow_exit;

            editData = null;

            if(load)
            {
                if (mainForm.CollectionsHolder.Items.Count > 0)
                {
                    foreach(CollectionData cd in mainForm.data.collectionData)
                    {
                        if (cd.collectionID == mainForm.CollectionsHolder.SelectedIndex)
                            editData = cd; 
                    }

                    if (editData != null)
                    {
                        collection_name_input.Text = editData.collectionName;
                        outputFolderLocationInput.Text = editData.collectionOutputLocationPath;

                        CreateCollectionButton.Text = "Edit";
                    }
                    else
                    {
                        MessageBox.Show("Some unknown error occured and the data can not be accessed. Aborting...");
                        this.Close();
                    }
                }
            }
            else
            {
                if(Directory.Exists(mainForm.settings.output_location))
                    outputFolderLocationInput.Text = mainForm.settings.output_location;
            }
        }

        private void CreateCollectionButton_Click(object sender, EventArgs e)
        {
            if (collection_name_input.Text != "" && !string.IsNullOrEmpty(collection_name_input.Text) && outputFolderLocationInput.Text != "" && !string.IsNullOrEmpty(outputFolderLocationInput.Text) && Directory.Exists(outputFolderLocationInput.Text))
            {
                if(editData != null)
                {
                    editData.collectionName = collection_name_input.Text;
                    editData.collectionOutputLocationPath = outputFolderLocationInput.Text;

                    mainForm.CollectionsHolder.Items[mainForm.CollectionsHolder.SelectedIndex] = editData.collectionName;

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    collectionName = collection_name_input.Text;
                    outputFolderPath = outputFolderLocationInput.Text;

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("You need to have a name and a valid output path. Try again.");
            }
        }

        private void OutputLocationButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(outputFolderLocationInput.Text))
            {
                this.folderBrowserDialog1.SelectedPath = outputFolderLocationInput.Text;
            }

            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                outputFolderLocationInput.Text = this.folderBrowserDialog1.SelectedPath;
            }
        }

        private void AddCollectionWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!allowExit)
            {
                if (this.DialogResult == DialogResult.OK)
                    return;

                e.Cancel = true;
            }
        }

        private void AboutButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("TIP: Adding a path in \"Output location folder\" in settings will set a default folder which is used when creating a new collection.");
        }
    }
}
