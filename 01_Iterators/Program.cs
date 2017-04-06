using System.Collections;

namespace _01_Iterators
{
    internal class Program
    {
        private static void Main()
        {
        }

        private static IEnumerator GetCounter()
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
