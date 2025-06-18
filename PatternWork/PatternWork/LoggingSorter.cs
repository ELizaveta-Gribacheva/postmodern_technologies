public class LoggingSorter : SorterDecorator
{
    public LoggingSorter(ISorter sorter) : base(sorter) { }

    public override void Sort(int[] array)
    {
        Console.WriteLine("Початок сортування...");
        base.Sort(array);
        Console.WriteLine("Сортування завершено.");
    }
}