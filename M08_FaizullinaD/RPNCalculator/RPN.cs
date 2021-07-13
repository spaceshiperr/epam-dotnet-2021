using System;
using System.Collections.Generic;

namespace RPNCalculator
{
    public class RPN
    {
        private Stack<double> stack;

        public RPN()
        {
            stack = new Stack<double>();
        }

        public double Calculate(string input)
        {
            if (string.IsNullOrEmpty(input))
                return 0;

            var tokens = input.Split();

            foreach (var token in tokens)
            {
                var isNumber = double.TryParse(token, out double result);

                if (isNumber)
                    stack.Push(result);
                else
                    Apply(token);
            }

            if (stack.Count == 1)
                return stack.Pop();
            else
                throw new InvalidOperationException();
        }

        private void Apply(string token)
        {
            if (token == "+")
            {
                Sum();
            }
            else if (token == "-")
            {
                Substract();
            }
            else if (token == "*")
            {
                Multiply();   
            }
            else if (token == "/")
            {
                Divide();
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        private void Sum()
        {
            var sum = stack.Pop() + stack.Pop();
            stack.Push(sum);
        }

        private void Substract()
        {
            var diff = -stack.Pop() + stack.Pop();
            stack.Push(diff);
        }

        private void Multiply()
        {
            var product = stack.Pop() * stack.Pop();
            stack.Push(product);
        }

        private void Divide()
        {
            var number2 = stack.Pop();
            var number1 = stack.Pop();
            var quotient = number1 / number2;
            stack.Push(quotient);
        }
    }
}
