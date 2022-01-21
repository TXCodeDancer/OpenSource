namespace PlexHelperUI
{
    public partial class PlexHelperForm : Form
    {
        public PlexHelperForm()
        {
            InitializeComponent();
        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"V:\",
                Title = "Browse Video Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "mp4",
                Filter = "video files (*.mp4)|*.mp4",
                FilterIndex = 1,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                directoryTextBox.Text = openFileDialog1.FileName;
            }
        }
    }
}
