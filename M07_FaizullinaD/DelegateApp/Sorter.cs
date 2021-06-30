using System;

namespace DelegateApp
{
    
    public interface ISorter
    {
        int[,] Sort(int[,] array);
    }
   
    public class Sorter: ISorter
    {
        private StrategyDelegate strategy;

        public delegate int[,] StrategyDelegate(int[,] array);
        
        //public void SetStategy(OrderType order, ComparisonType comparison)
        //{
        //    strategy = comparison switch
        //    {
        //        ComparisonType.SumsOfRowElements when 
        //            order.Equals(OrderType.Asc) => BubbleSortByRowSumsAsc,
        //        ComparisonType.SumsOfRowElements when 
        //            order.Equals(OrderType.Desc) => BubbleSortByRowSumsDesc,
        //        ComparisonType.MaxRowElement when 
        //            order.Equals(OrderType.Asc) => BubbleSortByMaxRowElementAsc,
        //        ComparisonType.MaxRowElement when 
        //            order.Equals(OrderType.Desc) => BubbleSortByMaxRowElementDesc,
        //        ComparisonType.MinRowElement when 
        //            order.Equals(OrderType.Asc) => BubbleSortByMinRowElementAsc,
        //        ComparisonType.MinRowElement when 
        //            order.Equals(OrderType.Desc) => BubbleSortByMinRowElementDesc,
        //        _ => throw new Exception(nameof(order) + ", " + nameof(comparison))
        //    };
        //}

        public void SetStrategy(StrategyDelegate strategy)
        {
            this.strategy = strategy;
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
