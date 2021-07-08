using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentTestsLibrary
{
    public class ResultFilter
    {
        public IEnumerable<TestResult> results { get; set; }

        public ResultFilter(IEnumerable<TestResult> results)
        {
            this.results = results;
        }

        public IEnumerable<TestResult> Filter(string searchString)
        {
            if (string.IsNullOrEmpty(searchString))
                throw new ArgumentException("Search string cannot be empty, try again!");

            var elements = searchString.Split();
            var tempResults = results;

            for (int i = 0; i < elements.Length - 1; i++)
            {
                if (elements[i].StartsWith("-"))
                {
                    var flag = elements[i];
                    var value = elements[i + 1];

                    if (flag.Equals("-name"))
                        tempResults = FilterName(tempResults, value);
                    else if (flag.Equals("-surname"))
                        tempResults = FilterSurname(tempResults, value);
                    else if (flag.Equals("-date"))
                        tempResults = FilterDate(tempResults, value);
                    else if (flag.Equals("-datefrom"))
                        tempResults = FilterDateFrom(tempResults, value);
                    else if (flag.Equals("-dateto"))
                        tempResults = FilterDateTo(tempResults, value);
                    else if (flag.Equals("-test"))
                        tempResults = FilterTest(tempResults, value);
                    else if (flag.Equals("-mark"))
                        tempResults = FilterMark(tempResults, value);
                    else if (flag.Equals("-maxmark"))
                        tempResults = FilterMaxMark(tempResults, value);
                    else if (flag.Equals("-minmark"))
                        tempResults = FilterMinMark(tempResults, value);
                    else if (flag.Equals("-sort") && i + 2 < elements.Length)
                        tempResults = Sort(tempResults, value, elements[i + 2]);
                    else
                        throw new ArgumentException("Wrong flag, try again!");
                }
            }
            return tempResults;
        }

        private IEnumerable<TestResult> FilterName(IEnumerable<TestResult> tempResults, string name)
        {
            return tempResults.Where(result => result.Student.Name.Equals(name));
        }

        private IEnumerable<TestResult> FilterSurname(IEnumerable<TestResult> tempResults, string surname)
        {
            return tempResults.Where(result => result.Student.Surname.Equals(surname));
        }

        private IEnumerable<TestResult> FilterDate(IEnumerable<TestResult> tempResults, string date)
        {
            try
            {
                var dt = DateTime.Parse(date);
                if (dt > DateTime.Today)
                    throw new ArgumentException("The date cannot be more than today's date");

                return tempResults.Where(result => result.Date.Equals(dt));
            }
            catch (FormatException)
            {
                throw new ArgumentException("Date must be in format yyyy/mm/dd, try again!");
            }
        }

        private IEnumerable<TestResult> FilterDateFrom(IEnumerable<TestResult> tempResults, string date)
        {
            try
            {
                var dt = DateTime.Parse(date);

                if (dt > DateTime.Today)
                    throw new ArgumentException("The date cannot be more than today's date");

                return tempResults.Where(result => result.Date >= dt);
            }
            catch (FormatException)
            {
                throw new ArgumentException("Date must be in format yyyy/mm/dd, try again!");
            }
            
        }

        private IEnumerable<TestResult> FilterDateTo(IEnumerable<TestResult> tempResults, string date)
        {
            try
            {
                var dt = DateTime.Parse(date);

                if (dt > DateTime.Today)
                    throw new ArgumentException("The date cannot be more than today's date");

                return tempResults.Where(result => result.Date <= dt);
            }
            catch (FormatException)
            {
                throw new ArgumentException("Date must be in format yyyy/mm/dd, try again!");
            }
        }

        private IEnumerable<TestResult> FilterTest(IEnumerable<TestResult> tempResults, string test)
        {
            if (Enum.TryParse(test, out TestResult.Subject subject))
                return tempResults.Where(result => result.Test.Equals(subject));
            else
                throw new ArgumentException("Wrong test name, try again!");
        }

        private IEnumerable<TestResult> FilterMark(IEnumerable<TestResult> tempResults, string mark)
        {
            if (int.TryParse(mark, out int markNum))
                if (markNum >= 2 && markNum <= 5)
                    return tempResults.Where(result => result.Mark == markNum);
                else
                    throw new ArgumentException("Mark must be between 2 and 5, try again!");
            else
                throw new ArgumentException("Mark must be an integer, try again!");
        }

        private IEnumerable<TestResult> FilterMinMark(IEnumerable<TestResult> tempResults, string mark)
        {
            if (int.TryParse(mark, out int minMark))
                if (minMark >= 2 && minMark <= 5)
                    return tempResults.Where(result => result.Mark >= minMark);
                else
                    throw new ArgumentException("Mark must be between 2 and 5, try again!");
            else
                throw new ArgumentException("Mark must be an integer, try again!");
        }

        private IEnumerable<TestResult> FilterMaxMark(IEnumerable<TestResult> tempResults, string mark)
        {
            if (int.TryParse(mark, out int maxMark))
                if (maxMark >= 2 && maxMark <= 5)
                    return tempResults.Where(result => result.Mark <= maxMark);
                else
                    throw new ArgumentException("Mark must be between 2 and 5, try again!");
            else
                throw new ArgumentException("Mark must be an integer, try again!");
        }

        private IEnumerable<TestResult> Sort(IEnumerable<TestResult> tempResults, string key, string order)
        {
            if (order != "asc" && order != "desc")
                throw new ArgumentException("Sorting order can be either asc or desc, try again!");

            if (key.Equals("name"))
                if (order.Equals("asc"))
                    return from result in tempResults
                           orderby result.Student.Name ascending
                           select result;
                else
                    return from result in tempResults
                           orderby result.Student.Name descending
                           select result;
            else if (key.Equals("surname"))
                if (order.Equals("asc"))
                    return from result in tempResults
                           orderby result.Student.Surname ascending
                           select result;
                else
                    return from result in tempResults
                           orderby result.Student.Surname descending
                           select result;
            else if (key.Equals("date"))
                if (order.Equals("asc"))
                    return from result in tempResults
                           orderby result.Date ascending
                           select result;
                else
                    return from result in tempResults
                           orderby result.Date descending
                           select result;
            else if (key.Equals("test"))
                if (order.Equals("asc"))
                    return from result in tempResults
                           orderby result.Test ascending
                           select result;
                else
                    return from result in tempResults
                           orderby result.Test descending
                           select result;
            else if (key.Equals("mark"))
                if (order.Equals("asc"))
                    return from result in tempResults
                           orderby result.Mark ascending
                           select result;
                else
                    return from result in tempResults
                           orderby result.Mark descending
                           select result;
            else
                throw new ArgumentException("Sorting key can only be name, surname, date, test and mark, try again!");
        }
    }
}
