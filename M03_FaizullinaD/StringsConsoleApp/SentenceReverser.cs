namespace StringsConsoleApp
{
    public static class SentenceReverser
    {
        public static string ReverseSentence(string input)
        {
            string[] words = input.Split(' ');
            string reversed = string.Empty;

            foreach(var word in words)
                reversed = word + ' ' + reversed;

            return reversed;
        }
    }
}
