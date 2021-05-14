using System;
using Microsoft.Extensions.Logging;

namespace ConverterLibrary
{
    public class ToIntConverter
    {
        public ToIntConverter(ILogger logger)
        {
            Logger = logger;
        }

        private static ILogger Logger;

        public int ToInt(string str)
        {
            checkNullOrEmpty(str);
            Logger.LogTrace("Input string received");

            int num = 0;
            Logger.LogTrace("Variable for int value initialized with 0");

            for (int i = 0; i < str.Length; i++)
            {
                int digit = ((int)str[i] - 48);
                checkDigit(digit);
                Logger.LogTrace("Next digit is " + digit);

                checkRange(num, digit);
                num = num * 10 + digit;
                Logger.LogTrace("The processed part of the number equals to " + num);
            }

            Logger.LogTrace("Final number equals to " + num);
            return num;
        }

        private void checkNullOrEmpty(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                var ex = new ArgumentNullException("Cannot convert to int, the argument is null or empty");
                Logger.LogError(ex.Message);
                throw ex;
            }
        }

        private void checkDigit(int digit)
        {
            if (digit > 9 || digit < 0)
            {
                var ex = new ArgumentException("Cannot convert to int, it contains non-digit symbols");
                Logger.LogError(ex.Message);
                throw ex;
            }
        }

        private void checkRange(int num, int digit)
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
