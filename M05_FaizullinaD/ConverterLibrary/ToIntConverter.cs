using System;
using Microsoft.Extensions.Logging;

namespace ConverterLibrary
{
    public class ToIntConverter
    {
        private static ILogger Logger;

        public ToIntConverter(ILogger logger)
        {
            Logger = logger;
        }

        public int ToInt(string str)
        {
            CheckNullOrWhiteSpace(str);
            Logger.LogTrace("Input string received");

            int num = 0;
            Logger.LogTrace("Variable for int value initialized with 0");
            var isNegative = false;

            for (int i = 0; i < str.Length; i++)
            {
                if (i == 0 && IsMinus(str[0]))
                {
                    isNegative = true;
                    continue;
                }

                int digit = str[i] - 48;
                CheckDigit(digit);
                Logger.LogTrace("Next digit is " + digit);

                CheckRange(num, digit);
                num = num * 10 + digit;
                Logger.LogTrace("The absolute value of processed part of the number equals to " + num);
            }

            if (isNegative)
                num = (-1) * num;

            Logger.LogTrace("Final number equals to " + num);
            return num;
        }

        private void CheckNullOrWhiteSpace(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                var ex = new ArgumentNullException("Cannot convert to int, the argument is null, empty or whitespace");
                Logger.LogError(ex.Message);
                throw ex;
            }
        }

        private void CheckDigit(int digit)
        {
            if (digit > 9 || digit < 0)
            {
                var ex = new ArgumentException("Cannot convert to int, it contains non-digit symbols");
                Logger.LogError(ex.Message);
                throw ex;
            }
        }

        private bool IsMinus(int c)
        {
            return c == 45;
        }

        private void CheckRange(int num, int digit)
        {
            try
            {
                num = checked(num * 10 + digit);
            }
            catch (OverflowException)
            {
                var ex = new ArgumentOutOfRangeException("Cannot convert to int, value is out of int range");
                Logger.LogError(ex.Message);
                throw ex;
            }
        }
    }
}
