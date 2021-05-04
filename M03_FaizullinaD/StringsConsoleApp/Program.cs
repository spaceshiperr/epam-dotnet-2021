using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringsConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //var input = Console.ReadLine();
            //double average = WordAverage.GetAverageWordLength(input);
            //Console.WriteLine(average);

            //var input = Console.ReadLine();
            //string reversed = SentenceReverser.ReverseSentence(input);
            //Console.WriteLine(reversed);

            var text = "omg i love shrek";
            var charsToDouble = "o kek";
            var doubled = MatchDoubler.DoubleMatchedChars(text, charsToDouble);
            Console.WriteLine(doubled);

            Console.ReadLine();
        }
    }
}
