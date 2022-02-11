using HelperLibrary;

namespace PlexHelperUI
{
    public partial class RenameFilesSpaceToDotsForm : Form
    {
        public RenameFilesSpaceToDotsForm()
        {
            InitializeComponent();
        }

        private void BrowseSourceFolderButton_Click(object sender, EventArgs e)
        {
            DestinationPathTextBox.Text = "";

            string initialPath = @"V:\";
            try
            {
                DirectoryInfo d = new(defaultBrowserDialog1.InitialDirectory);
                initialPath = d.FullName;
            }
            catch (DirectoryNotFoundException ex)
            {
                MessageBox.Show(ex.Message);
            }

            FolderBrowserDialog folderBrowserDialog1 = new()
            {
                InitialDirectory = initialPath,
                Description = "Select Video Folder",
                UseDescriptionForTitle = true,
                ShowNewFolderButton = false,
            };

            List<string> videoFiles = new();

            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                var path = folderBrowserDialog1.SelectedPath;
                defaultBrowserDialog1.InitialDirectory = path;
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

            List<string> videoFiles = new();
            DirectoryInfo d = new(path);
            FileInfo[] infos = d.GetFiles();
            foreach (FileInfo f in infos)
            {
                var newName = NameChange.ConvertSpace(f.Name);
                var newFullName = destinationPath + "\\" + newName;
                File.Move(f.FullName, newFullName);
                videoFiles.Add(newName);
            }

            RenamedFileListBox.Items.Clear();
            foreach (var file in videoFiles)
            {
                RenamedFileListBox.Items.Add(file.ToString());
            }
        }
    }
}
