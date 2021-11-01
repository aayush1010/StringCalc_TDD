using NUnit.Framework;
using System;

namespace TDD
{
    [TestFixture]
    public class StringCalculatorTest
    {
        [TestCase("", 0)]
        [TestCase("1", 1)]
        [TestCase("1,2", 3)]
        public void AddTwoNumbersTest(string input, int output)
        {
            var calculator = new StringCalculator();

            var result = calculator.Calculate(input);

            Assert.AreEqual(output, result);
        }

        [TestCase("", 0)]
        [TestCase("1", 1)]
        [TestCase("1,2,3", 6)]
        public void AddUnknownAmoutNumbersTest(string input, int output)
        {
            var calculator = new StringCalculator();

            var result = calculator.Calculate(input);

            Assert.AreEqual(output, result);
        }

        [TestCase("1\n2,3", 6)]
        public void AddUnknownAmoutNumbersWithDiffDelimitersTest(string input, int output)
        {
            var calculator = new StringCalculator();

            var result = calculator.Calculate(input);

            Assert.AreEqual(output, result);
        }


        [TestCase("//;\n1;2", 3)]
        public void AddUnknownAmoutNumbersWithDiffDefaultDelimitersTest(string input, int output)
        {
            var calculator = new StringCalculator();

            var result = calculator.Calculate(input);

            Assert.AreEqual(output, result);
        }

        [TestCase("1, 2, -1", "-1")]
        public void NegativeNotAllowedTest(string input, string output)
        {
            var calculator = new StringCalculator();


            Assert.That(() => calculator.Calculate(input), Throws.TypeOf<Exception>().With.Message.EqualTo("Negatives Not Allowed" + output));
        }

        [TestCase("2,1001", 2)]
        public void NumberGreaterThanThousandTest(string input, int output)
        {
            var calculator = new StringCalculator();
            var result = calculator.Calculate(input);

            Assert.AreEqual(output, result);

        }

        [TestCase("//[***]\n1***2***3", 6)]
        public void AnyLengthDelimiterTest(string input, int output)
        {
            var calculator = new StringCalculator();
            var result = calculator.Calculate(input);

            Assert.AreEqual(output, result);

        }

        [TestCase("//[A][b]\n1A2b3", 6)]
        public void add_multipledelimiters_allused(string input, int output)
        {
            var calculator = new StringCalculator();
            var result = calculator.Calculate(input);

            Assert.AreEqual(output, result);

        }
    }
}
