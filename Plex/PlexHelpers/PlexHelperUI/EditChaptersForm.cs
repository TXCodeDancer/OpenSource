namespace PlexHelperUI
{
    public partial class EditChaptersForm : Form
    {
        public EditChaptersForm()
        {
            InitializeComponent();
        }

        private void selectButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"V:\",
                Title = "Browse Video Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "mp4",
                Filter = "mp4 video files (*.mp4)|*.mp4|All files (*.*)|*.*",
                FilterIndex = 1,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                videoFileTextBox.Text = openFileDialog1.FileName;
            }
        }
    }
}
