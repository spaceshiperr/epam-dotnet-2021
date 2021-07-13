using NUnit.Framework;

namespace RPNCalculator.Tests
{
    [TestFixture]
    class RPNTests
    {
        [Test]
        [TestCase("1 +")]
        [TestCase("23 2 1 -")]
        [TestCase("nv jbb ll1")]
        [TestCase("7 8 %")]
        public void Calculate_InputIsInvalid(string input)
        {
            var rpn = new RPN();
            Assert.That(() => rpn.Calculate(input), Throws.InvalidOperationException);
        }

        [Test]
        public void Calculate_InputIsEmpty_Returns0()
        {
            var input = "0";
            var expected = 0;

            var rpn = new RPN();
            var result = rpn.Calculate(input);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [TestCase("9 12 40 * 8 / - 13 18 + -", -82)]
        [TestCase("12 2 +", 14)]
        [TestCase("23 5 -", 18)]
        [TestCase("5 7 *", 35)]
        [TestCase("100 10 /", 10)]
        public void Calculate_InputIsCorrect(string input, double expected)
        {
            var rpn = new RPN();
            var result = rpn.Calculate(input);

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
