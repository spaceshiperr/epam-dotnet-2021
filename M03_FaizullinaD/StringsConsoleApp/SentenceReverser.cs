using System;

namespace StringsConsoleApp
{
    public static class SentenceReverser
    {
        public static string ReverseSentence(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                throw new ArgumentNullException();
                
            string[] words = input.Split(' ');
            string reversed = string.Empty;

            foreach(var word in words)
                reversed = word + ' ' + reversed;

            return reversed.TrimEnd();
        }
    }
}
