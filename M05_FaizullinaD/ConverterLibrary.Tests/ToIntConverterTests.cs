using NUnit.Framework;
using System;
using Microsoft.Extensions.Logging;

namespace ConverterLibrary.Tests
{
    [TestFixture]
    public class ToIntConverterTests
    {
        private ToIntConverter _converter;
        
        [OneTimeSetUp]
        public void SetUp()
        {
            var factory = new LoggerFactory();
            var logger = new Logger<ToIntConverter>(factory);
            _converter = new ToIntConverter(logger);
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            _converter = null;
        }
        
        [Test]
        public void ToInt_StrIsNullOrEmptyOrWhiteSpace_ThrowsArgumentNullException(
            [Values(null, "", " ")] string str)
        {
            Assert.That(() => _converter.ToInt(str), Throws.ArgumentNullException);
        }

        [Test]
        [TestCase("text")]
        [TestCase("*.!!/")]
        [TestCase("123.5")]
        public void ToInt_StrContainsNonDigits_ThrowsArgumentException(string str)
        {
            Assert.That(() => _converter.ToInt(str), Throws.ArgumentException);
        }

        [Test]
        [TestCase("2147483648")]
        [TestCase("-2147483649")]
        [TestCase("999999999999999999")]
        public void ToInt_StrIsOutOfIntRange_ThrowsArgumentOutOfRangeException(string str)
        {
            Assert.That(() => _converter.ToInt(str), Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        [TestCase("0", 0)]
        [TestCase("780", 780)]
        [TestCase("-25", -25)]
        [TestCase("2147483646", 2147483646)]
        [TestCase("-2147483647", -2147483647)]
        public void ToInt_StrIsRegularNumber_ReturnsInt(string str, int expected)
        {
            var result = _converter.ToInt(str);

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
