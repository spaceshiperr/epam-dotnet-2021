using System;

namespace LibrariesTestApp
{
    /// <summary>
    /// Prints the information to the console
    /// </summary>
    class Printer
    {
        /// <summary>
        /// Prints the elements of the array into a line separated by spaces
        /// </summary>
        /// <param name="array">An input array</param>
        public static void PrintArray(decimal[] array)
        {
            foreach (var element in array)
                Console.Write(element + " ");
            Console.WriteLine();
        }

        /// <summary>
        /// Prints the list of commands for the LibrariesConsoleApp
        /// </summary>
        public static void PrintCommands()
        {
            Console.WriteLine("Choose a command:" + Environment.NewLine +
                              "1 - bubble sort an array," + Environment.NewLine +
                              "2 - sum all positive numbers of a two dimensional array," + Environment.NewLine +
                              "3 - calculate perimeter or square of a rectangle," + Environment.NewLine +
                              "0 - exit an application");
        }

        /// <summary>
        /// Prints the message
        /// </summary>
        /// <param name="message">The message to print</param>
        public static void Print(string message)
        {
            Console.WriteLine(message);
        }
    }
}
