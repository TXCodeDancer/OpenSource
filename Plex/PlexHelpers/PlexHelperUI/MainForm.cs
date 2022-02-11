namespace PlexHelperUI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        public void loadForm(object form)
        {
            if (this.mainPanel.Controls.Count > 0)
                this.mainPanel.Controls.Clear();
            Form f = (Form)form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.mainPanel.Controls.Add(f);
            this.mainPanel.Tag = f;
            f.Show();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void renameWithDotsButton_Click(object sender, EventArgs e)
        {
            loadForm(new RenameFilesSpaceToDotsForm());
        }
    }
}
