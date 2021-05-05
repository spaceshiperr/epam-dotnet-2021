using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.IO;

namespace StringsConsoleApp
{
    public static class PhoneNumberFilter
    {
        public static List<string> GetPhoneNumbers(string text)
        {
            var regex1 = new Regex(@"\+[0-9] \([0-9]{3}\) [0-9]{3}\-[0-9]{2}\-[0-9]{2}");
            var regex2 = new Regex(@"[0-9] [0-9]{3} [0-9]{3}\-[0-9]{2}\-[0-9]{2}");
            var regex3 = new Regex(@"\+[0-9]{3} \([0-9]{2}\) [0-9]{3}\-[0-9]{4}");

            var matches1 = regex1.Matches(text);
            var matches2 = regex2.Matches(text);
            var matches3 = regex3.Matches(text);

            var phoneNumbers = new List<string>();

            foreach (Match match in matches1)
                phoneNumbers.Add(match.Value);

            foreach (Match match in matches2)
                phoneNumbers.Add(match.Value);

            foreach (Match match in matches3)
                phoneNumbers.Add(match.Value);

            return phoneNumbers;
        }

        public static string ReadTextFile(string filename)
        {
            using (var reader = new StreamReader(filename))
            {
                string input = reader.ReadToEnd();
                return input;
            }
        }

        public static void WriteListToTextFile(string filename, List<string> output)
        {
            using (var writer = new StreamWriter(filename))
            {
                foreach (var element in output)
                {
                    writer.WriteLine(element);
                }
            }
        }

    }
}
