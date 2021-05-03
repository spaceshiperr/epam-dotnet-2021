using System;
using System.Diagnostics;
using System.Threading;

namespace Perfomance
{
    class Program
    {
        public const int Count = 100000;

        public class C
        {
            public int i;
        }

        public struct S
        {
            public int i;
        }

        private static string GetElapsedTime(Stopwatch stopWatch)
        {
            var ts = stopWatch.Elapsed;
            string elapsedTime = string.Format("{0:00}h:{1:00}m:{2:00}s.{3:00}ms",
                                                ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
            return elapsedTime;
        }

        private static long GetDifference(long x, long y)
        {
            return y - x;
        }

        static void Main(string[] args)
        {
            Random random = new Random();
            var process = Process.GetCurrentProcess();

            var classMemorySizeBefore = process.PrivateMemorySize64;

            C[] classArray = new C[Count];

            for (int i = 0; i < Count; i++)
            {
                classArray[i] = new C() { i = random.Next() };
            }

            process.Refresh();

            var classMemorySizeAfter = process.PrivateMemorySize64;
            var structMemorySizeBefore = process.PrivateMemorySize64;

            S[] structArray = new S[Count];

            for (int i = 0; i < Count; i++)
            {
                structArray[i].i = random.Next();
            }

            process.Refresh();
            var structMemorySizeAfter = process.PrivateMemorySize64;
            var classDelta = GetDifference(classMemorySizeBefore, classMemorySizeAfter);
            var structDelta = GetDifference(structMemorySizeBefore, structMemorySizeAfter);

            Console.WriteLine("PrivateMemorySize64 delta for array of classes initialization: " + classDelta);
            Console.WriteLine("PrivateMemorySize64 delta for array of structs initialization: " + structDelta);

            Console.WriteLine("Initializing an array of classes takes up more memory than an array of structs. The difference: " + 
                              GetDifference(structDelta, classDelta));

            var stopWatch = new Stopwatch();

            stopWatch.Start();
            Array.Sort<C>(classArray, (x, y) => x.i.CompareTo(y.i));
            stopWatch.Stop();
            Console.WriteLine("Execution of Array.Sort for an array of classes: " + GetElapsedTime(stopWatch));

            stopWatch.Restart();
            Array.Sort<S>(structArray, (x, y) => x.i.CompareTo(y.i));
            stopWatch.Stop();
            Console.WriteLine("Execution of Array.Sort for an array of structs: " + GetElapsedTime(stopWatch));

            Console.ReadLine();
        }
    }
}
