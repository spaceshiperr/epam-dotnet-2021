using System;

namespace DelegateApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var pub = new Countdown();

            var ts = new TimeSpan(0, 0, 10);

            var sub1 = new Subscriber("sub1", pub, ts);
            var sub2 = new Subscriber("sub2", pub, ts);

            pub.DoSomething();

            Console.ReadLine();
        }
    }
}
