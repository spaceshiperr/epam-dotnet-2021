using System;

namespace DelegateApp
{
    
    public interface ISorter
    {
        public int[,] Sort(Func<int[,], int[,]> strategy, int[,] array);
    }
   
    public class Sorter: ISorter
    {
        public int[,] Sort(Func<int[,], int[,]> strategy, int[,] array)
        {
            if (array is null)
                throw new ArgumentNullException(nameof(array) + ": the array cannot be null");

            if (strategy is null)
                throw new ArgumentNullException(nameof(strategy) + ": you must set the strategy");

            return strategy(array);
        }
    }
}
