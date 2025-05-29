using NUnit.Framework;
using System;
using System.IO;
using Laboratory;

namespace Laboratory.test
{
    public class Tests
    {
        [Test]
        public void TestBubbleSort()
        {
            int[] input = { 4, 2, 9, 6, 5, 1 };
            int[] expected = { 1, 2, 4, 5, 6, 9 };

            Program.BubbleSort(input);
            Assert.That(input, Is.EqualTo(expected));
        }

        [Test]
        public void TestBubbleSort_WithDuplicates()
        {
            int[] input = { 4, 2, 76, 2, 4, 1, 1 };
            int[] expected = { 1, 1, 2, 2, 4, 4, 76 };

            Program.BubbleSort(input);

            Assert.That(input, Is.EqualTo(expected));
        }

        [Test]
        public void TestBubbleSort_SingleElement()
        {
            int[] input = { 7 };
            int[] expected = { 7 };

            Program.BubbleSort(input);

            Assert.That(input, Is.EqualTo(expected));
        }

        [Test]
        public void TestBubbleSort_NegativeNumbers()
        {
            int[] input = { -3, -1, -7, -2 };
            int[] expected = { -7, -3, -2, -1 };

            Program.BubbleSort(input);

            Assert.That(input, Is.EqualTo(expected));
        }

        [Test]
        public void TestMain_ValidInput()
        {
            var input = new StringReader("4 2 9 6 5 1");
            var writer = new StringWriter();
            var error = new StringWriter();

            Console.SetIn(input);
            Console.SetOut(writer);
            Console.SetError(error);

            int code = Program.Main(Array.Empty<string>());
            string output = writer.ToString().Trim();

            Assert.That(code, Is.EqualTo(0));
            Assert.That(output, Is.EqualTo("1 2 4 5 6 9"));
        }

        [Test]
        public void TestMain_EmptyInput()
        {
            var input = new StringReader("");
            var error = new StringWriter();

            Console.SetIn(input);
            Console.SetOut(TextWriter.Null);
            Console.SetError(error);

            int code = Program.Main(Array.Empty<string>());
            Assert.That(code, Is.EqualTo(1));
            Assert.That(error.ToString(), Does.Contain("порожній"));
        }

        [Test]
        public void TestMain_WhitespaceInput_ReturnsOne()
        {
            var input = new StringReader("     ");
            var error = new StringWriter();

            Console.SetIn(input);
            Console.SetOut(TextWriter.Null);
            Console.SetError(error);

            int code = Program.Main(Array.Empty<string>());
            Assert.That(code, Is.EqualTo(1));
        }

        [Test]
        public void TestMain_InvalidInput_ReturnsTwo()
        {
            var input = new StringReader("1 // 67");
            var error = new StringWriter();

            Console.SetIn(input);
            Console.SetOut(TextWriter.Null);
            Console.SetError(error);

            int code = Program.Main(Array.Empty<string>());
            Assert.That(code, Is.EqualTo(2));
            Assert.That(error.ToString(), Does.Contain("нечислове"));
        }

        [Test]
        
        public void TestMain_AllSameNumbers()
        {
            var input = new StringReader("3 3 3 3");
            var writer = new StringWriter();

            Console.SetIn(input);
            Console.SetOut(writer);
            Console.SetError(TextWriter.Null);

            int code = Program.Main(Array.Empty<string>());
            Assert.That(code, Is.EqualTo(0));
            Assert.That(writer.ToString().Trim(), Is.EqualTo("3 3 3 3"));
        }
    }
}
