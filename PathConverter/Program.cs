using System;
using System.IO;

class Program
{
    private static readonly string wslFlag = "-wsl";
    private static readonly char volumeSeparator = ':';
    
    static void Main(string[] args)
    {
        bool isWsl = false;

        if (args.Length == 1)
        {
            isWsl = IsWsl(args[0]);
            if (isWsl)
            {
                args[0] = string.Empty; // Empty input to ready for user input
            }
        }

        while (args.Length == 0 || string.IsNullOrEmpty(args[0]))
        {
            if(isWsl)
                Console.WriteLine("Enter the path of the file or directory:");
            else
                Console.WriteLine("Enter the path of the file or directory. Use <path> <-wsl> to convert to WSL style path:");

            var input = Console.ReadLine();
            if (!string.IsNullOrEmpty(input))
            {
                args = input.Split();
                if (args.Length == 2)
                {
                    isWsl = IsWsl(args[1]);
                }
            }
        }

        try
        {
            var inputPath = Path.GetFullPath(args[0].Trim('\"'));
            if (args[0] != ".")
            {
                inputPath = inputPath.Replace($"{Path.GetFullPath(".")}/", ""); // This is only needed when running from linux (WSL) as that system add the current directory to the full file path.
            }

            var outputPath = isWsl ? ConvertToWslPath(inputPath) : ConvertPath(inputPath);

            Console.WriteLine("Original Path: " + inputPath);
            Console.WriteLine("Converted Path: " + outputPath);
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }    
    }

    private static bool IsWsl(string flag)
    {
        return flag.Equals(wslFlag);
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
