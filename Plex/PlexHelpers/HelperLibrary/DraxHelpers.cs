namespace HelperLibrary
{
    public class DraxHelpers
    {
        public static async Task<string?> GetChapterData(string filepath)
        {
            try
            {
                var directory = Path.GetDirectoryName(filepath);
                string chapterFile = $"{directory}\\tempChapters.txt";
                FileIO.WriteText(chapterFile, "");

                string command = "drax.exe";
                string arguments = $"/export:\"{chapterFile}\" /file:\"{filepath}\"";
                var commandTask = CommandRunner.RunCommandAsync(command, arguments);
                var exitCodes = await commandTask;
                var results = FileIO.ReadText(chapterFile);
                return results;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public static async Task<string?> SetChapterData(string filepath, string chapterData)
        {
            chapterData = chapterData.Trim();
            try
            {
                var directory = Path.GetDirectoryName(filepath);
                string chapterFile = $"{directory}\\tempChapters.txt";
                FileIO.WriteText(chapterFile, chapterData);

                string command = "drax.exe";
                string arguments = $"/import:\"{chapterFile}\" /file:\"{filepath}\"";

                var exitCode = await CommandRunner.RunCommandAsync(command, arguments);
                return exitCode;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
