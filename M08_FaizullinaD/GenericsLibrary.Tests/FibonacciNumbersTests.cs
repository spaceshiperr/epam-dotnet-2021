using System.Linq;
using NUnit.Framework;
using static GenericsLibrary.FibonacciNumbers;
using System.Numerics;

namespace GenericsLibrary.Tests
{
    [TestFixture]
    public class FibonacciNumbersTests
    {
        [Test]
        public void GetNumbers_TakeFirst10_ReturnsIEnumerableOfFirst10()
        {
            BigInteger[] expected = { 1, 1, 2, 3, 5, 8, 13, 21, 34, 55 };

            var result = GetNumbers().Take(10).ToArray();

            Assert.That(result, Is.EquivalentTo(expected));
        }
    }
}
