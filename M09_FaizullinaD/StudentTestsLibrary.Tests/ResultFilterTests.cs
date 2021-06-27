using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace StudentTestsLibrary.Tests
{
    [TestFixture]
    public class ResultFilterTests
    {
        public ResultFilter filter;

        [OneTimeSetUp]
        public void SetUp()
        {
            var results = GetTestResults();
            filter = new ResultFilter(results);
        }
        
        public IEnumerable<TestResult> GetTestResults()
        {
            return new TestResult[]
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
        }

        [Test]
        public void Filter_SearchStringIsEmpty_ThrowsArgumentException()
        {
            Assert.That(() => filter.Filter(string.Empty), Throws.ArgumentException);
        }

        [Test]
        public void Filter_NameFlagIsKsenia_ReturnsOneResult()
        {
            var name = "Ksenia";
            var searchString = "-name " + name;

            var results = filter.Filter(searchString);

            Assert.That(results.Single().Student.Name, Is.EqualTo(name));
        }

        [Test]
        public void Filter_SurnameFlagIsGross_ReturnsOneResult()
        {
            var surname = "Gross";
            var searchString = "-surname " + surname;

            var results = filter.Filter(searchString);

            Assert.That(results.Single().Student.Surname, Is.EqualTo(surname));
        }

        [Test]
        public void Filter_DateFlagIsFutureDate_ThrowsArgumentException()
        {
            var searchString = "-date 2022/01/01";

            Assert.That(() => filter.Filter(searchString), Throws.ArgumentException);
        }

        [Test]
        public void Filter_DateFlagIsWrongFormat_ThrowsArgumentException()
        {
            var searchString = "-date 121324";

            Assert.That(() => filter.Filter(searchString), Throws.ArgumentException);
        }

        [Test]
        public void Filter_DateIs04062021_ReturnsOneResult()
        {
            var date = new DateTime(2021, 06, 04);
            var results = filter.Filter("-date " + date);

            Assert.That(results.Single().Date, Is.EqualTo(date));
        }

        [Test]
        public void Filter_DateToFlagIsFutureDate_ThrowsArgumentException()
        {
            var searchString = "-dateto 2040/03/12";

            Assert.That(() => filter.Filter(searchString), Throws.ArgumentException);
        }

        [Test]
        public void Filter_DateToFlagIsWrongFormat_ThrowsArgumentException()
        {
            var searchString = "-dateto ";

            Assert.That(() => filter.Filter(searchString), Throws.ArgumentException);
        }

        [Test]
        public void Filter_DateToIs12052021_Returns3Results()
        {
            var date = new DateTime(2021, 05, 12);

            var results = filter.Filter("-dateto " + date);

            Assert.That(results.Count(), Is.EqualTo(3));
            Assert.That(results.All(result => result.Date <= date), Is.True);
        }

        [Test]
        public void Filter_DateFromFlagIsFutureDate_ThrowsArgumentException()
        {
            var searchString = "-datefrom 2022/01/01";

            Assert.That(() => filter.Filter(searchString), Throws.ArgumentException);
        }

        [Test]
        public void Filter_DateFromFlagIsWrongFormat_ThrowsArgumentException()
        {
            var searchString = "-datefrom ...";

            Assert.That(() => filter.Filter(searchString), Throws.ArgumentException);
        }

        [Test]
        public void Filter_DateFrom20210505_Returns3Results()
        {
            var date = new DateTime(2021, 05, 12);

            var results = filter.Filter("-datefrom " + date);

            Assert.That(results.Count(), Is.EqualTo(3));
            Assert.That(results.All(result => result.Date >= date), Is.True);
        }

        [Test]
        public void Filter_TestNameIsInvalid_ThrowsArgumentException()
        {
            var test = "Abracadabra";
            var searchString = "-test " + test;

            Assert.That(() => filter.Filter(searchString), Throws.ArgumentException);
        }

        public void Filter_TestIsEnglish_Returns2Results()
        {
            var searchString = "-test English";

            var results = filter.Filter(searchString);
            
            Assert.That(results.Count(), Is.EqualTo(2));
            Assert.That(results.All(result => result.Test.Equals(TestResult.Subject.English)), Is.True);
        }

        [TestCase("jksdf")]
        [TestCase("12.15")]
        public void Filter_MarkIsNotInteger_ThrowsArgumentException(string mark)
        {
            var searchString = "-mark " + mark;
            Assert.That(() => filter.Filter(searchString), Throws.ArgumentException);
        }

        [TestCase(1)]
        [TestCase(6)]
        [TestCase(100)]
        public void Filter_MarkIsOutOfRange_ThrowsArgumentException(int mark)
        {
            var searchString = "-mark " + mark;
            Assert.That(() => filter.Filter(searchString), Throws.ArgumentException);
        }

        [TestCase("..//")]
        [TestCase("0.09")]
        public void Filter_MinMarkIsNotInteger_ThrowsArgumentException(string mark)
        {
            var searchString = "-minmark " + mark;
            Assert.That(() => filter.Filter(searchString), Throws.ArgumentException);
        }

        [TestCase(1)]
        [TestCase(6)]
        [TestCase(0)]
        public void Filter_MinMarkIsOutOfRange_ThrowsArgumentException(int mark)
        {
            var searchString = "-minmark " + mark;
            Assert.That(() => filter.Filter(searchString), Throws.ArgumentException);
        }

        [Test]
        public void Filter_MinMarkIs4_Returns4Results()
        {
            var minmark = 4;

            var results = filter.Filter("-minmark " + minmark);

            Assert.That(results.Count(), Is.EqualTo(4));
            Assert.That(results.All(result => result.Mark >= minmark), Is.True);
        }

        [TestCase("text")]
        [TestCase("2E+15")]
        public void Filter_MaxMarkIsNotInteger_ThrowsArgumentException(string mark)
        {
            var searchString = "-maxmark " + mark;
            Assert.That(() => filter.Filter(searchString), Throws.ArgumentException);
        }

        [TestCase(1)]
        [TestCase(6)]
        [TestCase(1000)]
        public void Filter_MaxMarkIsOutOfRange_ThrowsArgumentException(int mark)
        {
            var searchString = "-maxmark " + mark;
            Assert.That(() => filter.Filter(searchString), Throws.ArgumentException);
        }

        [Test]
        public void Filter_MaxMarkIs3_Returns2Results()
        {
            var maxmark = 3;

            var results = filter.Filter("-maxmark " + maxmark);

            Assert.That(results.Count(), Is.EqualTo(2));
            Assert.That(results.All(result => result.Mark <= maxmark), Is.True);
        }
    }
}
