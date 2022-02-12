using HelperLibrary;

namespace PlexHelperUI;

public partial class EditChaptersForm : Form
{
    private static readonly string InitialDestinationPath = @"V:\";
    private static string? CurrentDestinationPath = InitialDestinationPath;

    public EditChaptersForm()
    {
        InitializeComponent();
    }

    private void sourceButton_Click(object sender, EventArgs e)
    {
        chapterDataTextBox.Text = "00:00:00.000 Title";
        newNameTextBox.Text = "";

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
            var filepath = openFileDialog1.FileName;
            sourceFileTextBox.Text = filepath;

            var folder = Path.GetDirectoryName(filepath);
            var filename = Path.GetFileName(filepath);

            if (CurrentDestinationPath == InitialDestinationPath)
            {
                CurrentDestinationPath = folder;
                destinationFolderTextBox.Text = folder;
            }
            newNameTextBox.Text = filename;

            var chapterData = DraxHelpers.GetChapterData(filepath);
            if (chapterData.Any())
                chapterDataTextBox.Text = chapterData;
        }
    }

    private void destinationButton_Click(object sender, EventArgs e)
    {
        FolderBrowserDialog folderBrowserDialog = new()
        {
            InitialDirectory = CurrentDestinationPath,
            Description = "Select Destination Folder",
            UseDescriptionForTitle = true,
            ShowNewFolderButton = false,
        };

        if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
        {
            var path = folderBrowserDialog.SelectedPath;
            CurrentDestinationPath = path;
            destinationFolderTextBox.Text = path;
        }
    }

    private void SaveButton_Click(object sender, EventArgs e)
    {
        var sourcePath = sourceFileTextBox.Text;
        var chapterData = chapterDataTextBox.Text;
        DraxHelpers.SetChapterData(sourcePath, chapterData);

        var folder = destinationFolderTextBox.Text;
        var name = newNameTextBox.Text;
        var destinationPath = folder + "/" + name;

        FileIO.Move(sourcePath, destinationPath);
    }
}
