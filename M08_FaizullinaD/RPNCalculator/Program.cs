using System;

namespace RPNCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                try
                {
                    Console.WriteLine("Enter the expression in RPN:");
                    var expression = Console.ReadLine();

                    var rpn = new RPN();
                    var result = rpn.Calculate(expression);

                    Console.WriteLine("The result: " + result);
                    break;
                }
                catch (InvalidOperationException)
                {
                    Console.WriteLine("Wrong expression, try again!");
                }
            }
            while (true);
            
            Console.ReadLine();
        }
    }
}
