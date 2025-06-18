public abstract class SorterDecorator : ISorter
{
    protected ISorter _wrappee;

    public SorterDecorator(ISorter sorter)
    {
        _wrappee = sorter;
    }

    public virtual void Sort(int[] array)
    {
        _wrappee.Sort(array);
    }
}