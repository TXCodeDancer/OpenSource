namespace PlexHelperUI
{
    partial class RenameFilesSpaceToDotsForm
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
            this.BrowseSourceFolderButton = new System.Windows.Forms.Button();
            this.SourcePathTextBox = new System.Windows.Forms.TextBox();
            this.RenameButton = new System.Windows.Forms.Button();
            this.OriginalFileListBox = new System.Windows.Forms.ListBox();
            this.RenamedFileListBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.DestinationButton = new System.Windows.Forms.Button();
            this.DestinationPathTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // BrowseSourceFolderButton
            // 
            this.BrowseSourceFolderButton.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BrowseSourceFolderButton.Location = new System.Drawing.Point(633, 12);
            this.BrowseSourceFolderButton.Name = "BrowseSourceFolderButton";
            this.BrowseSourceFolderButton.Size = new System.Drawing.Size(141, 51);
            this.BrowseSourceFolderButton.TabIndex = 0;
            this.BrowseSourceFolderButton.Text = "Source";
            this.BrowseSourceFolderButton.UseVisualStyleBackColor = true;
            this.BrowseSourceFolderButton.Click += new System.EventHandler(this.BrowseSourceFolderButton_Click);
            // 
            // SourcePathTextBox
            // 
            this.SourcePathTextBox.Location = new System.Drawing.Point(12, 30);
            this.SourcePathTextBox.Name = "SourcePathTextBox";
            this.SourcePathTextBox.Size = new System.Drawing.Size(615, 23);
            this.SourcePathTextBox.TabIndex = 1;
            // 
            // RenameButton
            // 
            this.RenameButton.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.RenameButton.Location = new System.Drawing.Point(633, 146);
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
            this.OriginalFileListBox.Location = new System.Drawing.Point(12, 146);
            this.OriginalFileListBox.Name = "OriginalFileListBox";
            this.OriginalFileListBox.Size = new System.Drawing.Size(300, 289);
            this.OriginalFileListBox.TabIndex = 3;
            // 
            // RenamedFileListBox
            // 
            this.RenamedFileListBox.FormattingEnabled = true;
            this.RenamedFileListBox.ItemHeight = 15;
            this.RenamedFileListBox.Location = new System.Drawing.Point(327, 146);
            this.RenamedFileListBox.Name = "RenamedFileListBox";
            this.RenamedFileListBox.Size = new System.Drawing.Size(300, 289);
            this.RenamedFileListBox.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Original File Names";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(327, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "New File Names";
            // 
            // DestinationButton
            // 
            this.DestinationButton.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DestinationButton.Location = new System.Drawing.Point(633, 69);
            this.DestinationButton.Name = "DestinationButton";
            this.DestinationButton.Size = new System.Drawing.Size(141, 51);
            this.DestinationButton.TabIndex = 7;
            this.DestinationButton.Text = "Destination";
            this.DestinationButton.UseVisualStyleBackColor = true;
            this.DestinationButton.Click += new System.EventHandler(this.DestinationButton_Click);
            // 
            // DestinationPathTextBox
            // 
            this.DestinationPathTextBox.Location = new System.Drawing.Point(12, 87);
            this.DestinationPathTextBox.Name = "DestinationPathTextBox";
            this.DestinationPathTextBox.Size = new System.Drawing.Size(615, 23);
            this.DestinationPathTextBox.TabIndex = 8;
            // 
            // RenameFilesSpaceToDotsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.DestinationPathTextBox);
            this.Controls.Add(this.DestinationButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.RenamedFileListBox);
            this.Controls.Add(this.OriginalFileListBox);
            this.Controls.Add(this.RenameButton);
            this.Controls.Add(this.SourcePathTextBox);
            this.Controls.Add(this.BrowseSourceFolderButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RenameFilesSpaceToDotsForm";
            this.Text = "Rename Spaces to Dots";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Button BrowseSourceFolderButton;
        private TextBox SourcePathTextBox;
        private Button RenameButton;
        private ListBox OriginalFileListBox;
        private ListBox RenamedFileListBox;
        private Label label1;
        private Label label2;
        private Button DestinationButton;
        private TextBox DestinationPathTextBox;
    }
}