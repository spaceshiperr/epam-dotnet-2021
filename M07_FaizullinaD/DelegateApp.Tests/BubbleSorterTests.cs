using System;
using NUnit.Framework;
using static DelegateApp.BubbleSorter;

namespace DelegateApp.Tests
{
    [TestFixture]
    public class SorterTests
    {
        private Sorter sorter;

        static object[] DataArray =
        {
            new int[3, 5]
            {
                { 2, 1, 4, 6, 0 }, //sum 13, max 6, min 0
                { 4, -1, 5, 2, -6 }, // sum 4, max 5, min -6
                { 0, 9, 2, -3, 7 } //sum 15, max 9, min -3
            }
        };
        
        [SetUp]
        public void SetUp()
        {
            sorter = new Sorter();
        }

        [TearDown]
        public void TearDown()
        {
            sorter = null;
        }

        [Test]
        public void Sort_ArrayIsNull_ThrowsArgumentNullException()
        {
            var order = OrderType.Asc;
            var comparison = ComparisonType.MaxRowElement;
            int[,] array = null;

            var strategy = GetSortStrategy(comparison, order);

            Assert.That(() => sorter.Sort(strategy, array), Throws.ArgumentNullException);
        }

        [Test]
        public void Sort_StategyIsNull_ThrowsArgumentNullException()
        {
            int[,] array = { { 1, 2, 3 } };

            Assert.That(() => sorter.Sort(null, array), Throws.ArgumentNullException);
        }

        [Test]
        [TestCaseSource(nameof(DataArray))]
        public void Sort_BubbleSortBySumsOfRowElementsAsc_ReturnsSortedArray(int[,] array)
        {
            var order = OrderType.Asc;
            var comparison = ComparisonType.SumsOfRowElements;
            int[,] expected =
            {
                {4, -1, 5, 2, -6 },
                { 2, 1, 4, 6, 0 },
                {0, 9, 2, -3, 7 }
            };

            var strategy = GetSortStrategy(comparison, order);
            var result = sorter.Sort(strategy, array);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [TestCaseSource(nameof(DataArray))]
        public void Sort_BubbleSortBySumsOfRowElementsDesc_ReturnsSortedArray(int[,] array)
        {
            var order = OrderType.Desc;
            var comparison = ComparisonType.SumsOfRowElements;
            int[,] expected =
            {
                {0, 9, 2, -3, 7 },
                { 2, 1, 4, 6, 0 },
                {4, -1, 5, 2, -6 }
            };

            var strategy = GetSortStrategy(comparison, order);
            var result = sorter.Sort(strategy, array);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [TestCaseSource(nameof(DataArray))]
        public void Sort_BubbleSortByMaxRowElementAsc_ReturnsSortedArray(int[,] array)
        {
            var order = OrderType.Asc;
            var comparison = ComparisonType.MaxRowElement;
            int[,] expected =
            {
                {4, -1, 5, 2, -6 },
                { 2, 1, 4, 6, 0 },
                {0, 9, 2, -3, 7 },
            };

            var strategy = GetSortStrategy(comparison, order);
            var result = sorter.Sort(strategy, array);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [TestCaseSource(nameof(DataArray))]
        public void Sort_BubbleSortByMaxRowElementDesc_ReturnsSortedArray(int[,] array)
        {
            var order = OrderType.Desc;
            var comparison = ComparisonType.MaxRowElement;
            int[,] expected =
            {
                {0, 9, 2, -3, 7 },
                { 2, 1, 4, 6, 0 },
                {4, -1, 5, 2, -6 }
            };

            var strategy = GetSortStrategy(comparison, order);
            var result = sorter.Sort(strategy, array);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [TestCaseSource(nameof(DataArray))]
        public void Sort_BubbleSortByMinRowElementAsc_ReturnsSortedArray(int[,] array)
        {
            var order = OrderType.Asc;
            var comparison = ComparisonType.MinRowElement;
            int[,] expected =
            {
                {4, -1, 5, 2, -6 },
                {0, 9, 2, -3, 7 },
                { 2, 1, 4, 6, 0 }
            };

            var strategy = GetSortStrategy(comparison, order);
            var result = sorter.Sort(strategy, array);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [TestCaseSource(nameof(DataArray))]
        public void Sort_BubbleSortByMinRowElementDesc_ReturnsSortedArray(int[,] array)
        {
            var order = OrderType.Desc;
            var comparison = ComparisonType.MinRowElement;
            int[,] expected =
            {
                { 2, 1, 4, 6, 0 },
                {0, 9, 2, -3, 7 },
                {4, -1, 5, 2, -6 },
            };

            var strategy = GetSortStrategy(comparison, order);
            var result = sorter.Sort(strategy, array);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void Sort_BubbleArrayHasOneRow_ReturnsSameArray()
        {
            var order = OrderType.Desc;
            var comparison = ComparisonType.MinRowElement;
            int[,] array = { { 1, 2, 3 } };

            var strategy = GetSortStrategy(comparison, order);
            var result = sorter.Sort(strategy, array);

            Assert.That(result, Is.EqualTo(array));
        }
    }
}
