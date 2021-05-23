using static DelegateApp.IBubbleSorter;


namespace DelegateApp
{
    public class BubbleSortMethods
    {
        private delegate int GetRowSortElement(int[,] array, int row);

        public int[,] Sort(int[,] array, OrderType order, ComparisonType comparison)
        {
            GetRowSortElement sortElement = comparison switch
            {
                ComparisonType.SumsOfRowElements => SumRowElements,
                ComparisonType.MaxRowElement => GetMinElement,
                ComparisonType.MinRowElement => GetMaxElement
            };

            var tupleArray = CreateTupleArray(array, sortElement);

            if (order.Equals(OrderType.Asc))
                BubbleSortAsc(ref tupleArray);

            if (order.Equals(OrderType.Desc))
                BubbleSortDesc(ref tupleArray);

            var sortedArray = GetSortedArray(array, tupleArray);

            return sortedArray;
        }

        private int SumRowElements(int[,] array, int row)
        {
            int sum = 0;
            int n = array.GetLength(1);

            for (int i = 0; i < n; i++)
                sum += array[row, i];

            return sum;
        }

        private int GetMaxElement(int[,] array, int row)
        {
            int max = array[row, 0];
            int n = array.GetLength(1);

            for (int i = 0; i < n; i++)
                if (array[row, i] > max)
                    max = array[row, i];

            return max;
        }

        private int GetMinElement(int[,] array, int row)
        {
            int min = array[row, 0];
            int n = array.GetLength(1);

            for (int i = 0; i < n; i++)
                if (array[row, i] < min)
                    min = array[row, i];

            return min;
        }

        private void BubbleSortAsc(ref (int Value, int Row)[] array)
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

        private int[,] GetSortedArray(int[,] array, (int Value, int Row)[] tupleArray)
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

        private void BubbleSortDesc(ref (int Value, int Row)[] array)
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

        private (int, int)[] CreateTupleArray(int[,] array, GetRowSortElement getElement)
        {
            var rowCount = array.GetLength(0);
            var tupleArray = new (int Value, int Row)[rowCount];

            for (int i = 0; i < rowCount; i++)
            {
                var sum = getElement(array, i);
                tupleArray[i].Value = sum;
                tupleArray[i].Row = i;
            }

            return tupleArray;
        }
    }
}
