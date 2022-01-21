using HelperLibrary;

namespace PlexHelperUI
{
    public partial class PlexHelperForm : Form
    {
        public PlexHelperForm()
        {
            InitializeComponent();
        }

        private void BrowseFolderButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog
            {
                InitialDirectory = @"V:\",
                Description = "Select Video Folder",
                UseDescriptionForTitle = true,
            };

            List<string> videoFiles = new List<string>();

            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                var path = folderBrowserDialog1.SelectedPath;
                directoryTextBox.Text = path;

                DirectoryInfo d = new DirectoryInfo(path);
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

        private void RenameButton_Click(object sender, EventArgs e)
        {
            var path = directoryTextBox.Text;

            if (path == null)
                return;

            List<string> videoFiles = new List<string>();
            DirectoryInfo d = new DirectoryInfo(path);
            FileInfo[] infos = d.GetFiles();
            foreach (FileInfo f in infos)
            {
                videoFiles.Add(f.Name);
            }

            RenamedFileListBox.Items.Clear();
            foreach (var file in videoFiles)
            {
                var renamed = NameChange.ConvertSpace(file); ;
                RenamedFileListBox.Items.Add(renamed.ToString());
            }
        }
    }
}
