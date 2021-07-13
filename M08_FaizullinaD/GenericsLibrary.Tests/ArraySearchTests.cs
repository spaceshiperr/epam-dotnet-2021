using System;
using NUnit.Framework;
using static GenericsLibrary.ArraySearch;

namespace GenericsLibrary.Tests
{
    [TestFixture]
    public class ArraySearchTests
    {
        [Test]
        public void BinarySearch_ArrayIsNull_ThrowsArgumentNullException()
        {
            int[] array = null;
            int x = 0;

            Assert.That(() => BinarySearch(array, x), Throws.ArgumentNullException);
        }

        [Test]
        [TestCase(new double[] { 1.1 }, 1.1, 0)]
        [TestCase(new int[] { 12 }, 12, 0)]
        public void BinarySearch_ArrayHasOneItemX_Returns0<T>(T[] array, T x, int expected)
            where T : IComparable<T>
        {
            var result = BinarySearch(array, x);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(new long[] { 2, 6, 9, 11 }, 90, -1)]
        [TestCase(new double[] { 0.0, 1.1, 404.5}, 9.86, -1)]
        public void BinarySearch_XIsNotInArray_ReturnsMinus1<T>(T[] array, T x, int expected)
            where T : IComparable<T>
        {
            var result = BinarySearch(array, x);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(new int[] { 1, 40, 41, 100 }, 1, 0)]
        public void BinarySearch_XIsFirst_Returns0<T>(T[] array, T x, int expected)
            where T : IComparable<T>
        {
            var result = BinarySearch(array, x);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(new double[] { 100.1, 200.2, 300.3 }, 300.3, 2)]
        public void BinarySearch_XIsLast_ReturnsLastIndex<T>(T[] array, T x, int expected)
            where T : IComparable<T>
        {
            var result = BinarySearch(array, x);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(new float[] { 1.2f, 4.5f, 5.9f, 6.0f, 7.3f }, 5.9f, 2)]
        public void BinarySearch_XIsInTheMiddle_ReturnsMiddleIndex<T>(T[] array, T x, int expected)
            where T : IComparable<T>
        {
            var result = BinarySearch(array, x);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(new int[] { 263, 1053, 6688, 105901, 106901 }, 1053, 1)]
        [TestCase(new int[] { 69, 1, 5, 23, 6, 123, 3 }, 3, 6)]
        public void BinarySearch_XIsInArray_ReturnsIndex<T>(T[] array, T x, int expected)
            where T : IComparable<T>
        {
            var result = BinarySearch(array, x);

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
