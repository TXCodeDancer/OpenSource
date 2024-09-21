using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the path of the file or directory:");
        string? inputPath = Console.ReadLine();

        if (string.IsNullOrEmpty(inputPath))
        {
            Console.WriteLine("Invalid input. Please enter a valid path.");
            return;
        }

        string fullPath = Path.GetFullPath(inputPath);
        string convertedPath = fullPath.Replace("\\", "/");

        Console.WriteLine("Original Path: " + fullPath);
        Console.WriteLine("Converted Path: " + convertedPath);
    }
}
