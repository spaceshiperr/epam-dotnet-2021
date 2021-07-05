using System;
using System.Collections.Generic;
using static DelegateApp.BubbleSorter;

namespace DelegateApp
{
    class Program
    {
        public static void PrintCommands()
        {
            Console.WriteLine("Enter the command:");
            Console.WriteLine("1. Bubble-sort a matrix of integers");
            Console.WriteLine("2. Transmit a message to any subscriber of a class after the appointed time");
            Console.WriteLine("0. Exit");
        }

        public static int[,] ReadArray(int rowCount, int colCount)
        {
            Console.WriteLine("Enter the array:");
            var array = new int[rowCount, colCount];

            for (int i = 0; i < rowCount; i++)
            {
                var input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                    throw new ArgumentException("Size cannot be empty or whitespace, try again!");

                var row = input.Split();

                if (row.Length != colCount)
                    throw new ArgumentException("Wrong amount of items in a row, try again!");

                for (int j = 0; j < colCount; j++)
                {
                    var isInt = int.TryParse(row[j], out int item);

                    if (!isInt)
                        throw new ArgumentException("Array elements must be integer numbers, try again!");

                    array[i, j] = item;
                }
            }

            return array;
        }

        public static Tuple<int, int> ReadArraySize()
        {
            Console.WriteLine("Enter the size of the int matrix (row and col count) - two integers separated by spaces:");
            var size = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(size))
                throw new ArgumentException("Size cannot be empty or whitespace, try again!");

            var sizes = size.Split();

            var isInt1 = int.TryParse(sizes[0], out int rowCount);
            var isInt2 = int.TryParse(sizes[1], out int colCount);

            if (!(isInt1 && isInt2))
                throw new ArgumentException("Both sizes must be integers, try again!");

            return new Tuple<int ,int>(rowCount, colCount);
        }

        public static Func<int[,], int[,]> ReadStategy()
        {
            Console.WriteLine("Enter the comparison type (SumsOfRowElements, MinRowElement, MaxRowElement):");
            var comparisonInput = Console.ReadLine();

            Console.WriteLine("Enter the order type (Asc, Desc):");
            var orderInput = Console.ReadLine();

            if (!((Enum.TryParse(comparisonInput, out ComparisonType comparison)) &&
                  (Enum.TryParse(orderInput, out OrderType order))))
                throw new ArgumentException("Wrong comparison or order type, try again!");

            return GetSortStrategy(comparison, order);
        }

        public static void PrintArray(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                    Console.Write(array[i, j] + " ");
                Console.WriteLine();
            }
        }

        public static void Sort()
        {
            var size = ReadArraySize();

            var array = ReadArray(size.Item1, size.Item2);
            var strategy = ReadStategy();

            var sorter = new Sorter();
            var sorted = sorter.Sort(strategy, array);
            
            PrintArray(sorted);
        }

        public static void Subscribe()
        {
            var pub = new Countdown();

            Console.WriteLine("Enter the number of subcribers:");
            var isInteger = int.TryParse(Console.ReadLine(), out int subCount);

            if (!isInteger)
                throw new ArgumentException("Wrong subscriber count, it must be an integer!");

            var subs = new List<Subscriber>();

            for (int i = 0; i < subCount; i++)
            {
                subs.Add(new Subscriber("sub" + (i + 1).ToString(), pub));
            }

            Console.WriteLine("Enter timeout time (hh:mm:ss):");
            var isTime = TimeSpan.TryParse(Console.ReadLine(), out TimeSpan ts);

            if (!isTime)
                throw new ArgumentException("Wrong time format, try again!");

            Console.WriteLine("Enter the message to transmit:");
            var message = Console.ReadLine();

            pub.DoSomething(message, ts);
        }

        static void Main(string[] args)
        {
            do
            {
                try
                {
                    PrintCommands();
                    var command = Console.ReadLine();

                    if (command == "1")
                    {
                        Sort();
                        break;
                    }
                    else if (command == "2")
                    {
                        Subscribe();
                        break;
                    }
                    else if (command == "0")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Wrong command number, try again!");
                    }
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            while (true);
                
            Console.ReadKey();
        }
    }
}
