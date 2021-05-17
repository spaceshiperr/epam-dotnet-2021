using NUnit.Framework;
using System;

namespace StringsConsoleApp.Tests
{
    [TestFixture]
    class WordAverageTests
    {
        [Test]
        public void GetAverageWordLength_InputIsNullOrEmpty_ThrowsArgumentNullException([Values(null, "")] string input)
        {
            Assert.That(() => WordAverage.GetAverageWordLength(input), Throws.ArgumentNullException);
        }

        [Test]
        public void GetAverageWordLength_InputIsOnlyPunctuation_Returns0(
            [Values(" ", ",", ".", ":", "\t", ";", "\"", "\'", "?", "!", "(", ")", "-", "\\", "/")] string input)
        {
            var result = WordAverage.GetAverageWordLength(input);
            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void GetAverageLength_InputIsNewLine_Returns0()
        {
            var result = WordAverage.GetAverageWordLength(Environment.NewLine);
            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        [TestCase("'this' is something..unusual!", 5.5d)]
        [TestCase("1234//123\t1234???!!!.......123", 3.5d)]
        [TestCase("Do you want some spaghetti?", 4.4d)]
        public void GetAverageLength_RegularInputs_ReturnsLength(string input, double expected)
        {
            var result = WordAverage.GetAverageWordLength(input);
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
