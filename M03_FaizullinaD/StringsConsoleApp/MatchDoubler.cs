using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace StringsConsoleApp
{
    public static class MatchDoubler
    {
        public static string DoubleMatchedChars(string text, string charsToDouble)
        {
            if (string.IsNullOrWhiteSpace(text) || string.IsNullOrWhiteSpace(charsToDouble))
                throw new ArgumentNullException();

            while (charsToDouble.IndexOf(' ') > 0)
                charsToDouble = charsToDouble.Remove(charsToDouble.IndexOf(' '), 1);

            var uniqueChars = charsToDouble.OfType<char>().Distinct();

            foreach (var c in uniqueChars)
            {
                text = text.Replace(new string(c, 1), new string(c, 2));
            }
            
            return text;
        }
    }
}
