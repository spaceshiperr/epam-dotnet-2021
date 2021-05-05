namespace StringsConsoleApp
{
    public static class BigNumberSummator
    {
        
        public static string Sum(string first, string second)
        {
            string result = string.Empty;

            string longer = (first.Length > second.Length) ? first : second;
            string shorter = (first.Length > second.Length) ? second : first;

            int additional = 0;
            int indexDiff = longer.Length - shorter.Length;

            for (int i = shorter.Length - 1; i >= 0; i--)
            {
                int longerDigit, shorterDigit;
                int.TryParse(longer[i + indexDiff].ToString(), out longerDigit);
                int.TryParse(shorter[i].ToString(), out shorterDigit);

                int sum = longerDigit + shorterDigit + additional;
                result = (sum % 10).ToString() + result;
                additional = sum / 10;
            }

            if (result.Length < longer.Length)
            {
                for (int i = indexDiff - 1; i >= 0; i--)
                {
                    int longerDigit;
                    int.TryParse(longer[i].ToString(), out longerDigit);

                    int sum = longerDigit + additional;
                    result = (sum % 10).ToString() + result;
                    additional = sum / 10;
                }
            }

            if (additional == 1)
                result = "1" + result;

            return result;
        }
    }
}
