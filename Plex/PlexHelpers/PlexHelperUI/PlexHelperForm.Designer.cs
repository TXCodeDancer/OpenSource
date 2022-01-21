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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.browseButton = new System.Windows.Forms.Button();
            this.directoryTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "\"mp4\"";
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "\"video files (*.mp4)|*.txt|All files (*.*)|*.*\"";
            this.openFileDialog1.InitialDirectory = "@\"V:\\\"";
            this.openFileDialog1.RestoreDirectory = true;
            this.openFileDialog1.Title = "\"Browse Video Files\"";
            // 
            // browseButton
            // 
            this.browseButton.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.browseButton.Location = new System.Drawing.Point(633, 29);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(141, 51);
            this.browseButton.TabIndex = 0;
            this.browseButton.Text = "Browse";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.BrowseButton_Click);
            // 
            // directoryTextBox
            // 
            this.directoryTextBox.Location = new System.Drawing.Point(12, 44);
            this.directoryTextBox.Name = "directoryTextBox";
            this.directoryTextBox.Size = new System.Drawing.Size(615, 23);
            this.directoryTextBox.TabIndex = 1;
            // 
            // PlexHelperForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.directoryTextBox);
            this.Controls.Add(this.browseButton);
            this.Name = "PlexHelperForm";
            this.Text = "Plex Helper";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OpenFileDialog openFileDialog1;
        private Button browseButton;
        private TextBox directoryTextBox;
    }
}