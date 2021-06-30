using System;
using static DelegateApp.Sorter;

namespace DelegateApp
{
    public static class BubbleSorter
    {
        public enum OrderType
        {
            Asc,
            Desc
        }

        public enum ComparisonType
        {
            SumsOfRowElements,
            MaxRowElement,
            MinRowElement
        }

        private delegate int RowSortDelegate(int[,] array, int row);
        public static StrategyDelegate GetSortStrategy(ComparisonType comparison, OrderType order)
        {
            return comparison switch
            {
                ComparisonType.SumsOfRowElements when
                    order.Equals(OrderType.Asc) => BubbleSortByRowSumsAsc,
                ComparisonType.SumsOfRowElements when
                    order.Equals(OrderType.Desc) => BubbleSortByRowSumsDesc,
                ComparisonType.MaxRowElement when
                    order.Equals(OrderType.Asc) => BubbleSortByMaxRowElementAsc,
                ComparisonType.MaxRowElement when
                    order.Equals(OrderType.Desc) => BubbleSortByMaxRowElementDesc,
                ComparisonType.MinRowElement when
                    order.Equals(OrderType.Asc) => BubbleSortByMinRowElementAsc,
                ComparisonType.MinRowElement when
                    order.Equals(OrderType.Desc) => BubbleSortByMinRowElementDesc,
                _ => throw new Exception(nameof(order) + ", " + nameof(comparison))
            };
        }

        public static int[,] BubbleSortByRowSumsAsc(int[,] array)
        {
            var tupleArray = CreateTupleArray(array, SumRowElements);

            BubbleSortAsc(ref tupleArray);
            
            return GetSortedArray(array, tupleArray);
        }   

        public static int[,] BubbleSortByRowSumsDesc(int[,] array)
        {
            var tupleArray = CreateTupleArray(array, SumRowElements);

            BubbleSortDesc(ref tupleArray);
            
            return GetSortedArray(array, tupleArray);
        }

        public static int[,] BubbleSortByMaxRowElementAsc(int[,] array)
        {
            var tupleArray = CreateTupleArray(array, GetMaxElement);
            
            BubbleSortAsc(ref tupleArray);

            return GetSortedArray(array, tupleArray);
        }

        public static int[,] BubbleSortByMaxRowElementDesc(int[,] array)
        {
            var tupleArray = CreateTupleArray(array, GetMaxElement);
            
            BubbleSortDesc(ref tupleArray);

            return GetSortedArray(array, tupleArray);
        }

        public static int[,] BubbleSortByMinRowElementAsc(int[,] array)
        {
            var tupleArray = CreateTupleArray(array, GetMinElement);

            BubbleSortAsc(ref tupleArray);

            return GetSortedArray(array, tupleArray);
        }

        public static int[,] BubbleSortByMinRowElementDesc(int[,] array)
        {
            var tupleArray = CreateTupleArray(array, GetMinElement);

            BubbleSortDesc(ref tupleArray);

            return GetSortedArray(array, tupleArray);
        }

        private static int SumRowElements(int[,] array, int row)
        {
            int sum = 0;
            int n = array.GetLength(1);

            for (int i = 0; i < n; i++)
                sum += array[row, i];

            return sum;
        }

        private static int GetMaxElement(int[,] array, int row)
        {
            int max = array[row, 0];
            int n = array.GetLength(1);

            for (int i = 0; i < n; i++)
                if (array[row, i] > max)
                    max = array[row, i];

            return max;
        }

        private static int GetMinElement(int[,] array, int row)
        {
            int min = array[row, 0];
            int n = array.GetLength(1);

            for (int i = 0; i < n; i++)
                if (array[row, i] < min)
                    min = array[row, i];

            return min;
        }

        private static (int, int)[] CreateTupleArray(int[,] array, RowSortDelegate getElement)
        {
            var rowCount = array.GetLength(0);
            var tupleArray = new (int Value, int Row)[rowCount];

            for (int i = 0; i < rowCount; i++)
            {
                var element = getElement(array, i);
                tupleArray[i].Value = element;
                tupleArray[i].Row = i;
            }

            return tupleArray;
        }

        private static void BubbleSortAsc(ref (int Value, int Row)[] array)
        {
            int n = array.Length;

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (array[j].Value > array[j + 1].Value)
                    {
                        var tempValue = array[j].Value;
                        var tempIndex = array[j].Row;

                        array[j].Value = array[j + 1].Value;
                        array[j].Row = array[j + 1].Row;

                        array[j + 1].Value = tempValue;
                        array[j + 1].Row = tempIndex;
                    }
                }
            }
        }

        private static void BubbleSortDesc(ref (int Value, int Row)[] array)
        {
            int n = array.Length;

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (array[j].Value < array[j + 1].Value)
                    {
                        var tempValue = array[j].Value;
                        var tempIndex = array[j].Row;

                        array[j].Value = array[j + 1].Value;
                        array[j].Row = array[j + 1].Row;

                        array[j + 1].Value = tempValue;
                        array[j + 1].Row = tempIndex;
                    }
                }
            }
        }

        private static int[,] GetSortedArray(int[,] array, (int Value, int Row)[] tupleArray)
        {
            var rowCount = array.GetLength(0);
            var colCount = array.GetLength(1);
            var newArray = new int[rowCount, colCount];

            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < colCount; j++)
                {
                    newArray[i, j] = array[tupleArray[i].Row, j];
                }
            }

            return newArray;
        }
    }
}
