public class Program
{
    public static int Main(string[] args)
    {
        try
        {
            string? input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.Error.WriteLine("порожній ввід");
                return 1;
            }

            int[] numbers = input
                .Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(s => int.Parse(s))
                .ToArray();

            ISorter sorter = new LoggingSorter(new TimingSorter(new BubbleSorter()));
            sorter.Sort(numbers);

            Console.WriteLine(string.Join(" ", numbers));
            return 0;
        }
        catch (FormatException)
        {
            Console.Error.WriteLine("нечислове значення.");
            return 2;
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"помилка: {ex.Message}");
            return 3;
        }
    }
}