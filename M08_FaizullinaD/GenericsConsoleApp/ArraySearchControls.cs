using System;
using System.Collections.Generic;
using GenericsLibrary;

namespace GenericsConsoleApp
{
    public class ArraySearchControls
    {
        public static void Search()
        {
            var array = ReadDecimalArray();
            var element = ReadDecimal("Enter the element you're searching for:",
                                      "Invalid search element, try again!");

            var result = ArraySearch.BinarySearch(array, element);

            if (result == -1)
                Console.WriteLine("The element is not found!");
            else
                Console.WriteLine("The element's index in the array is " + result);
        }

        private static decimal[] ReadDecimalArray()
        {
            do
            {
                Console.WriteLine("Enter elements of an array separated by spaces:");

                var input = Console.ReadLine().Split();
                var list = new List<decimal>();

                foreach (var element in input)
                {
                    var isDecimal = decimal.TryParse(element, out decimal result);
                    if (isDecimal)
                        list.Add(result);
                    else
                    {
                        Console.WriteLine("Invalid array element, try again!");
                        break;
                    }
                }

                if (input.Length == list.Count)
                    return list.ToArray();
            }
            while (true);
        }

        private static decimal ReadDecimal(string consoleMessage, string errorMessage)
        {
            do
            {
                Console.WriteLine(consoleMessage);

                var input = Console.ReadLine();
                var isDecimal = decimal.TryParse(input, out decimal result);

                if (isDecimal)
                    return result;
                else
                    Console.WriteLine(errorMessage);
            }
            while (true);
        }
    }
}
