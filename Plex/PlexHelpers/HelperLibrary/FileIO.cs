namespace HelperLibrary;

public class FileIO
{
    public static void WriteText(string[] text, string filepath)
    {
        File.WriteAllLines(filepath, text);
    }

    public static void WriteText(string text, string filepath)
    {
        File.WriteAllText(filepath, text);
    }

    public static string[] ReadTextLine(string filepath)
    {
        return File.ReadAllLines(filepath);
    }

    public static string ReadText(string filepath)
    {
        return File.ReadAllText(filepath);
    }

    public static void Move(string originalPath, string newPath)
    {
        File.Move(originalPath, newPath);
    }
}
