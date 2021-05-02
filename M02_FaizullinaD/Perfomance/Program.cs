using System;
using System.Diagnostics;

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
        
        static void Main(string[] args)
        {
            Random random = new Random();
            var process = Process.GetCurrentProcess();
            
            Console.WriteLine("PrivateMemorySize64 before initializing an array of classes: " + process.PrivateMemorySize64);

            C[] classArray = new C[Count];

            for (int i = 0; i < Count; i++)
            {
                classArray[i] = new C() { i = random.Next() };
            }

            process.Refresh();
            Console.WriteLine("PrivateMemorySize64 after initializing an array of classes: " + process.PrivateMemorySize64);
            Console.WriteLine("PrivateMemorySize64 before initializing an array of structs: " + process.PrivateMemorySize64);

            S[] structArray = new S[Count];

            for (int i = 0; i < Count; i++)
            {
                structArray[i].i = random.Next();
            }

            process.Refresh();
            Console.WriteLine("PrivateMemorySize64 after initializing an array of structs: " + process.PrivateMemorySize64);
        }
    }
}
