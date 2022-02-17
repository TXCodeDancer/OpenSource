using HelperLibrary;

namespace PlexHelperUI;

public partial class EditChaptersForm : Form
{
    private static readonly string InitialDestinationPath = @"V:\";
    private static string? CurrentDestinationPath = InitialDestinationPath;
    private static readonly string VideoFileExtention = "mp4";
    private static readonly Queue<Task> SetChapterDataTasks = new Queue<Task>();
    private static bool SourceAvailable = false;

    public EditChaptersForm()
    {
        InitializeComponent();
        SourceAvailable = false;
        var timer = new System.Windows.Forms.Timer
        {
            Interval = 200,
            Enabled = true,
        };
        timer.Tick += new System.EventHandler(OnTimerEvent);
    }

    private void OnTimerEvent(object? sender, EventArgs e)
    {
        if (SetChapterDataTasks.Any())
        {
            SaveButton.Enabled = false;
            var task = SetChapterDataTasks.Peek();
            if (task.IsCompleted)
            {
                SetChapterDataTasks.Dequeue();
            }
        }
        else
        {
            if (SourceAvailable)
                SaveButton.Enabled = true;
        }
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
                SourceAvailable = false;
                DisableButtons();
                var chapterDataTask = DraxHelpers.GetChapterData(filepath);
                var chapterData = await chapterDataTask;
                if (chapterData != null)
                    chapterDataTextBox.Text = chapterData;
                EnableButtons();
                SourceAvailable = true;
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
            var task = DraxHelpers.SetChapterData(sourcePath, chapterData);
            SetChapterDataTasks.Enqueue(task);
            var result = await task;
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

    private void DisableButtons()
    {
        SourceButton.Enabled = false;
        DestinationButton.Enabled = false;
        SaveButton.Enabled = false;
        MoveButton.Enabled = false;
    }

    private void EnableButtons()
    {
        SourceButton.Enabled = true;
        DestinationButton.Enabled = true;
        SaveButton.Enabled = true;
        MoveButton.Enabled = true;
    }
}
