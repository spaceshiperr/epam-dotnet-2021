using System;

namespace ArrayHelper
{
    public class PositivesSummator
    {
        public decimal[,] Array { get; set; }

        public PositivesSummator(decimal[,] array)
        {
            if (array is null)
            {
                throw new ArgumentNullException();
            }

            Array = array;
        }

        public decimal SumPositives()
        {
            decimal sum = 0;

            foreach (var element in Array)
            {
                if (element > 0)
                {
                    sum += element;
                }
            }

            return sum;
        }
    }
}
