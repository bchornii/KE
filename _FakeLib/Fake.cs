using System;

namespace _FakeLib
{
    public class Fake
    {
        public void Method1()
        {
            Console.WriteLine("Method #1 from fake class in Fake assembly");
        }

        public void Method2(bool p1, int p2)
        {
            Console.WriteLine($"Method #2 from fake class parameters: p1: {p1}, p2: {p2}");
        }
    }
}
