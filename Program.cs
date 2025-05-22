using CSV_Enumerable.Models;
using CSV_Enumerable.Services;

namespace CSV_Enumerable;

internal class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Press ESC to exit or tab to use example csv or any other key to enter your path");
            ConsoleKeyInfo keyInfo = Console.ReadKey(false);
            if (keyInfo.Key == ConsoleKey.Escape)
            {
                break;
            }
            string? path = "Pets_and_Owners.csv";
            if (keyInfo.Key != ConsoleKey.Tab)
            {
                Console.WriteLine("Enter path to the csv");
                path = Console.ReadLine();
                if (path == null)
                {
                    Console.WriteLine("Path cannot be null");
                    continue;
                }
            }

            Console.WriteLine();

            try
            {
                var csv = new CsvEnumerable<Pet>(path);
                foreach (var item in csv)
                {
                    Console.WriteLine(item.ToString());
                }
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Wrong path!");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
