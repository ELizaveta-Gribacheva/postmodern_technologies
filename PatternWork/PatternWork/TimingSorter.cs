
using System.Diagnostics;

public class TimingSorter : SorterDecorator
{
    public TimingSorter(ISorter sorter) : base(sorter) { }

    public override void Sort(int[] array)
    {
        var stopwatch = Stopwatch.StartNew();
        base.Sort(array);
        stopwatch.Stop();
        Console.WriteLine($"Час сортування: {stopwatch.ElapsedMilliseconds} мс");
    }
}