using System;

namespace LibrariesTestApp
{
    /// <summary>
    /// Class for reading input information
    /// </summary>
    public static class Reader
    {
        /// <summary>
        /// Reads an input line
        /// </summary>
        /// <returns>An input string</returns>
        public static string GetInput()
        {
            var input = Console.ReadLine();

            if (string.IsNullOrEmpty(input))
                throw new ArgumentException("The input is empty, try again!");

            return input;
        }

        /// <summary>
        /// Reads an array of elements separated by spaces
        /// </summary>
        /// <returns>A string array</returns>
        public static string[] GetInputArray()
        {
            var input = Console.ReadLine();

            if (string.IsNullOrEmpty(input))
                throw new ArgumentException("The input is empty, try again!");

            string[] inputArray = input.Split(' ');

            return inputArray;
        }

        /// <summary>
        /// Reads a 2d array where elements are in rows and separated by spaces
        /// </summary>
        /// <param name="n">The number of rows in an array</param>
        /// <returns>A string array</returns>
        public static string[] GetInputArray(int rowCount)
        {
            if (rowCount < 1)
                throw new ArgumentException("The number of rows must be positive. Try again!");
            
            var inputArray = new string[rowCount];
            for (int i = 0; i < rowCount; i++)
            {
                var input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                    throw new ArgumentException("The input is empty, try again!");

                inputArray[i] = input;
            }

            return inputArray;
        }

    }
}
