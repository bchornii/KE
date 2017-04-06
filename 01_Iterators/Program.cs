using System;
using System.Collections;
using System.Collections.Generic;

namespace _01_Iterators
{
    internal class Program
    {
        private static void Main()
        {
            foreach (var val in GetCounter())
            {
                Console.WriteLine(val);
            }

            Console.Read();
        }

        // yield - будує стейт машину ітератора
        // під капотом буде ітератор пропертя current якого
        // буде отримувати значення, які визначаються при виконанні коду
        // стейт машини
        private static IEnumerable<int> GetCounter()
        {
            for (var count = 0; count < 10; count++)
            {
                yield return count;
            }

            var a = 10;
            switch (a)
            {
                case 5:
                    yield return 5;
                    break;
                case 10:
                    yield return 10;
                    break;
            }
        }
    }
}
