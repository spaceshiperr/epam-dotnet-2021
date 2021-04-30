using System;

namespace ArrayHelper
{
    public class ArraySorter
    {
        public decimal[] Array { get; set; }

        public ArraySorter(decimal[] array)
        {
            if (array is null)
            {
                throw new ArgumentNullException();
            }
            
            Array = array;
        }

        public void BubbleSortAsc()
        {
            int n = Array.Length;

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (Array[j] > Array[j + 1])
                    {
                        var temp = Array[j];
                        Array[j] = Array[j + 1];
                        Array[j + 1] = temp;
                    }
                }
            }
        }

        public void BubbleSortDesc()
        {
            int n = Array.Length;

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (Array[j] < Array[j + 1])
                    {
                        var temp = Array[j];
                        Array[j] = Array[j + 1];
                        Array[j + 1] = temp;
                    }
                }
            }
        }
    }
}
