using System;
using System.IO;

class Program
{
    private static readonly string wslFlag = "-wsl";
    private static readonly char volumeSeparator = ':';
    
    static void Main(string[] args)
    {
        var inputPath = args.Length != 0 ? Path.GetFullPath(args[0]) : null;

        while (string.IsNullOrEmpty(inputPath))
        {
            Console.WriteLine("Enter the path of the file or directory. Enter <path> <-wsl> to convert to WSL style path:");
            inputPath = Console.ReadLine();
            if (string.IsNullOrEmpty(inputPath))
            {
                Console.WriteLine("Invalid input. Please enter a valid path.");
                continue;
            }
            args = inputPath.Split(' ');
            inputPath = Path.GetFullPath(args[0]);
        }
        var isWsl = (args.Length > 1) && args[1].Equals(wslFlag);

        var outputPath = isWsl ? ConvertToWslPath(inputPath) : ConvertPath(inputPath);
        Console.WriteLine("Original Path: " + inputPath);
        Console.WriteLine("Converted Path: " + outputPath);
    }

    private static string ConvertPath(string windowsPath)
    {
        string convertedPath = windowsPath.Replace("\\", "/");
        return convertedPath;
    }

    static string ConvertToWslPath(string windowsPath)
    {
        int volumeSeparatorPosition = windowsPath.IndexOf(volumeSeparator);
        
        // Replace backslashes with forward slashes
        string wslPath = windowsPath.Replace("\\", "/");

        // Replace the drive letter with /mnt/<drive letter>
        if (volumeSeparatorPosition > 0)
        {
            char driveLetter = char.ToLower(wslPath[volumeSeparatorPosition - 1]);
            wslPath = $"/mnt/{driveLetter}{wslPath[(volumeSeparatorPosition + 1)..]}";
        }

        return wslPath;
    }
}
