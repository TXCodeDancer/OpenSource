using HelperLibrary;

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
            chapterDataTextBox.Text = "";

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
                var filename = openFileDialog1.FileName;
                sourceFileTextBox.Text = filename;
                var chapterData = DraxHelpers.GetChapterData(filename);
                chapterDataTextBox.Text = chapterData;
            }
        }

        private void destinationButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1 = new()
            {
                InitialDirectory = @"V:\",
                Description = "Select Destination Folder",
                UseDescriptionForTitle = true,
                ShowNewFolderButton = false,
            };

            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                var path = folderBrowserDialog1.SelectedPath;
                DestinationPathTextBox.Text = path;
            }
        }
    }
}
