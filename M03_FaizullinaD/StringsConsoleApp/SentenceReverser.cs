namespace StringsConsoleApp
{
    public class SentenceReverser
    {
        public string ReverseSentence(string input)
        {
            string[] words = input.Split(' ');
            string reversed = string.Empty;

            foreach(var word in words)
                reversed = word + ' ' + reversed;

            return reversed;
        }
    }
}
