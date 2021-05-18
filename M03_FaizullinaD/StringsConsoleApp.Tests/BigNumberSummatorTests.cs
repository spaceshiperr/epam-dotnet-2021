using NUnit.Framework;
using System;

namespace StringsConsoleApp.Tests
{
    [TestFixture]
    public class BigNumberSummatorTests
    {
        private static readonly string[][] DataForOrdinaryNumbers =
        {
            new string[] {"1", "2", "3"},
            new string[] {"-1", "-1", "-2"},
            new string[] {"1", "-1", "0"},
            new string[] { "-18446744073709551615", "18446744073709551615", "0"},
            new string[] { "-18446744073709551615", "-18446744073709551615", "-36893488147419103230"},
        };

        private static readonly string[] dataForNullOrEmptyOrWhiteSpace = new string[] { null, "", " " };

        private static readonly string[] dataForOneChar = new string[] { "+", "-", ".", "!" };

        private static readonly string[] dataForContainsMisplacedSign =
            new string[] { "18446744-073709551615", "18446744073709551615-", "1+1", "123+" };

        private static readonly string[] dataForContainsNonDigits =
            new string[] { "1844d6744073709551615", "1844674407370955g1615", "12abc", "0o0", "l10" };

        private static readonly string[] dataForOneDigit = 
            new string[] { "9", "8", "7", "6", "5", "4", "3", "2", "1", "0"};

        private static readonly string[] expectedSumsForDataForOneDigit =
            new string[] { "10", "9", "8", "7", "6", "5", "4", "3", "2", "1" };

        private static readonly string[] dataForSignedNumbers =
            new string[] { "+1", "-1", "-9712398217237", "-12321", "+8127" };

        private static readonly string[] expectedSumsForDataForSignedNumbers =
            new string[] { "0", "-2", "-9712398217238", "-12322", "8126" };

        private static Random random;

        [OneTimeSetUp]
        public void SetUp()
        {
            random = new Random();
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            random = null;
        }

        [Test]
        [TestCaseSource(nameof(DataForOrdinaryNumbers))]
        public void Sum_FirstAndSecondAreOrdinary_ReturnsSum(string first, string second, string expected)
        {
            var result = BigNumberSummator.Sum(first, second);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [TestCaseSource(nameof(dataForNullOrEmptyOrWhiteSpace))]
        public void Sum_FirstNullOrEmptyOrWhiteSpace_ThrowsArgumentNullException(string first)
        {
            var second = random.Next().ToString();
            Assert.That(() => BigNumberSummator.Sum(first, second), Throws.ArgumentNullException);
        }

        [Test]
        [TestCaseSource(nameof(dataForNullOrEmptyOrWhiteSpace))]
        public void Sum_SecondIsNullOrEmptyOrWhiteSpace_ThrowsArgumentNullException(string second)
        {
            var first = random.Next().ToString();
            Assert.That(() => BigNumberSummator.Sum(first, second), Throws.ArgumentNullException);
        }

        [Test]
        [TestCaseSource(nameof(dataForOneChar))]
        public void Sum_FirstIsOneChar_ThrowsArgumentExcpetion(string first)
        {
            var second = random.Next().ToString();
            Assert.That(() => BigNumberSummator.Sum(first, second), Throws.ArgumentException);
        }

        [Test]
        [TestCaseSource(nameof(dataForOneChar))]
        public void Sum_SecondIsOneChar_ThrowsArgumentExcpetion(string second)
        {
            var first = random.Next().ToString();
            Assert.That(() => BigNumberSummator.Sum(first, second), Throws.ArgumentException);
        }

        [Test]
        [TestCaseSource(nameof(dataForContainsMisplacedSign))]
        public void Sum_FirstContainsMisplacedMinus_ThrowsArgumentException(string first)
        {
            var second = random.Next().ToString();
            Assert.That(() => BigNumberSummator.Sum(first, second), Throws.ArgumentException);
        }

        [Test]
        [TestCaseSource(nameof(dataForContainsMisplacedSign))]
        public void Sum_SecondContainsMisplacedMinus_ThrowsArgumentException(string second)
        {
            var first = random.Next().ToString();
            Assert.That(() => BigNumberSummator.Sum(first, second), Throws.ArgumentException);
        }

        [Test]
        [TestCaseSource(nameof(dataForContainsNonDigits))]
        public void Sum_FirstContainsNonDigits_ThrowsArgumentException(string first)
        {
            var second = random.Next().ToString();
            Assert.That(() => BigNumberSummator.Sum(first, second), Throws.ArgumentException);
        }

        [Test]
        [TestCaseSource(nameof(dataForContainsNonDigits))]
        public void Sum_SecondContainsNonDigits_ThrowsArgumentException(string second)
        {
            var first = random.Next().ToString();
            Assert.That(() => BigNumberSummator.Sum(first, second), Throws.ArgumentException);
        }

        [Test, Sequential]
        public void Sum_FirstIsOneDigit_ReturnsSum(
            [ValueSource(nameof(dataForOneDigit))] string first, 
            [ValueSource(nameof(expectedSumsForDataForOneDigit))] string expected)
        {
            var second = "1";
            var result = BigNumberSummator.Sum(first, second);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test, Sequential]
        public void Sum_SecondIsOneDigit_ReturnsSum(
            [ValueSource(nameof(dataForOneDigit))] string second,
            [ValueSource(nameof(expectedSumsForDataForOneDigit))] string expected)
        {
            var first = "1";
            var result = BigNumberSummator.Sum(first, second);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test, Sequential]
        public void Sum_FirstIsSignedNumber_ReturnsSum(
            [ValueSource(nameof(dataForSignedNumbers))] string first,
            [ValueSource(nameof(expectedSumsForDataForSignedNumbers))] string expected)
        {
            var second = "-1";
            var result = BigNumberSummator.Sum(first, second);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test, Sequential]
        public void Sum_SecondIsSignedNumber_ReturnsSum(
            [ValueSource(nameof(dataForSignedNumbers))] string second,
            [ValueSource(nameof(expectedSumsForDataForSignedNumbers))] string expected)
        {
            var first = "-1";
            var result = BigNumberSummator.Sum(first, second);

            Assert.That(result, Is.EqualTo(expected));
        }

    }
}
