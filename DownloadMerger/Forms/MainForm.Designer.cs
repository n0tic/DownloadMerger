namespace DownloadMerger
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.GridView = new System.Windows.Forms.DataGridView();
            this.Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.URL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OutputLocationButton = new System.Windows.Forms.Button();
            this.DownloadButton = new System.Windows.Forms.Button();
            this.SettingsButton = new System.Windows.Forms.Button();
            this.urlButton = new System.Windows.Forms.Button();
            this.AddSeasonButton = new System.Windows.Forms.Button();
            this.outputLocationInput = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.CollectionsHolder = new MetroFramework.Controls.MetroComboBox();
            this.AboutButton = new System.Windows.Forms.Button();
            this.chkUseNoAsFileName = new MetroFramework.Controls.MetroCheckBox();
            this.editSeasonButton = new System.Windows.Forms.Button();
            this.DownloadAllButton = new System.Windows.Forms.Button();
            this.VerifyAllButton = new System.Windows.Forms.Button();
            this.VerifyButton = new System.Windows.Forms.Button();
            this.VerifyHelpButton = new System.Windows.Forms.Button();
            this.FixffmpegButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.GridView)).BeginInit();
            this.SuspendLayout();
            // 
            // GridView
            // 
            this.GridView.AllowUserToAddRows = false;
            this.GridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Number,
            this.FileName,
            this.URL});
            this.GridView.Location = new System.Drawing.Point(12, 92);
            this.GridView.Name = "GridView";
            this.GridView.Size = new System.Drawing.Size(776, 296);
            this.GridView.TabIndex = 2;
            this.GridView.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.GridView_CellBeginEdit);
            this.GridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridView_CellValueChanged);
            this.GridView.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.GridView_UserDeletedRow);
            this.GridView.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.GridView_UserDeletingRow);
            // 
            // Number
            // 
            this.Number.FillWeight = 50F;
            this.Number.HeaderText = "No.";
            this.Number.Name = "Number";
            this.Number.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Number.Width = 50;
            // 
            // FileName
            // 
            this.FileName.FillWeight = 230F;
            this.FileName.HeaderText = "Name";
            this.FileName.Name = "FileName";
            this.FileName.Width = 230;
            // 
            // URL
            // 
            this.URL.FillWeight = 453F;
            this.URL.HeaderText = "URL";
            this.URL.Name = "URL";
            this.URL.Width = 453;
            // 
            // OutputLocationButton
            // 
            this.OutputLocationButton.Image = global::DownloadMerger.Properties.Resources.FolderIcon;
            this.OutputLocationButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.OutputLocationButton.Location = new System.Drawing.Point(746, 392);
            this.OutputLocationButton.Name = "OutputLocationButton";
            this.OutputLocationButton.Size = new System.Drawing.Size(43, 23);
            this.OutputLocationButton.TabIndex = 7;
            this.OutputLocationButton.Text = "...";
            this.OutputLocationButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.OutputLocationButton.UseVisualStyleBackColor = true;
            this.OutputLocationButton.Click += new System.EventHandler(this.OutputLocationButton_Click);
            // 
            // DownloadButton
            // 
            this.DownloadButton.Image = global::DownloadMerger.Properties.Resources.DownloadIcon;
            this.DownloadButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DownloadButton.Location = new System.Drawing.Point(610, 421);
            this.DownloadButton.Name = "DownloadButton";
            this.DownloadButton.Size = new System.Drawing.Size(80, 23);
            this.DownloadButton.TabIndex = 5;
            this.DownloadButton.Text = "Download";
            this.DownloadButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.DownloadButton.UseVisualStyleBackColor = true;
            this.DownloadButton.Click += new System.EventHandler(this.DownloadButton_Click);
            // 
            // SettingsButton
            // 
            this.SettingsButton.Image = ((System.Drawing.Image)(resources.GetObject("SettingsButton.Image")));
            this.SettingsButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SettingsButton.Location = new System.Drawing.Point(688, 57);
            this.SettingsButton.Name = "SettingsButton";
            this.SettingsButton.Size = new System.Drawing.Size(69, 29);
            this.SettingsButton.TabIndex = 4;
            this.SettingsButton.Text = "Settings";
            this.SettingsButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.SettingsButton.UseVisualStyleBackColor = true;
            this.SettingsButton.Click += new System.EventHandler(this.SettingsButton_Click);
            // 
            // urlButton
            // 
            this.urlButton.Image = global::DownloadMerger.Properties.Resources.CloudIcon;
            this.urlButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.urlButton.Location = new System.Drawing.Point(422, 57);
            this.urlButton.Name = "urlButton";
            this.urlButton.Size = new System.Drawing.Size(104, 29);
            this.urlButton.TabIndex = 3;
            this.urlButton.Text = "Add m3u8 links";
            this.urlButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.urlButton.UseVisualStyleBackColor = true;
            this.urlButton.Click += new System.EventHandler(this.URLButton_Click);
            // 
            // AddSeasonButton
            // 
            this.AddSeasonButton.Image = global::DownloadMerger.Properties.Resources.PlusIcon;
            this.AddSeasonButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.AddSeasonButton.Location = new System.Drawing.Point(214, 57);
            this.AddSeasonButton.Name = "AddSeasonButton";
            this.AddSeasonButton.Size = new System.Drawing.Size(98, 29);
            this.AddSeasonButton.TabIndex = 1;
            this.AddSeasonButton.Text = "Add Collection";
            this.AddSeasonButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.AddSeasonButton.UseVisualStyleBackColor = true;
            this.AddSeasonButton.Click += new System.EventHandler(this.AddSeasonButton_Click);
            // 
            // outputLocationInput
            // 
            this.outputLocationInput.Location = new System.Drawing.Point(130, 394);
            this.outputLocationInput.Name = "outputLocationInput";
            this.outputLocationInput.ReadOnly = true;
            this.outputLocationInput.Size = new System.Drawing.Size(610, 20);
            this.outputLocationInput.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 397);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Output folder location:";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // CollectionsHolder
            // 
            this.CollectionsHolder.FormattingEnabled = true;
            this.CollectionsHolder.ItemHeight = 23;
            this.CollectionsHolder.Location = new System.Drawing.Point(12, 57);
            this.CollectionsHolder.Name = "CollectionsHolder";
            this.CollectionsHolder.Size = new System.Drawing.Size(196, 29);
            this.CollectionsHolder.TabIndex = 12;
            this.CollectionsHolder.SelectedIndexChanged += new System.EventHandler(this.CollectionsHolder_SelectedIndexChanged);
            // 
            // AboutButton
            // 
            this.AboutButton.Cursor = System.Windows.Forms.Cursors.Help;
            this.AboutButton.Image = global::DownloadMerger.Properties.Resources.QuestionmarkIcon;
            this.AboutButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.AboutButton.Location = new System.Drawing.Point(763, 57);
            this.AboutButton.Name = "AboutButton";
            this.AboutButton.Size = new System.Drawing.Size(25, 29);
            this.AboutButton.TabIndex = 13;
            this.AboutButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.AboutButton.UseVisualStyleBackColor = true;
            this.AboutButton.Click += new System.EventHandler(this.AboutButton_Click);
            // 
            // chkUseNoAsFileName
            // 
            this.chkUseNoAsFileName.AutoSize = true;
            this.chkUseNoAsFileName.Enabled = false;
            this.chkUseNoAsFileName.Location = new System.Drawing.Point(548, 109);
            this.chkUseNoAsFileName.Name = "chkUseNoAsFileName";
            this.chkUseNoAsFileName.Size = new System.Drawing.Size(142, 15);
            this.chkUseNoAsFileName.TabIndex = 14;
            this.chkUseNoAsFileName.Text = "Use row ID as filename";
            this.chkUseNoAsFileName.UseVisualStyleBackColor = true;
            // 
            // editSeasonButton
            // 
            this.editSeasonButton.Image = global::DownloadMerger.Properties.Resources.EditIcon;
            this.editSeasonButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.editSeasonButton.Location = new System.Drawing.Point(318, 57);
            this.editSeasonButton.Name = "editSeasonButton";
            this.editSeasonButton.Size = new System.Drawing.Size(98, 29);
            this.editSeasonButton.TabIndex = 15;
            this.editSeasonButton.Text = "Edit Collection";
            this.editSeasonButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.editSeasonButton.UseVisualStyleBackColor = true;
            this.editSeasonButton.Click += new System.EventHandler(this.EditSeasonButton_Click);
            // 
            // DownloadAllButton
            // 
            this.DownloadAllButton.Image = global::DownloadMerger.Properties.Resources.DownloadIcon;
            this.DownloadAllButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DownloadAllButton.Location = new System.Drawing.Point(696, 421);
            this.DownloadAllButton.Name = "DownloadAllButton";
            this.DownloadAllButton.Size = new System.Drawing.Size(93, 23);
            this.DownloadAllButton.TabIndex = 16;
            this.DownloadAllButton.Text = "Download All";
            this.DownloadAllButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.DownloadAllButton.UseVisualStyleBackColor = true;
            this.DownloadAllButton.Click += new System.EventHandler(this.DownloadAllButton_Click);
            // 
            // VerifyAllButton
            // 
            this.VerifyAllButton.Image = global::DownloadMerger.Properties.Resources.DownloadIcon;
            this.VerifyAllButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.VerifyAllButton.Location = new System.Drawing.Point(130, 421);
            this.VerifyAllButton.Name = "VerifyAllButton";
            this.VerifyAllButton.Size = new System.Drawing.Size(123, 23);
            this.VerifyAllButton.TabIndex = 18;
            this.VerifyAllButton.Text = "Verify Download All";
            this.VerifyAllButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.VerifyAllButton.UseVisualStyleBackColor = true;
            this.VerifyAllButton.Click += new System.EventHandler(this.VerifyAllButton_Click);
            // 
            // VerifyButton
            // 
            this.VerifyButton.Image = global::DownloadMerger.Properties.Resources.DownloadIcon;
            this.VerifyButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.VerifyButton.Location = new System.Drawing.Point(12, 421);
            this.VerifyButton.Name = "VerifyButton";
            this.VerifyButton.Size = new System.Drawing.Size(109, 23);
            this.VerifyButton.TabIndex = 17;
            this.VerifyButton.Text = "Verify Download";
            this.VerifyButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.VerifyButton.UseVisualStyleBackColor = true;
            this.VerifyButton.Click += new System.EventHandler(this.VerifyButton_Click);
            // 
            // VerifyHelpButton
            // 
            this.VerifyHelpButton.Cursor = System.Windows.Forms.Cursors.Help;
            this.VerifyHelpButton.Image = global::DownloadMerger.Properties.Resources.QuestionmarkIcon;
            this.VerifyHelpButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.VerifyHelpButton.Location = new System.Drawing.Point(259, 418);
            this.VerifyHelpButton.Name = "VerifyHelpButton";
            this.VerifyHelpButton.Size = new System.Drawing.Size(25, 29);
            this.VerifyHelpButton.TabIndex = 19;
            this.VerifyHelpButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.VerifyHelpButton.UseVisualStyleBackColor = true;
            this.VerifyHelpButton.Click += new System.EventHandler(this.VerifyHelpButton_Click);
            // 
            // FixffmpegButton
            // 
            this.FixffmpegButton.Image = global::DownloadMerger.Properties.Resources.WarningIcon;
            this.FixffmpegButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.FixffmpegButton.Location = new System.Drawing.Point(548, 57);
            this.FixffmpegButton.Name = "FixffmpegButton";
            this.FixffmpegButton.Size = new System.Drawing.Size(110, 29);
            this.FixffmpegButton.TabIndex = 20;
            this.FixffmpegButton.Text = "Install FFMPEG";
            this.FixffmpegButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.FixffmpegButton.UseVisualStyleBackColor = true;
            this.FixffmpegButton.Click += new System.EventHandler(this.FixffmpegButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = MetroFramework.Drawing.MetroBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(800, 453);
            this.Controls.Add(this.FixffmpegButton);
            this.Controls.Add(this.VerifyHelpButton);
            this.Controls.Add(this.VerifyAllButton);
            this.Controls.Add(this.VerifyButton);
            this.Controls.Add(this.DownloadAllButton);
            this.Controls.Add(this.editSeasonButton);
            this.Controls.Add(this.AboutButton);
            this.Controls.Add(this.CollectionsHolder);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.outputLocationInput);
            this.Controls.Add(this.OutputLocationButton);
            this.Controls.Add(this.DownloadButton);
            this.Controls.Add(this.SettingsButton);
            this.Controls.Add(this.urlButton);
            this.Controls.Add(this.GridView);
            this.Controls.Add(this.AddSeasonButton);
            this.Controls.Add(this.chkUseNoAsFileName);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Resizable = false;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button AddSeasonButton;
        private System.Windows.Forms.DataGridView GridView;
        private System.Windows.Forms.Button urlButton;
        private System.Windows.Forms.Button SettingsButton;
        private System.Windows.Forms.Button DownloadButton;
        private System.Windows.Forms.Button OutputLocationButton;
        private System.Windows.Forms.TextBox outputLocationInput;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button AboutButton;
        private MetroFramework.Controls.MetroCheckBox chkUseNoAsFileName;
        private System.Windows.Forms.Button editSeasonButton;
        internal MetroFramework.Controls.MetroComboBox CollectionsHolder;
        private System.Windows.Forms.Button DownloadAllButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn URL;
        private System.Windows.Forms.Button VerifyAllButton;
        private System.Windows.Forms.Button VerifyButton;
        private System.Windows.Forms.Button VerifyHelpButton;
        private System.Windows.Forms.Button FixffmpegButton;
    }
}

