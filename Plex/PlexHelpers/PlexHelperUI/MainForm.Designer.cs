namespace PlexHelperUI
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
            this.controlPanel = new System.Windows.Forms.Panel();
            this.controlPanelLabel = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.editChapterButton = new System.Windows.Forms.Button();
            this.renameWithDotsButton = new System.Windows.Forms.Button();
            this.headerPanel = new System.Windows.Forms.Panel();
            this.closeButton = new System.Windows.Forms.Button();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.controlPanel.SuspendLayout();
            this.headerPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // controlPanel
            // 
            this.controlPanel.BackColor = System.Drawing.Color.DimGray;
            this.controlPanel.Controls.Add(this.controlPanelLabel);
            this.controlPanel.Controls.Add(this.button3);
            this.controlPanel.Controls.Add(this.editChapterButton);
            this.controlPanel.Controls.Add(this.renameWithDotsButton);
            this.controlPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.controlPanel.Location = new System.Drawing.Point(0, 30);
            this.controlPanel.Name = "controlPanel";
            this.controlPanel.Size = new System.Drawing.Size(200, 450);
            this.controlPanel.TabIndex = 0;
            // 
            // controlPanelLabel
            // 
            this.controlPanelLabel.BackColor = System.Drawing.Color.DimGray;
            this.controlPanelLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.controlPanelLabel.ForeColor = System.Drawing.Color.White;
            this.controlPanelLabel.Location = new System.Drawing.Point(-3, 0);
            this.controlPanelLabel.Name = "controlPanelLabel";
            this.controlPanelLabel.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.controlPanelLabel.Size = new System.Drawing.Size(200, 40);
            this.controlPanelLabel.TabIndex = 0;
            this.controlPanelLabel.Text = "Video File Helpers:";
            this.controlPanelLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.DimGray;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(-3, 144);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(200, 40);
            this.button3.TabIndex = 2;
            this.button3.Text = "Unused";
            this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Visible = false;
            // 
            // editChapterButton
            // 
            this.editChapterButton.BackColor = System.Drawing.Color.DimGray;
            this.editChapterButton.FlatAppearance.BorderSize = 0;
            this.editChapterButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editChapterButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.editChapterButton.ForeColor = System.Drawing.Color.White;
            this.editChapterButton.Location = new System.Drawing.Point(0, 98);
            this.editChapterButton.Name = "editChapterButton";
            this.editChapterButton.Size = new System.Drawing.Size(200, 40);
            this.editChapterButton.TabIndex = 1;
            this.editChapterButton.Text = "Edit Chapters";
            this.editChapterButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.editChapterButton.UseVisualStyleBackColor = false;
            // 
            // renameWithDotsButton
            // 
            this.renameWithDotsButton.BackColor = System.Drawing.Color.DimGray;
            this.renameWithDotsButton.FlatAppearance.BorderSize = 0;
            this.renameWithDotsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.renameWithDotsButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.renameWithDotsButton.ForeColor = System.Drawing.Color.White;
            this.renameWithDotsButton.Location = new System.Drawing.Point(0, 52);
            this.renameWithDotsButton.Name = "renameWithDotsButton";
            this.renameWithDotsButton.Size = new System.Drawing.Size(200, 40);
            this.renameWithDotsButton.TabIndex = 0;
            this.renameWithDotsButton.Text = "Rename With Dots";
            this.renameWithDotsButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.renameWithDotsButton.UseVisualStyleBackColor = false;
            this.renameWithDotsButton.Click += new System.EventHandler(this.renameWithDotsButton_Click);
            // 
            // headerPanel
            // 
            this.headerPanel.BackColor = System.Drawing.Color.Gray;
            this.headerPanel.Controls.Add(this.closeButton);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(1000, 30);
            this.headerPanel.TabIndex = 1;
            this.headerPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.headerPanel_MouseDown);
            // 
            // closeButton
            // 
            this.closeButton.BackColor = System.Drawing.Color.Gray;
            this.closeButton.FlatAppearance.BorderSize = 0;
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.closeButton.ForeColor = System.Drawing.Color.White;
            this.closeButton.Location = new System.Drawing.Point(970, 0);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(30, 30);
            this.closeButton.TabIndex = 3;
            this.closeButton.Text = "X";
            this.closeButton.UseVisualStyleBackColor = false;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // mainPanel
            // 
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(200, 30);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(800, 450);
            this.mainPanel.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1000, 480);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.controlPanel);
            this.Controls.Add(this.headerPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.Text = "Video File Helper";
            this.controlPanel.ResumeLayout(false);
            this.headerPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel controlPanel;
        private Panel headerPanel;
        private Panel mainPanel;
        private Button renameWithDotsButton;
        private Button button3;
        private Button editChapterButton;
        private Button closeButton;
        private Label controlPanelLabel;
    }
}