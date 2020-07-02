namespace DownloadMerger.Forms
{
    partial class AddCollectionWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddCollectionWindow));
            this.label2 = new System.Windows.Forms.Label();
            this.outputFolderLocationInput = new System.Windows.Forms.TextBox();
            this.OutputLocationButton = new System.Windows.Forms.Button();
            this.CreateCollectionButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.collection_name_input = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.label4 = new System.Windows.Forms.Label();
            this.AboutButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Output folder location:";
            // 
            // outputFolderLocationInput
            // 
            this.outputFolderLocationInput.Location = new System.Drawing.Point(134, 102);
            this.outputFolderLocationInput.Name = "outputFolderLocationInput";
            this.outputFolderLocationInput.Size = new System.Drawing.Size(314, 20);
            this.outputFolderLocationInput.TabIndex = 14;
            // 
            // OutputLocationButton
            // 
            this.OutputLocationButton.Image = global::DownloadMerger.Properties.Resources.FolderIcon;
            this.OutputLocationButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.OutputLocationButton.Location = new System.Drawing.Point(454, 100);
            this.OutputLocationButton.Name = "OutputLocationButton";
            this.OutputLocationButton.Size = new System.Drawing.Size(43, 23);
            this.OutputLocationButton.TabIndex = 13;
            this.OutputLocationButton.Text = "...";
            this.OutputLocationButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.OutputLocationButton.UseVisualStyleBackColor = true;
            this.OutputLocationButton.Click += new System.EventHandler(this.OutputLocationButton_Click);
            // 
            // CreateCollectionButton
            // 
            this.CreateCollectionButton.Image = global::DownloadMerger.Properties.Resources.DownloadIcon;
            this.CreateCollectionButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CreateCollectionButton.Location = new System.Drawing.Point(431, 139);
            this.CreateCollectionButton.Name = "CreateCollectionButton";
            this.CreateCollectionButton.Size = new System.Drawing.Size(66, 23);
            this.CreateCollectionButton.TabIndex = 12;
            this.CreateCollectionButton.Text = "Create";
            this.CreateCollectionButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CreateCollectionButton.UseVisualStyleBackColor = true;
            this.CreateCollectionButton.Click += new System.EventHandler(this.CreateCollectionButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Collections Name:";
            // 
            // collection_name_input
            // 
            this.collection_name_input.Location = new System.Drawing.Point(134, 63);
            this.collection_name_input.Name = "collection_name_input";
            this.collection_name_input.Size = new System.Drawing.Size(363, 20);
            this.collection_name_input.TabIndex = 16;
            this.collection_name_input.Text = "Videos";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(131, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(304, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Example: Random Videos, Supernatural S01, Prison Break S04\r\n";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(131, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(192, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Example: Supernatural S01, Season 01";
            // 
            // AboutButton
            // 
            this.AboutButton.Cursor = System.Windows.Forms.Cursors.Help;
            this.AboutButton.Image = global::DownloadMerger.Properties.Resources.QuestionmarkIcon;
            this.AboutButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.AboutButton.Location = new System.Drawing.Point(472, 28);
            this.AboutButton.Name = "AboutButton";
            this.AboutButton.Size = new System.Drawing.Size(25, 29);
            this.AboutButton.TabIndex = 20;
            this.AboutButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.AboutButton.UseVisualStyleBackColor = true;
            this.AboutButton.Click += new System.EventHandler(this.AboutButton_Click);
            // 
            // AddCollectionWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = MetroFramework.Drawing.MetroBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(517, 172);
            this.Controls.Add(this.AboutButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.collection_name_input);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.outputFolderLocationInput);
            this.Controls.Add(this.OutputLocationButton);
            this.Controls.Add(this.CreateCollectionButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddCollectionWindow";
            this.Resizable = false;
            this.Text = "Add Collection";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddCollectionWindow_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox outputFolderLocationInput;
        private System.Windows.Forms.Button OutputLocationButton;
        private System.Windows.Forms.Button CreateCollectionButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox collection_name_input;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button AboutButton;
    }
}