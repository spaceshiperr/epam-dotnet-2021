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

            string command;
            do
            {
                PrintCommands();
                command = Console.ReadLine();
                switch (command)
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
                        Console.WriteLine("Wrong action number. Try again!");
                        break;
                }
            } while (command != "0");
        }

        private static void BubbleSort()
        {
            do
            {
                try
                {
                    Console.WriteLine("Enter the array - numbers separated by spaces:");

                    var inputArray = Reader.GetInputArray();
                    decimal[] array = Converter.ToNumberArray(inputArray);

                    var sorter = new ArraySorter(array);

                    sorter.BubbleSortAsc();
                    Console.WriteLine("The array sorted in ascending order:");
                    Console.WriteLine(string.Join(" ", array));

                    sorter.BubbleSortDesc();
                    Console.WriteLine("The array sorted in descending order:");
                    Console.WriteLine(string.Join(" ", array));
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
            } while (true);
        }

        private static void SumPositives()
        {
            do
            {
                try
                {
                    Console.WriteLine("Enter the number of rows in a two-dimensional array:");
                    var rowsInput = Reader.GetInput();
                    var rows = Convert.ToInt32(Converter.ToNumber(rowsInput));

                    Console.WriteLine("Enter members of the a two-dimensional array - rows of numbers separated by spaces:");
                    string[] inputArray = Reader.GetInputArray(rows);
                    decimal[,] array = Converter.To2DNumberArray(inputArray);

                    var summator = new PositivesSummator(array);
                    var sum = summator.SumPositives();
                    Console.WriteLine("The sum of all positive numbers of the array: " + sum);
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
            } while (true);
        }

        private static void CalculateRectangle()
        {
            do
            {
                try
                {
                    Console.WriteLine("Enter width and length of a rectangle - two numbers separated by spaces:");
                    var inputSizes = Reader.GetInputArray();
                    var sizes = Converter.ToNumberArray(inputSizes);

                    if (sizes.Length != 2)
                        throw new ArgumentException("There must be two numbers - length and width. Try again!");

                    var width = sizes[0];
                    var length = sizes[1];

                    var calculator = new RectangleCalculator(width, length);
                    var perimeter = calculator.GetPerimeter();
                    var square = calculator.GetSquare();

                    Console.WriteLine("The perimeter is " + perimeter + " and the square is " + square);
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
            } while (true);
        }

        private static void PrintCommands()
        {
            Console.WriteLine("Choose a command:" + Environment.NewLine +
                              "1 - bubble sort an array," + Environment.NewLine +
                              "2 - sum all positive numbers of a two dimensional array," + Environment.NewLine +
                              "3 - calculate perimeter or square of a rectangle," + Environment.NewLine +
                              "0 - exit an application");
        }
    }
}
