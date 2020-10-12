using Cache.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;

namespace CachingSolutionsSamples
{
    [TestClass]
    public class Tests1
    {
        private readonly string _fibonacciPrefix = "_fibonacci";

        [TestMethod]
        public void FibonacciMemoryCache()
        {
            var fibonacci = new Fibonacci(new MemoryCache<int>(_fibonacciPrefix));

            for (var i = 1; i < 20; i++)
            {
                Console.WriteLine(fibonacci.Count(i));
                Thread.Sleep(100);
            }
        }

        [TestMethod]
        public void FibonacciRedisCache()
        {
            var fibonacci = new Fibonacci(new RedisCache<int>("127.0.0.1", _fibonacciPrefix));

            for (var i = 1; i < 20; i++)
            {
                Console.WriteLine(fibonacci.Count(i));
                Thread.Sleep(100);
            }
        }
    }
}