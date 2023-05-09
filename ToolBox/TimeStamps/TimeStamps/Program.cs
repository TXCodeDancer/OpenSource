namespace TimeStamps;

internal static class Program
{
    private static void Main()
    {
        Console.WriteLine("Enter DateTime arguments: ");
        var input = Console.ReadLine();
        if (input == null) { throw new ArgumentNullException(input); }

        var arguments = input.Split(' ');

        Console.WriteLine($"Number of argument = {arguments.Length}");

        foreach (var argument in arguments)
        {
            Console.WriteLine($"{argument}");
        }
    }
}
