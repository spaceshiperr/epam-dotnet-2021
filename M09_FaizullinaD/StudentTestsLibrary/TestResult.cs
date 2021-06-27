using System;

namespace StudentTestsLibrary
{
    public class TestResult
    {
        public enum Subject
        {
            Math,
            English,
            History,
            ComputerScience,
            Physics,
            Chemistry
        }
        
        public Student Student { get; set; }

        public DateTime Date { get; set; }

        public Subject Test { get; set; }

        public int Mark { get; set; }
    }
}
