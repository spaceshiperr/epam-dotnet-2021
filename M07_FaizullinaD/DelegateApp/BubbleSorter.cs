using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DelegateApp.IBubbleSorter;

namespace DelegateApp
{
    public interface IBubbleSorter
    {
        enum OrderType
        {
            Asc,
            Desc
        }

        enum ComparisonType
        {
            SumsOfRowElements,
            MaxRowElement,
            MinRowElement
        }

        int[,] BubbleSort(int[,] array, OrderType order, ComparisonType comparison);
    }

   
    class BubbleSorter: IBubbleSorter
    {
        private Sort strategy;

        public delegate int[,] Sort(int[,] array, OrderType order, ComparisonType comparison);
        
        public int[,] BubbleSort(int[,] array, OrderType order, ComparisonType comparison)
        {
            if (array is null)
                throw new ArgumentNullException(nameof(array) + ": the array cannot be null");

            if (strategy is null)
                throw new NullReferenceException(nameof(strategy) + ": you must set the strategy");
            
            return strategy(array, order, comparison);
        }

        public void SetStategy(Sort strategy)
        {
            this.strategy = strategy;
        }
    }
}
