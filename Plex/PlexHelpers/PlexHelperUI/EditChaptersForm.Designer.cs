namespace PlexHelperUI
{
    partial class EditChaptersForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.SaveButton = new System.Windows.Forms.Button();
            this.DestinationButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SourceButton = new System.Windows.Forms.Button();
            this.sourceFileTextBox = new System.Windows.Forms.TextBox();
            this.destinationFolderTextBox = new System.Windows.Forms.TextBox();
            this.newNameTextBox = new System.Windows.Forms.TextBox();
            this.sourceFileLabel = new System.Windows.Forms.Label();
            this.destinationFolderLabel = new System.Windows.Forms.Label();
            this.newFilenameLabel = new System.Windows.Forms.Label();
            this.chapterDataTextBox = new System.Windows.Forms.TextBox();
            this.chapterDataLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.SaveButton);
            this.panel1.Controls.Add(this.DestinationButton);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.SourceButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(640, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(160, 450);
            this.panel1.TabIndex = 0;
            // 
            // SaveButton
            // 
            this.SaveButton.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SaveButton.Location = new System.Drawing.Point(3, 145);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(141, 51);
            this.SaveButton.TabIndex = 3;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // DestinationButton
            // 
            this.DestinationButton.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DestinationButton.Location = new System.Drawing.Point(3, 78);
            this.DestinationButton.Name = "DestinationButton";
            this.DestinationButton.Size = new System.Drawing.Size(141, 51);
            this.DestinationButton.TabIndex = 2;
            this.DestinationButton.Text = "Destination";
            this.DestinationButton.UseVisualStyleBackColor = true;
            this.DestinationButton.Click += new System.EventHandler(this.DestinationButton_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(3, 78);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(141, 51);
            this.button1.TabIndex = 2;
            this.button1.Text = "Source";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // SourceButton
            // 
            this.SourceButton.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SourceButton.Location = new System.Drawing.Point(3, 12);
            this.SourceButton.Name = "SourceButton";
            this.SourceButton.Size = new System.Drawing.Size(141, 51);
            this.SourceButton.TabIndex = 1;
            this.SourceButton.Text = "Source";
            this.SourceButton.UseVisualStyleBackColor = true;
            this.SourceButton.Click += new System.EventHandler(this.SourceButton_Click);
            // 
            // sourceFileTextBox
            // 
            this.sourceFileTextBox.Location = new System.Drawing.Point(12, 40);
            this.sourceFileTextBox.Name = "sourceFileTextBox";
            this.sourceFileTextBox.Size = new System.Drawing.Size(622, 23);
            this.sourceFileTextBox.TabIndex = 1;
            // 
            // destinationFolderTextBox
            // 
            this.destinationFolderTextBox.Location = new System.Drawing.Point(12, 106);
            this.destinationFolderTextBox.Name = "destinationFolderTextBox";
            this.destinationFolderTextBox.Size = new System.Drawing.Size(318, 23);
            this.destinationFolderTextBox.TabIndex = 2;
            // 
            // newNameTextBox
            // 
            this.newNameTextBox.Location = new System.Drawing.Point(336, 106);
            this.newNameTextBox.Name = "newNameTextBox";
            this.newNameTextBox.Size = new System.Drawing.Size(298, 23);
            this.newNameTextBox.TabIndex = 3;
            // 
            // sourceFileLabel
            // 
            this.sourceFileLabel.AutoSize = true;
            this.sourceFileLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.sourceFileLabel.Location = new System.Drawing.Point(12, 12);
            this.sourceFileLabel.Name = "sourceFileLabel";
            this.sourceFileLabel.Size = new System.Drawing.Size(131, 27);
            this.sourceFileLabel.TabIndex = 4;
            this.sourceFileLabel.Text = "Source Video File";
            this.sourceFileLabel.UseCompatibleTextRendering = true;
            // 
            // destinationFolderLabel
            // 
            this.destinationFolderLabel.AutoSize = true;
            this.destinationFolderLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.destinationFolderLabel.Location = new System.Drawing.Point(12, 78);
            this.destinationFolderLabel.Name = "destinationFolderLabel";
            this.destinationFolderLabel.Size = new System.Drawing.Size(139, 27);
            this.destinationFolderLabel.TabIndex = 5;
            this.destinationFolderLabel.Text = "Destination Folder";
            this.destinationFolderLabel.UseCompatibleTextRendering = true;
            // 
            // newFilenameLabel
            // 
            this.newFilenameLabel.AutoSize = true;
            this.newFilenameLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.newFilenameLabel.Location = new System.Drawing.Point(336, 78);
            this.newFilenameLabel.Name = "newFilenameLabel";
            this.newFilenameLabel.Size = new System.Drawing.Size(116, 27);
            this.newFilenameLabel.TabIndex = 6;
            this.newFilenameLabel.Text = "New File Name";
            this.newFilenameLabel.UseCompatibleTextRendering = true;
            // 
            // chapterDataTextBox
            // 
            this.chapterDataTextBox.Location = new System.Drawing.Point(12, 163);
            this.chapterDataTextBox.Multiline = true;
            this.chapterDataTextBox.Name = "chapterDataTextBox";
            this.chapterDataTextBox.Size = new System.Drawing.Size(622, 275);
            this.chapterDataTextBox.TabIndex = 7;
            // 
            // chapterDataLabel
            // 
            this.chapterDataLabel.AutoSize = true;
            this.chapterDataLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.chapterDataLabel.Location = new System.Drawing.Point(12, 135);
            this.chapterDataLabel.Name = "chapterDataLabel";
            this.chapterDataLabel.Size = new System.Drawing.Size(293, 27);
            this.chapterDataLabel.TabIndex = 8;
            this.chapterDataLabel.Text = "Chapter Data (hh:mm:ss.mmm Chapter)";
            this.chapterDataLabel.UseCompatibleTextRendering = true;
            // 
            // EditChaptersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.chapterDataLabel);
            this.Controls.Add(this.chapterDataTextBox);
            this.Controls.Add(this.newFilenameLabel);
            this.Controls.Add(this.destinationFolderLabel);
            this.Controls.Add(this.sourceFileLabel);
            this.Controls.Add(this.newNameTextBox);
            this.Controls.Add(this.destinationFolderTextBox);
            this.Controls.Add(this.sourceFileTextBox);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "EditChaptersForm";
            this.Text = "EditChaptersForm";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel panel1;
        private Button DestinationButton;
        private Button button1;
        private Button SourceButton;
        private TextBox sourceFileTextBox;
        private Button SaveButton;
        private TextBox destinationFolderTextBox;
        private TextBox newNameTextBox;
        private Label sourceFileLabel;
        private Label destinationFolderLabel;
        private Label newFilenameLabel;
        private TextBox chapterDataTextBox;
        private Label chapterDataLabel;
    }
}