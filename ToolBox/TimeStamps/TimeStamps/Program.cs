Console.WriteLine("Enter DateTime arguments: ");
var input = Console.ReadLine();
Console.WriteLine();

if (input == null) { throw new ArgumentNullException(input); }

var arguments = input.Trim().Split(' ').Where(x => x != "").ToArray();

var doubles = new List<double>();
var longs = new List<long>();
var ints = new List<int>();
foreach (var argument in arguments)
{
    try
    {
        if (arguments.Length == 1)
        {
            try
            {
                longs.Add(Convert.ToInt64(argument));
            }
            catch (Exception)
            {
                doubles.Add(Convert.ToDouble(argument));
            }
        }
        else
        {
            ints.Add(Convert.ToInt32(argument));
        }
    }
    catch (FormatException e)
    {
        Console.WriteLine(e.Message);
        Environment.Exit(1);
    }
}

try
{
    var datetime = new DateTime();
    switch (arguments.Length)
    {
        case 1:
            if (longs.Any())
            {
                datetime = new DateTime(longs[0], DateTimeKind.Utc);
            }
            else
            {
                datetime = DateTime.FromOADate(doubles[0]);
            }
            break;

        case 3:
            datetime = new DateTime(ints[0], ints[1], ints[2]);
            break;

        case 6:
            datetime = new DateTime(ints[0], ints[1], ints[2], ints[3], ints[4], ints[5]);
            break;

        case 7:
            datetime = new DateTime(ints[0], ints[1], ints[2], ints[3], ints[4], ints[5], ints[6]);
            break;

        case 8:
            datetime = new DateTime(ints[0], ints[1], ints[2], ints[3], ints[4], ints[5], ints[6], ints[7]);
            break;

        default:
            Console.WriteLine($"Invalid number of arguments: {arguments.Length}. Requires 1, 3, 6, 7, or 8 arguments.");
            Environment.Exit(2);
            break;
    }
    Console.WriteLine($"Date Time: {datetime.ToLocalTime():yyyy.MM.dd HH:mm:ss.fff}");
    Console.WriteLine($"    Ticks: {datetime.ToLocalTime().Ticks}");
    Console.WriteLine($"1900 Time: {datetime.ToLocalTime().ToOADate()}");
    Console.WriteLine();
    Console.WriteLine($"Date Time UTC: {datetime.ToUniversalTime():yyyy.MM.dd HH:mm:ss.fff}");
    Console.WriteLine($"    Ticks UTC: {datetime.ToUniversalTime().Ticks}");
    Console.WriteLine($"1900 Time UTC: {datetime.ToUniversalTime().ToOADate()}");
    Console.WriteLine();
    Console.WriteLine($"Date Time UTC -1: {datetime.ToUniversalTime().AddHours(-1):yyyy.MM.dd HH:mm:ss.fff}");
    Console.WriteLine($"    Ticks UTC -1: {datetime.ToUniversalTime().AddHours(-1).Ticks}");
    Console.WriteLine($"1900 Time UTC -1: {datetime.ToUniversalTime().AddHours(-1).ToOADate()}");
    Console.WriteLine();
}
catch (ArgumentOutOfRangeException e)
{
    Console.WriteLine(e.Message);
    Environment.Exit(3);
}
catch (ArgumentException e)
{
    Console.WriteLine(e.Message);
    Environment.Exit(4);
}
