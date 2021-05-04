using System;

namespace StringsConsoleApp
{
    public static class WordAverage
    {
        public static double GetAverageWordLength(string input)
        {
            char[] delimiterChars = { ' ', ',', '.', ':', '\t', ';', '\'', '"', '?', '!', '(', ')', '-' };
            string[] words = input.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries);

            double sum = 0;
            foreach (var word in words)
                sum += word.Length;

            double average = sum / words.Length;

            return average;
        }
    }
}
