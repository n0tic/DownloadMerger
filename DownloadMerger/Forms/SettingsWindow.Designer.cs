namespace DownloadMerger.Forms
{
    partial class SettingsWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsWindow));
            this.label2 = new System.Windows.Forms.Label();
            this.outputLocationInput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ffmpegLocationInput = new System.Windows.Forms.TextBox();
            this.OutputLocationButton = new System.Windows.Forms.Button();
            this.ffmpegFindButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.sequentialBox = new System.Windows.Forms.CheckBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.SaveSettingsButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.label4 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.ClearDataButton = new System.Windows.Forms.Button();
            this.addPause = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Default output folder:";
            // 
            // outputLocationInput
            // 
            this.outputLocationInput.Location = new System.Drawing.Point(129, 102);
            this.outputLocationInput.Name = "outputLocationInput";
            this.outputLocationInput.ReadOnly = true;
            this.outputLocationInput.Size = new System.Drawing.Size(468, 20);
            this.outputLocationInput.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "FFMPEG.exe location:";
            // 
            // ffmpegLocationInput
            // 
            this.ffmpegLocationInput.Location = new System.Drawing.Point(129, 63);
            this.ffmpegLocationInput.Name = "ffmpegLocationInput";
            this.ffmpegLocationInput.ReadOnly = true;
            this.ffmpegLocationInput.Size = new System.Drawing.Size(419, 20);
            this.ffmpegLocationInput.TabIndex = 14;
            // 
            // OutputLocationButton
            // 
            this.OutputLocationButton.Image = global::DownloadMerger.Properties.Resources.FolderIcon;
            this.OutputLocationButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.OutputLocationButton.Location = new System.Drawing.Point(603, 100);
            this.OutputLocationButton.Name = "OutputLocationButton";
            this.OutputLocationButton.Size = new System.Drawing.Size(43, 23);
            this.OutputLocationButton.TabIndex = 13;
            this.OutputLocationButton.Text = "...";
            this.OutputLocationButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.OutputLocationButton.UseVisualStyleBackColor = true;
            this.OutputLocationButton.Click += new System.EventHandler(this.OutputLocationButton_Click);
            // 
            // ffmpegFindButton
            // 
            this.ffmpegFindButton.Image = global::DownloadMerger.Properties.Resources.ExeFileIcon;
            this.ffmpegFindButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ffmpegFindButton.Location = new System.Drawing.Point(554, 61);
            this.ffmpegFindButton.Name = "ffmpegFindButton";
            this.ffmpegFindButton.Size = new System.Drawing.Size(43, 23);
            this.ffmpegFindButton.TabIndex = 12;
            this.ffmpegFindButton.Text = "...";
            this.ffmpegFindButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ffmpegFindButton.UseVisualStyleBackColor = true;
            this.ffmpegFindButton.Click += new System.EventHandler(this.ffmpegFindButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(126, 186);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(204, 13);
            this.label3.TabIndex = 41;
            this.label3.Text = "Sequential = Download one after another.";
            // 
            // sequentialBox
            // 
            this.sequentialBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sequentialBox.Checked = true;
            this.sequentialBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.sequentialBox.Location = new System.Drawing.Point(129, 166);
            this.sequentialBox.Name = "sequentialBox";
            this.sequentialBox.Size = new System.Drawing.Size(127, 17);
            this.sequentialBox.TabIndex = 40;
            this.sequentialBox.Text = "Sequential Download";
            this.sequentialBox.UseVisualStyleBackColor = true;
            this.sequentialBox.CheckedChanged += new System.EventHandler(this.sequentialBox_CheckedChanged);
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.Location = new System.Drawing.Point(579, -122);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(70, 25);
            this.saveButton.TabIndex = 39;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            // 
            // SaveSettingsButton
            // 
            this.SaveSettingsButton.Image = global::DownloadMerger.Properties.Resources.SaveIcon;
            this.SaveSettingsButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SaveSettingsButton.Location = new System.Drawing.Point(590, 176);
            this.SaveSettingsButton.Name = "SaveSettingsButton";
            this.SaveSettingsButton.Size = new System.Drawing.Size(56, 23);
            this.SaveSettingsButton.TabIndex = 42;
            this.SaveSettingsButton.Text = "Save";
            this.SaveSettingsButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.SaveSettingsButton.UseVisualStyleBackColor = true;
            this.SaveSettingsButton.Click += new System.EventHandler(this.SaveSettingsButton_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(126, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 13);
            this.label4.TabIndex = 43;
            this.label4.Text = "Don\'t have ffmpeg.exe?";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(253, 86);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(176, 13);
            this.linkLabel1.TabIndex = 44;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "https://ffmpeg.zeranoe.com/builds/";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // ClearDataButton
            // 
            this.ClearDataButton.Image = global::DownloadMerger.Properties.Resources.DeleteIcon;
            this.ClearDataButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ClearDataButton.Location = new System.Drawing.Point(472, 176);
            this.ClearDataButton.Name = "ClearDataButton";
            this.ClearDataButton.Size = new System.Drawing.Size(94, 23);
            this.ClearDataButton.TabIndex = 45;
            this.ClearDataButton.Text = "Clear All Data";
            this.ClearDataButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ClearDataButton.UseVisualStyleBackColor = true;
            this.ClearDataButton.Click += new System.EventHandler(this.ClearDataButton_Click);
            // 
            // addPause
            // 
            this.addPause.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addPause.Location = new System.Drawing.Point(129, 128);
            this.addPause.Name = "addPause";
            this.addPause.Size = new System.Drawing.Size(127, 17);
            this.addPause.TabIndex = 46;
            this.addPause.Text = "Add pause command";
            this.addPause.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(126, 148);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(440, 13);
            this.label5.TabIndex = 47;
            this.label5.Text = "(Debug) An option to add pause command to ffmpeg. You can view if download failed" +
    " or not";
            // 
            // button1
            // 
            this.button1.Image = global::DownloadMerger.Properties.Resources.InstallDownload;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(603, 61);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(43, 23);
            this.button1.TabIndex = 48;
            this.button1.Text = "✓";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SettingsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = MetroFramework.Drawing.MetroBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(661, 210);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.addPause);
            this.Controls.Add(this.ClearDataButton);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.SaveSettingsButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.sequentialBox);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.outputLocationInput);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ffmpegLocationInput);
            this.Controls.Add(this.OutputLocationButton);
            this.Controls.Add(this.ffmpegFindButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsWindow";
            this.Resizable = false;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.SettingsWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox outputLocationInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ffmpegLocationInput;
        private System.Windows.Forms.Button OutputLocationButton;
        private System.Windows.Forms.Button ffmpegFindButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox sequentialBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button SaveSettingsButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button ClearDataButton;
        private System.Windows.Forms.CheckBox addPause;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
    }
}