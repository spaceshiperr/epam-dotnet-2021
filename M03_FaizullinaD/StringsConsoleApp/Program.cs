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
            var input = Console.ReadLine();

            //var wordAverage = new WordAverage();
            //double average = wordAverage.GetAverageWordLength(input);
            //Console.WriteLine(average);

            var sentenceReverser = new SentenceReverser();
            string reversed = sentenceReverser.ReverseSentence(input);
            Console.WriteLine(reversed);

            Console.ReadLine();
        }
    }
}
