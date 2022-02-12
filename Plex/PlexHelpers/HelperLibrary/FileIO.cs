namespace HelperLibrary;

public class FileIO
{
    public static void WriteTextLines(string[] text, string filepath)
    {
        File.WriteAllLines(filepath, text);
    }

    public static string[] ReadTextLine(string filepath)
    {
        return File.ReadAllLines(filepath);
    }

    public static string ReadText(string filepath)
    {
        return File.ReadAllText(filepath);
    }
}
