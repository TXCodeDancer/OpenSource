using HelperLibrary;

namespace PlexHelperUI
{
    public partial class RenameFilesSpaceToDotsForm : Form
    {
        private static string? CurrentSourcePath = @"V:\";
        private static string? CurrentDestinationPath = @"V:\";

        public RenameFilesSpaceToDotsForm()
        {
            InitializeComponent();
        }

        private void BrowseSourceFolderButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new()
            {
                InitialDirectory = CurrentSourcePath,
                Description = "Select Video Folder",
                UseDescriptionForTitle = true,
                ShowNewFolderButton = false,
            };

            List<string> videoFiles = new();

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                var path = folderBrowserDialog.SelectedPath;
                CurrentSourcePath = path;
                SourcePathTextBox.Text = path;

                DirectoryInfo d = new(path);
                FileInfo[] infos = d.GetFiles();
                foreach (FileInfo f in infos)
                {
                    videoFiles.Add(f.Name);
                }
            }

            OriginalFileListBox.Items.Clear();
            foreach (var file in videoFiles)
            {
                OriginalFileListBox.Items.Add(file.ToString());
            }
        }

        private void DestinationButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1 = new()
            {
                InitialDirectory = CurrentDestinationPath,
                Description = "Select Destination Folder",
                UseDescriptionForTitle = true,
                ShowNewFolderButton = true,
            };

            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                var path = folderBrowserDialog1.SelectedPath;
                CurrentDestinationPath = path;
                DestinationPathTextBox.Text = path;
            }
        }

        private void RenameButton_Click(object sender, EventArgs e)
        {
            var path = SourcePathTextBox.Text;
            var destinationPath = path;

            if (DestinationPathTextBox.Text != "")
            {
                destinationPath = DestinationPathTextBox.Text;
            }

            if (path == null)
                return;

            List<string> videoFiles = NameChange.RenameFilesSpacesToDots(path, destinationPath);

            RenamedFileListBox.Items.Clear();
            foreach (var file in videoFiles)
            {
                RenamedFileListBox.Items.Add(file.ToString());
            }
        }
    }
}
