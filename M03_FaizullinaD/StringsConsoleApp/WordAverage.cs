using System;

namespace StringsConsoleApp
{
    public static class WordAverage
    {
        public static double GetAverageWordLength(string input)
        {
            if (string.IsNullOrEmpty(input))
                throw new ArgumentNullException();
            
            string[] delimiterChars = { " ", ",", ".", ":", "\t", ";", "\"", "\'", 
                                        "?", "!", "(", ")", "-", "\\", "/", Environment.NewLine};
            string[] words = input.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries);

            double sum = 0;
            foreach (var word in words)
                sum += word.Length;

            double average = sum == 0 ? 0 : sum / words.Length;

            return average;
        }
    }
}
