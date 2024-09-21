using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        var inputPath = args.Length != 0 ? args[0] : null;
        while (string.IsNullOrEmpty(inputPath))
        {
            Console.WriteLine("Enter the path of the file or directory:");
            inputPath = Console.ReadLine();
            if (string.IsNullOrEmpty(inputPath))
            {
                Console.WriteLine("Invalid input. Please enter a valid path.");
            }
        }

        string fullPath = Path.GetFullPath(inputPath);
        string convertedPath = fullPath.Replace("\\", "/");

        Console.WriteLine("Original Path: " + fullPath);
        Console.WriteLine("Converted Path: " + convertedPath);
    }
}
