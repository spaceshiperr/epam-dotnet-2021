using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using StudentTestsLibrary;


namespace StudentTestsApp
{
    class Program
    {
        private static IEnumerable<TestResult> GetTestResults()
        {
            var results = new TestResult[]
            {
                new TestResult
                {
                    Student = new Student("Elena", "Kasimova"),
                    Date = DateTime.Today,
                    Test = TestResult.Subject.ComputerScience,
                    Mark = 5
                },
                new TestResult
                {
                    Student = new Student("Robert", "Maksimov"),
                    Date = new DateTime(2021, 06, 12),
                    Test = TestResult.Subject.Math,
                    Mark = 4
                },
                new TestResult
                {
                    Student = new Student("Ksenia", "Foshkina"),
                    Date = new DateTime(2021, 05, 2),
                    Test = TestResult.Subject.English,
                    Mark = 5
                },
                new TestResult
                {
                    Student = new Student("Green", "Thumb"),
                    Date = new DateTime(2021, 06, 4),
                    Test = TestResult.Subject.Chemistry,
                    Mark = 2
                },
                new TestResult
                {
                    Student = new Student("Sasha", "Borisenko"),
                    Date = new DateTime(2021, 04, 29),
                    Test = TestResult.Subject.Math,
                    Mark = 3
                },
                new TestResult
                {
                    Student = new Student("Veronika", "Gross"),
                    Date = new DateTime(2021, 05, 11),
                    Test = TestResult.Subject.English,
                    Mark = 5
                }
            };

            return results;
        }

        public static void PrintResults(IEnumerable<TestResult> results)
        {
            Console.WriteLine("Student Test Date Mark");

            foreach (var result in results)
            {
                Console.WriteLine(result.Student.Name + " " +
                                  result.Student.Surname + " " +
                                  result.Test + " " +
                                  result.Date.ToShortDateString() + " " +
                                  result.Mark);
            }
        }
        
        static void Main(string[] args)
        {
            //var results = GetTestResults();
            string path = Path.Combine(
                Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName,
                "results.json"
            );

            //var rw = new ResultWriter(path);
            //rw.Write(results);

            var rr = new ResultReader(path);
            var results = rr.Read();

            do
            {
                try
                {
                    Console.WriteLine("Enter the search string:");
                    var searchString = Console.ReadLine();

                    var filter = new ResultFilter(results);
                    var filteredResults = filter.Filter(searchString);
                    
                    if (filteredResults.Any())
                    {
                        PrintResults(filteredResults);
                    }
                    else
                    {
                        Console.WriteLine("No results matching the pattern found!");
                    }
                    break;
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
            }
            while (true);

            Console.ReadKey();
        }
    }
}
