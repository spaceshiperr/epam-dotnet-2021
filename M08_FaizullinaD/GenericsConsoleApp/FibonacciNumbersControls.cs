using System;
using System.Linq;
using GenericsLibrary;

namespace GenericsConsoleApp
{
    public class FibonacciNumbersControls
    {
        public static void GetFibonacciNumbers()
        {
            var count = ReadPositiveInt("Enter the number of elements:",
                                        "Wrong input, try again!");

            var numbers = FibonacciNumbers.GetNumbers().Take(count).ToArray();
            PrintArray(numbers);
        }

        private static int ReadPositiveInt(string consoleMessage, string errorMessage)
        {
            do
            {
                Console.WriteLine(consoleMessage);

                var input = Console.ReadLine();
                var isInt = int.TryParse(input, out int result);

                if (isInt && result > 0)
                    return result;
                else
                    Console.WriteLine(errorMessage);
            }
            while (true);
        }

        internal static void PrintArray<T>(T[] array)
        {
            foreach (var element in array)
                Console.Write(element.ToString() + " ");
            Console.WriteLine();
        }
    }
}
