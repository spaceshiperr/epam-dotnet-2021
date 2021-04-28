using System;
using System.Globalization;
using System.Threading;
using ArrayHelper;
using RectangleHelper;

namespace LibrariesTestApp
{
    public class Program
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;

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
                              "2 - sum all positive numbers of a two dimensional array," + Environment.NewLine +
                              "3 - calculate perimeter or square of a rectangle," + Environment.NewLine +
                              "0 - exit an application");
        }

        private static void PrintArray(decimal[] array)
        {
            foreach (var element in array)
                Console.Write(element + " ");
            Console.WriteLine();
        }

        private static decimal[] GetArray(string line)
        {
            if (line.Equals(string.Empty))
                throw new ArgumentException("The entry should not be empty. Try again!");

            string[] elements = line.Split(' ');
            var array = new decimal[elements.Length];
            
            for (int i = 0; i < elements.Length; i++)
            {
                try
                {
                    array[i] = GetNumber(elements[i]);
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            return array;
        }

        private static decimal GetNumber(string stringNumber)
        {
            decimal numericValue;
            bool isNumber = decimal.TryParse(stringNumber, out numericValue);
            if (isNumber)
                return numericValue;
            else
                throw new ArgumentException("It must be a number or numbers. Try again!");
        }

        private static void BubbleSort()
        {
            while (true)
            {
                Console.WriteLine("Enter the array - numbers separated by spaces:");
                var line = Console.ReadLine();
                decimal[] array;
                try
                {
                    array = GetArray(line);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }

                var sorter = new ArraySorter(array);

                sorter.BubbleSortAsc();
                Console.WriteLine("The array sorted in ascending order:");
                PrintArray(array);

                sorter.BubbleSortDesc();
                Console.WriteLine("The array sorted in descending order:");
                PrintArray(array);
                break;
            }
        }

        private static void SumPositives()
        {
            while (true)
            {
                Console.WriteLine("Enter the number of rows in a two-dimensional array");
                string line = Console.ReadLine();
                int n;
                int m = 0;
                decimal[][] array;

                try
                {
                    n = Convert.ToInt32(GetNumber(line));

                    array = new decimal[n][];
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }

                Console.WriteLine("Enter members of the a two-dimensional array - rows of numbers separated by spaces:");

                for (int i = 0; i < n; i++)
                {
                    line = Console.ReadLine();

                    try
                    {
                        array[i] = GetArray(line);
                        if (i == 0)
                            m = array[0].Length;
                        else if (array[i].Length != m)
                            throw new ArgumentException("The number of elements in a row must be the same. Try again!");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        continue;
                    }
                }

                var summator = new PositivesSummator(array);
                var sum = summator.SumPositives();
                Console.WriteLine("The sum of all positive numbers of the array: " + sum);
                break;
            }
        }

        private static void CalculateRectangle()
        {
            Console.WriteLine("Enter width and length of a rectangle - two numbers separated by spaces:");
            
            while (true)
            {
                var line = Console.ReadLine();
                decimal width, length;

                try
                {
                    var sizes = GetArray(line);

                    if (sizes.Length != 2)
                        throw new ArgumentException("There must be two number - length and width. Try again!");

                    width = sizes[0];
                    length = sizes[1];

                    if (width <= 0 | length <= 0)
                    {
                        throw new ArgumentException("Width and length must be positive numbers. Try again!");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }

                var calculator = new RectangleCalculator(width, length);
                var perimeter = calculator.GetPerimeter();
                var square = calculator.GetSquare();

                Console.WriteLine("The perimeter is " + perimeter + " and the square is " + square);
                break;
            }
        }
    }
}
