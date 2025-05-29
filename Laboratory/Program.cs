using System;
using System.Linq;

namespace Laboratory
{
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

                BubbleSort(numbers);

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

        public static void BubbleSort(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        (array[j], array[j + 1]) = (array[j + 1], array[j]);
                    }
                }
            }
        }
    }
}