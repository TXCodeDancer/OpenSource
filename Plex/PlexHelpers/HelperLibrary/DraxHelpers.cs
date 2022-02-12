namespace HelperLibrary
{
    public class DraxHelpers
    {
        public static string GetChapterData(string filepath)
        {
            var directory = Path.GetDirectoryName(filepath);
            string chapterFile = $"{directory}\\tempChapters.txt";

            string command = "drax.exe";
            string arguments = $"export:\"{chapterFile}\" /file:\"{filepath}\"";

            var exitCode = CommandRunner.RunCommand(command, arguments);

            return FileIO.ReadText(chapterFile);
        }
    }
}
