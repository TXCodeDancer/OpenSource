namespace PlexHelperUI
{
    partial class PlexHelperForm
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
            this.BrowseFolderButton = new System.Windows.Forms.Button();
            this.directoryTextBox = new System.Windows.Forms.TextBox();
            this.defaultBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.RenameButton = new System.Windows.Forms.Button();
            this.OriginalFileListBox = new System.Windows.Forms.ListBox();
            this.RenamedFileListBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BrowseFolderButton
            // 
            this.BrowseFolderButton.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BrowseFolderButton.Location = new System.Drawing.Point(633, 29);
            this.BrowseFolderButton.Name = "BrowseFolderButton";
            this.BrowseFolderButton.Size = new System.Drawing.Size(141, 51);
            this.BrowseFolderButton.TabIndex = 0;
            this.BrowseFolderButton.Text = "Browse";
            this.BrowseFolderButton.UseVisualStyleBackColor = true;
            this.BrowseFolderButton.Click += new System.EventHandler(this.BrowseFolderButton_Click);
            // 
            // directoryTextBox
            // 
            this.directoryTextBox.Location = new System.Drawing.Point(12, 29);
            this.directoryTextBox.Name = "directoryTextBox";
            this.directoryTextBox.Size = new System.Drawing.Size(615, 23);
            this.directoryTextBox.TabIndex = 1;
            // 
            // defaultBrowserDialog1
            // 
            this.defaultBrowserDialog1.Description = "Select Video File Folder";
            this.defaultBrowserDialog1.InitialDirectory = "@\"V:\\\"";
            this.defaultBrowserDialog1.ShowNewFolderButton = false;
            this.defaultBrowserDialog1.UseDescriptionForTitle = true;
            // 
            // RenameButton
            // 
            this.RenameButton.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.RenameButton.Location = new System.Drawing.Point(633, 86);
            this.RenameButton.Name = "RenameButton";
            this.RenameButton.Size = new System.Drawing.Size(141, 51);
            this.RenameButton.TabIndex = 2;
            this.RenameButton.Text = "Rename";
            this.RenameButton.UseVisualStyleBackColor = true;
            this.RenameButton.Click += new System.EventHandler(this.RenameButton_Click);
            // 
            // OriginalFileListBox
            // 
            this.OriginalFileListBox.FormattingEnabled = true;
            this.OriginalFileListBox.ItemHeight = 15;
            this.OriginalFileListBox.Location = new System.Drawing.Point(12, 86);
            this.OriginalFileListBox.Name = "OriginalFileListBox";
            this.OriginalFileListBox.Size = new System.Drawing.Size(300, 349);
            this.OriginalFileListBox.TabIndex = 3;
            // 
            // RenamedFileListBox
            // 
            this.RenamedFileListBox.FormattingEnabled = true;
            this.RenamedFileListBox.ItemHeight = 15;
            this.RenamedFileListBox.Location = new System.Drawing.Point(327, 86);
            this.RenamedFileListBox.Name = "RenamedFileListBox";
            this.RenamedFileListBox.Size = new System.Drawing.Size(300, 349);
            this.RenamedFileListBox.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Original File Names";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(327, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "New File Names";
            // 
            // PlexHelperForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.RenamedFileListBox);
            this.Controls.Add(this.OriginalFileListBox);
            this.Controls.Add(this.RenameButton);
            this.Controls.Add(this.directoryTextBox);
            this.Controls.Add(this.BrowseFolderButton);
            this.Name = "PlexHelperForm";
            this.Text = "Plex Helper";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Button BrowseFolderButton;
        private TextBox directoryTextBox;
        private FolderBrowserDialog defaultBrowserDialog1;
        private Button RenameButton;
        private ListBox OriginalFileListBox;
        private ListBox RenamedFileListBox;
        private Label label1;
        private Label label2;
    }
}