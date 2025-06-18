// SorterTests.cs

namespace PatternWorkTest
{
    [TestFixture]
    public class SorterTests
    {
        [Test]
        public void BubbleSorter_SortsCorrectly()
        {
            int[] input = { 5, 3, 8, 1, 45, 0};
            int[] expected = { 0, 1, 3, 5, 8, 45 };

            ISorter sorter = new BubbleSorter();
            sorter.Sort(input);

            Assert.That(input, Is.EqualTo(expected));
        }

        [Test]
        public void LoggingSorter_AddsLoggingMessages()
        {
            int[] input = {99, 90 };
            var output = new StringWriter();
            Console.SetOut(output);

            ISorter sorter = new LoggingSorter(new BubbleSorter());
            sorter.Sort(input);

            string log = output.ToString();
            Assert.That(log.Contains("Початок сортування"), Is.True);
            Assert.That(log.Contains("Сортування завершено"), Is.True);
        }

        [Test]
        public void TimingSorter_MeasuresExecutionTime()
        {
            int[] input = { 99 };
            var output = new StringWriter();
            Console.SetOut(output);

            ISorter sorter = new TimingSorter(new BubbleSorter());
            sorter.Sort(input);

            string log = output.ToString();
            Assert.That(log.Contains("Час сортування"), Is.True);
        }

        [Test]
        public void CombinedDecorators_WorkTogetherCorrectly()
        {
            int[] input = { 99 };
            int[] expected = { 99 };
            var output = new StringWriter();
            Console.SetOut(output);

            ISorter sorter = new LoggingSorter(new TimingSorter(new BubbleSorter()));
            sorter.Sort(input);

            Assert.That(input, Is.EqualTo(expected));
            string log = output.ToString();
            Assert.That(log.Contains("Початок сортування"), Is.True);
            Assert.That(log.Contains("Час сортування"), Is.True);
            Assert.That(log.Contains("Сортування завершено"), Is.True);
        }
    }
}