namespace HelperLibrary
{
    public class DraxHelpers
    {
        public static string GetChapterData(string filepath)
        {
            try
            {
                var directory = Path.GetDirectoryName(filepath);
                string chapterFile = $"{directory}\\tempChapters.txt";

                string command = "drax.exe";
                string arguments = $"/export:\"{chapterFile}\" /file:\"{filepath}\"";
                var exitCode = CommandRunner.RunCommand(command, arguments);
                var results = FileIO.ReadText(chapterFile);
                return results;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public static void SetChapterData(string filepath, string chapterData)
        {
            try
            {
                var directory = Path.GetDirectoryName(filepath);
                string chapterFile = $"{directory}\\tempChapters.txt";
                FileIO.WriteText(chapterData, chapterFile);

                string command = "drax.exe";
                string arguments = $"/import:\"{chapterFile}\" /file:\"{filepath}\"";

                var exitCode = CommandRunner.RunCommand(command, arguments);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
