using System.Collections.Generic;
using System.Numerics;

namespace GenericsLibrary
{
    public static class FibonacciNumbers
    {
        public static IEnumerable<BigInteger> GetNumbers()
        {
            BigInteger previous = 0;
            BigInteger current = 1;

            while(true)
            {
                yield return current;

                var next = previous + current;
                previous = current;
                current = next;
            }
        }
    }
}
