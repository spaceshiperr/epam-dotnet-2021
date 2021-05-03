using System;

namespace LibrariesTestApp
{
    /// <summary>
    /// Converts objects of one type into another
    /// </summary>
    static class Converter
    {
        /// <summary>
        /// Converts a string array into the decimal array
        /// </summary>
        /// <param name="inputArray">A string array of numbers</param>
        /// <returns>A decimal array</returns>
        public static decimal[] ToNumberArray(string[] inputArray)
        {
            var array = new decimal[inputArray.Length];

            for (int i = 0; i < inputArray.Length; i++)
            {
                array[i] = ToNumber(inputArray[i]);
            }
            return array;
        }

        /// <summary>
        /// Converts a string array into a 2D decimal array
        /// </summary>
        /// <param name="inputArray">An array where each element is a string of elements</param>
        /// <returns>A 2D decimal array</returns>
        public static decimal[,] To2DNumberArray(string[] inputArray)
        {
            int n = inputArray.Length;
            int m = inputArray[0].Split(' ').Length;

            decimal[,] array = new decimal[n, m];

            for (int i = 0; i < n; i++)
            {
                string[] cells = inputArray[i].Split(' ');

                if (cells.Length != m)
                    throw new ArgumentException("The number of elements in a row must be the same. Try again!");

                for (int j = 0; j < m; j++)
                {
                    array[i, j] = ToNumber(cells[j]);
                }
            }

            return array;
        }

        /// <summary>
        /// Converts a string into a decimal number
        /// </summary>
        /// <param name="input">Input string that contains a number</param>
        /// <returns>Decimal number</returns>
        public static decimal ToNumber(string input)
        {
            decimal numericValue;
            bool isNumber = decimal.TryParse(input, out numericValue);
            if (isNumber)
                return numericValue;
            else
                throw new ArgumentException("The input must be a number. Try again!");
        }
    }
}
