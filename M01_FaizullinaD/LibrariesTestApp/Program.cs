using System;
using System.Globalization;
using ArrayHelper;
using RectangleHelper;

namespace LibrariesTestApp
{
    public class Program
    {
        public static void Main()
        {
            var action = string.Empty;

            while (action != "0")
            {
                PrintInfo();
                action = Console.ReadLine();
                switch (action)
                {
                    case "0":
                        break;
                    case "1":
                        BubbleSort();
                        break;
                    case "2":
                        SumPositives();
                        break;
                    case "3":
                        CalculateRectangle();
                        break;
                    default:
                        Console.WriteLine("Wrong action number, try again!");
                        break;
                }
            }
        }

        private static void PrintInfo()
        {
            Console.WriteLine("Choose an action:" + Environment.NewLine +
                              "1 - bubble sort an array," + Environment.NewLine +
                              "2 - sum all positive numbers of a two dimensional array" + Environment.NewLine +
                              "3 - calculate perimeter or square of a rectangle:" + Environment.NewLine +
                              "0 - exit an application");
        }

        private static void BubbleSort()
        {
            Console.WriteLine("Enter one number - the size of an array:");
            int n = Convert.ToInt32(Console.ReadLine());
            var array = new decimal[n];

            Console.WriteLine("Enter members of the array - a row of numbers separated by spaces:");
            string[] elements = Console.ReadLine().Split(' ');

            NumberFormatInfo provider = new NumberFormatInfo();
            provider.NumberDecimalSeparator = ".";

            for (int i = 0; i < n; i++)
                array[i] = Convert.ToDecimal(elements[i], provider);

            var sorter = new ArraySorter(array);

            Console.WriteLine("The array sorted in ascending order:");
            sorter.BubbleSortAsc();
            foreach (var element in array)
                Console.Write(element + " ");

            Console.WriteLine();
            Console.WriteLine("The array sorted in descending order:");
            sorter.BubbleSortDesc();
            foreach (var element in array)
                Console.Write(element + " ");
            Console.WriteLine();
        }

        private static void SumPositives()
        {
            Console.WriteLine("Enter two numbers separated by a space - " +
                              "the number of rows and columns of a two-dimensional array:");
            string[] sizes = Console.ReadLine().Split(' ');
            int n = Convert.ToInt32(sizes[0]);
            int m = Convert.ToInt32(sizes[1]);

            var array = new decimal[n, m];

            NumberFormatInfo provider = new NumberFormatInfo();
            provider.NumberDecimalSeparator = ".";

            Console.WriteLine("Enter members of the array - rows of numbers separated by spaces:");
            for (int i = 0; i < n; i++)
            {
                string[] elements = Console.ReadLine().Split(' ');
                for (int j = 0; j < m; j++)
                    array[i, j] = Convert.ToDecimal(elements[j], provider);
            }

            var summator = new PositivesSummator(array);
            var sum = summator.SumPositives();
            Console.WriteLine("The sum of all positive numbers of the array: " + sum);
        }

        private static void CalculateRectangle()
        {
            Console.WriteLine("Enter width and length of a rectangle - two numbers separated by spaces:");
            string[] sizes = Console.ReadLine().Split(' ');

            NumberFormatInfo provider = new NumberFormatInfo();
            provider.NumberDecimalSeparator = ".";

            var width = Convert.ToDecimal(sizes[0], provider);
            var length = Convert.ToDecimal(sizes[1], provider);

            var calculator = new RectangleCalculator(width, length);
            var perimeter = calculator.GetPerimeter();
            var square = calculator.GetSquare();

            Console.WriteLine("The perimeter is " + perimeter + " and the square is " + square);
        }

    }
}
