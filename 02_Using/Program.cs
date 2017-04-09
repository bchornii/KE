using System;

namespace _02_Using
{
    internal class Program
    {
        private static void Main()
        {
            try
            {
                var test = new Test(10);

                // check hash code
                Console.WriteLine(test.GetHashCode());

                // if we you 'test' var in using then using will create
                // copy of that var and in case of struct this copy will not point
                // to original obj as in case with ref types (because of reference is being copied)
                // and that is why original resources will not be disposed
                // check for hash code is confirmed that in using statement when we work with struct
                // hash codes differs btw hash before and in using statement
                // change Test from struct to class and you will see the diff in behaviour
                using (test)
                {
                    //test.DoWork();
                    Console.WriteLine("Body of using");

                    // check hash code
                    Console.WriteLine(test.Marker);
                }
                Console.WriteLine(test.GetHashCode());
                Console.WriteLine(test.Marker);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);                
            }

            Console.Read();
        }
    }

    public struct Test : IDisposable
    {
        public int Marker { get; set; }        

        public Test(int marker)
        {
            Marker = marker;
        }

        public void DoWork()
        {
            throw new NotImplementedException();
        }
        public void Dispose()
        {
            //throw new NotImplementedException();
            Marker = 5;

            // check hash code
            Console.WriteLine(GetHashCode());
        }
    }
}
