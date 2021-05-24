using System;
using static DelegateApp.ISorter;
using static DelegateApp.BubbleSortMethods;

namespace DelegateApp
{
    public interface ISorter
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

        int[,] Sort(int[,] array);
    }
   
    public class Sorter: ISorter
    {
        private SortDelegate strategy;

        public delegate int[,] SortDelegate(int[,] array);
        
        public void SetStategy(OrderType order, ComparisonType comparison)
        {
            strategy = comparison switch
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

        public int[,] Sort(int[,] array)
        {
            if (array is null)
                throw new ArgumentNullException(nameof(array) + ": the array cannot be null");

            if (strategy is null)
                throw new NullReferenceException(nameof(strategy) + ": you must set the strategy");

            return strategy(array);
        }
    }
}
