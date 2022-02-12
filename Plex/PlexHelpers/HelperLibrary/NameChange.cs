namespace HelperLibrary;

public class NameChange
{
    public static string ConvertSpace(string name, char replacement = '.')
    {
        name = name.Trim();
        name = name.Replace(" ", replacement.ToString());
        name = name.Replace("-", "");
        name = name.Replace("_", "");

        string result = name[0].ToString();
        for (int i = 1; i < name.Length; i++)
        {
            if (name[i] != replacement || name[i] != name[i - 1])
            {
                result += name[i];
            }
        }

        return result;
    }

    public static List<string> RenameFilesSpacesToDots(string path, string destinationPath)
    {
        List<string> videoFiles = new();
        DirectoryInfo d = new(path);
        FileInfo[] infos = d.GetFiles();
        foreach (FileInfo f in infos)
        {
            var newName = ConvertSpace(f.Name);
            var newFullName = destinationPath + "\\" + newName;
            File.Move(f.FullName, newFullName);
            videoFiles.Add(newName);
        }

        return videoFiles;
    }

    //public static string Rename(string oldName, string newName)
    //{
    //    oldName = oldName.Trim();
    //    newName = newName.Trim();

    //    string result = name[0].ToString();
    //    for (int i = 1; i < name.Length; i++)
    //    {
    //        if (name[i] != replacement || name[i] != name[i - 1])
    //        {
    //            result += name[i];
    //        }
    //    }

    //    return result;
    //}
}
