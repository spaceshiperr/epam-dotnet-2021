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
                Printer.PrintCommands();
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
                    Printer.Print("Enter the array - numbers separated by spaces:");

                    var inputArray = Reader.GetInputArray();
                    decimal[] array = Converter.ToNumberArray(inputArray);

                    var sorter = new ArraySorter(array);

                    sorter.BubbleSortAsc();
                    Printer.Print("The array sorted in ascending order:");
                    Printer.PrintArray(array);

                    sorter.BubbleSortDesc();
                    Printer.Print("The array sorted in descending order:");
                    Printer.PrintArray(array);
                    break;
                }
                catch (Exception e)
                {
                    Printer.Print(e.Message);
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
                    Printer.Print("Enter the number of rows in a two-dimensional array:");
                    var rowsInput = Reader.GetInput();
                    var rows = Convert.ToInt32(Converter.ToNumber(rowsInput));

                    Printer.Print("Enter members of the a two-dimensional array - rows of numbers separated by spaces:");
                    string[] inputArray = Reader.GetInputArray(rows);
                    decimal[,] array = Converter.To2DNumberArray(inputArray);

                    var summator = new PositivesSummator(array);
                    var sum = summator.SumPositives();
                    Printer.Print("The sum of all positive numbers of the array: " + sum);
                    break;
                }
                catch (Exception e)
                {
                    Printer.Print(e.Message);
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
                    Printer.Print("Enter width and length of a rectangle - two numbers separated by spaces:");
                    var inputSizes = Reader.GetInputArray();
                    var sizes = Converter.ToNumberArray(inputSizes);

                    if (sizes.Length != 2)
                        throw new ArgumentException("There must be two numbers - length and width. Try again!");

                    var width = sizes[0];
                    var length = sizes[1];

                    var calculator = new RectangleCalculator(width, length);
                    var perimeter = calculator.GetPerimeter();
                    var square = calculator.GetSquare();

                    Printer.Print("The perimeter is " + perimeter + " and the square is " + square);
                    break;
                }
                catch (Exception e)
                {
                    Printer.Print(e.Message);
                    continue;
                }
            } while (true);
        }
    }
}
