using Cache.Infrastructure;
using System;

namespace CachingSolutionsSamples
{
    public class Fibonacci
    {
        private readonly ICache<int> _cache;

        public Fibonacci(ICache<int> cache)
        {
            _cache = cache;
        }

        public int Count(int index)
        {
            if (index <= 0)
            {
                throw new ArgumentException($"{nameof(index)} must be positive number");
            }

            if (index == 1 || index == 2)
            {
                return 1;
            }

            int cacheValue = _cache.Get(index.ToString());

            if (cacheValue != default(int))
            {
                Console.WriteLine($"From cache: {cacheValue}");
                return cacheValue;
            }

            int result = Count(index - 1) + Count(index - 2);
            Console.WriteLine($"Computed: {result}");

            _cache.Set(index.ToString(), result, DateTimeOffset.Now.AddMilliseconds(300));
            return result;
        }
    }
}