using NUnit.Framework;

namespace StringsConsoleApp.Tests
{
    [TestFixture]
    class SentenceReverserTests
    {
        [Test]
        public void ReverseSentence_InputIsNullOrEmptyOrWhiteSpace_ThrowsArgumentNullException(
            [Values(null, "", " ")] string input)
        {
            Assert.That(() => SentenceReverser.ReverseSentence(input), Throws.ArgumentNullException);
        }

        [Test]
        public void ReverseSentence_InputIsPalindromic_ReturnsInput()
        {
            var input = "is it crazy how saying sentences backwards " +
                        "creates backwards sentences saying how crazy it is";

            var result = SentenceReverser.ReverseSentence(input);

            Assert.That(result, Is.EqualTo(input));
        }

        [Test]
        [TestCase("The greatest victory is that which requires no battle", 
                  "battle no requires which that is victory greatest The")]
        public void ReverseSentence_RegularInput_ReturnsReversedSentence(string input, string expected)
        {
            var result = SentenceReverser.ReverseSentence(input);

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
