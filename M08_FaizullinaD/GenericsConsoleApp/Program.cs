using System;


namespace GenericsConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            PrintCommands();
            do
            {
                Console.Write("Enter the command: ");
                var command = Console.ReadLine();

                if (command == "0")
                    break;
                else if (command == "1")
                    ArraySearchControls.Search();
                else if (command == "2")
                    FibonacciNumbersControls.GetFibonacciNumbers();
                else if (command == "3")
                    StackControls.RunStack();
                else
                {
                    Console.WriteLine("Wrong command number, try again!");
                    continue;
                }

            }
            while (true);
        }

        private static void PrintCommands()
        {
            Console.WriteLine("Enter the command number:");
            Console.WriteLine("1. Find an element in an array using binary search algorithm");
            Console.WriteLine("2. Get an array of Fibonacci numbers");
            Console.WriteLine("3. Create a stack stucture and work with it");
            Console.WriteLine("0. Exit");
        }
    }
}
