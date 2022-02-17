using HelperLibrary;

namespace PlexHelperUI;

public partial class EditChaptersForm : Form
{
    private static readonly string InitialDestinationPath = @"V:\";
    private static string? CurrentDestinationPath = InitialDestinationPath;
    private static readonly string VideoFileExtention = "mp4";
    private static List<Task> SetChapterDataTasks = new List<Task>();
    private static int timeLeft = 60;

    public EditChaptersForm()
    {
        InitializeComponent();
        timer.Interval = 1000;
        timer.Start();

        timeLeft = 60;
        timer.Tick += Timer_Tick;
    }

    private async void SourceButton_Click(object sender, EventArgs e)
    {
        chapterDataTextBox.Text = "00:00:00.000 Title";
        newNameTextBox.Text = "";

        OpenFileDialog openFileDialog1 = new()
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
            var filename = Path.GetFileNameWithoutExtension(filepath);

            if (CurrentDestinationPath == InitialDestinationPath)
            {
                CurrentDestinationPath = folder;
                destinationFolderTextBox.Text = folder;
            }
            newNameTextBox.Text = filename;

            try
            {
                SourceButton.Enabled = false;
                var chapterDataTask = DraxHelpers.GetChapterData(filepath);
                var chapterData = await chapterDataTask;
                if (chapterData != null)
                    chapterDataTextBox.Text = chapterData;
                SourceButton.Enabled = true;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }

    private void DestinationButton_Click(object sender, EventArgs e)
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

    private async void SaveButton_Click(object sender, EventArgs e)
    {
        var sourcePath = sourceFileTextBox.Text;
        var chapterData = chapterDataTextBox.Text;

        try
        {
            //SaveButton.Enabled = false;
            var task = DraxHelpers.SetChapterData(sourcePath, chapterData);
            SetChapterDataTasks.Add(task);
            var result = await task;
            //SaveButton.Enabled = true;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void MoveButton_Click(object sender, EventArgs e)
    {
        var sourcePath = sourceFileTextBox.Text;
        var folder = destinationFolderTextBox.Text;
        var name = newNameTextBox.Text;
        var destinationPath = folder + "/" + name + "." + VideoFileExtention;

        try
        {
            FileIO.Move(sourcePath, destinationPath);
            sourceFileTextBox.Text = String.Empty;
            newNameTextBox.Text = String.Empty;
            chapterDataTextBox.Text = String.Empty;
        }
        catch (IOException ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void Timer_Tick(object sender, EventArgs e)
    {
        //timeLeft--;

        //if (timeLeft <= 0)
        //{
        //    timer.Stop();
        //}

        if (SetChapterDataTasks.Any())
            SaveButton.Enabled = false;
        else
            SaveButton.Enabled = true;
    }
}
