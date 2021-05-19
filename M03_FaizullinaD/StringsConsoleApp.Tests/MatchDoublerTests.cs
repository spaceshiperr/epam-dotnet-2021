using NUnit.Framework;

namespace StringsConsoleApp.Tests
{
    [TestFixture]
    class MatchDoublerTests
    {
        [Test]
        public void DoubleMatchedChars_TextIsNullOrEmptyOrWhiteSpace_ThrowsArgumentNullException(
            [Values(null, "", " ")] string text)
        {
            var charsToDouble = "test chars";

            Assert.That(() => MatchDoubler.DoubleMatchedChars(text, charsToDouble),
                    Throws.ArgumentNullException);
        }

        [Test]
        public void DoubleMatchedChars_CharsToDoubleIsNullOrEmptyOrWhiteSpace_ThrowsArgumentNullException(
            [Values(null, "", " ")] string charsToDouble)
        {
            string text = "test text";

            Assert.That(() => MatchDoubler.DoubleMatchedChars(text, charsToDouble),
                    Throws.ArgumentNullException);
        }

        [Test]
        [TestCase("hello world", "lol", "helllloo woorlld")]
        [TestCase("omg i love shrek", "lol kek", "oomg i lloovee shreekk")]
        public void DoubleMatchedChars_RepeatingCharsInCharsToDouble_ReturnsCharsDoubledOnce(
            string text, string charsToDouble, string expected)
        {
            var result = MatchDoubler.DoubleMatchedChars(text, charsToDouble);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [TestCase("how about now?", "oh..mb", "hhoow abboout noow?")]
        [TestCase("some random text", "random", "soomme rraannddoomm text")]
        public void DoubleMatchedChars_RegularInput_ReturnsTextWithDoubledMatchedChars(
            string text, string charsToDouble, string expected)
        {
            var result = MatchDoubler.DoubleMatchedChars(text, charsToDouble);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void DoubleMatchedChars_NoMatchingCharsInText_ReturnsUnchangedText()
        {
            var text = "i am a very interesting text";
            var charsToDouble = "12 23 4567";

            var result = MatchDoubler.DoubleMatchedChars(text, charsToDouble);

            Assert.That(result, Is.EqualTo(text));
        }
    }
}
