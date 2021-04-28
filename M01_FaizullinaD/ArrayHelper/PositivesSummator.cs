using System;

namespace ArrayHelper
{
    public class PositivesSummator
    {
        public decimal[][] Array { get; set; }

        public PositivesSummator(decimal[][] array)
        {
            Array = array;
        }

        public decimal SumPositives()
        {
            decimal sum = 0;

            foreach (var array in Array)
                foreach (var element in array)
                    if (element > 0)
                        sum += element;

            return sum;
        }
    }
}
