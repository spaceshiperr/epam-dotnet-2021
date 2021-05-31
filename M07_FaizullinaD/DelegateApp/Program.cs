using System;

namespace DelegateApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var pub = new Countdown();
            
            var sub1 = new Subscriber("sub1", pub);
            var sub2 = new Subscriber("sub2", pub);

            var ts = new TimeSpan(0, 0, 10);
            pub.DoSomething("important message", ts);

            Console.ReadLine();
        }
    }
}
