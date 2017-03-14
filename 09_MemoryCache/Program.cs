using System;
using System.Collections.Generic;
using System.Runtime.Caching;
using System.Threading;

namespace _09_MemoryCache
{
    internal class Program
    {
        private static readonly List<string> _list = new List<string>
        {
            "hellO",
            "my",
            "dear",
            "memoty",
            "cache"
        };

        private static void Main()
        {
            foreach (var s in GetStrings("key"))
            {
                Console.WriteLine(s);
            }

            Console.WriteLine(new string('-', 80));

            foreach (var s in GetStrings("key"))
            {
                Console.WriteLine(s);
            }

            Console.Read();
        }

        private static IEnumerable<string> GetStrings(string key)
        {
            var cache = MemoryCache.Default;

            if (cache.Contains(key))
            {
                return cache.Get(key) as IEnumerable<string>;
            }
            var list = GetFromRepo();

            // Store data in cache
            var cacheItemPolicy = new CacheItemPolicy
            {
                AbsoluteExpiration = DateTime.Now.AddHours(1.0)
                    
            };
            cache.Add(key, list, cacheItemPolicy);
            return list;
        }        

        private static IEnumerable<string> GetFromRepo()
        {
            Thread.Sleep(10000);
            return _list;
        }
    }
}
