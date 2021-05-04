using System;
using System.Collections.Generic;

namespace Students
{
    class Program
    {

        static string GetRandomElement(Random random, string[] array)
        {
            return array[random.Next(0, array.Length)];
        }

        static HashSet<string> GetRandomHashSet(Random random, string[] array, int count)
        {
            var hashSet = new HashSet<string>();
            for (int i = 0; i < count; i++)
            {
                string element;
                do
                {
                    element = GetRandomElement(random, array);
                }
                while (hashSet.Contains(element));
                
                hashSet.Add(element);
            }

            return hashSet;
        }
        
        static void Main(string[] args)
        {
            var subjects = new string[] { "Math", "PE", "English", "Physics", "History", "French" };

            var student1c1 = new Student("rick.grimes@epam.com");
            var student2c1 = new Student("daryl.dixon@epam.com");
            var student3c1 = new Student("michonne.hawthorne@epam.com");

            var student1c2 = new Student("Rick", "Grimes");
            var student2c2 = new Student("Daryl", "Dixon");
            var student3c2 = new Student("Michonne", "Hawthorne");

            var studentSubjectDict = new Dictionary<Student, HashSet<string>>();

            var random = new Random();
            studentSubjectDict[student1c1] = GetRandomHashSet(random, subjects, 3);
            studentSubjectDict[student2c1] = GetRandomHashSet(random, subjects, 3);
            studentSubjectDict[student3c1] = GetRandomHashSet(random, subjects, 3);
            studentSubjectDict[student1c2] = GetRandomHashSet(random, subjects, 3);
            studentSubjectDict[student2c2] = GetRandomHashSet(random, subjects, 3);
            studentSubjectDict[student3c2] = GetRandomHashSet(random, subjects, 3);

            Console.WriteLine(studentSubjectDict.Count == 3);
            Console.ReadLine();
        }
    }
}
