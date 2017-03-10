using System;
using System.IO;
using System.Reflection;

namespace _05_LateBindingApp
{
    internal class Program
    {
        private static void Main()
        {
            Console.WriteLine("***** Fun with Late Binding *****");
            Assembly a = null;

            try
            {
                a = Assembly.Load("_FakeLib");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            if (a != null)
                CreateUsingLateBinding(a);

            Console.ReadLine();
        }

        private static void CreateUsingLateBinding(Assembly asm)
        {
            try
            {
                // Get metadata for the Minivan type.
                var fake = asm.GetType("_FakeLib.Fake");

                // Create the Minivan on the fly.
                var obj = Activator.CreateInstance(fake);
                Console.WriteLine("Created a {0} using late binding!", obj);

                // Get method info
                var mi = fake.GetMethod("Method2");

                // Invoke method
                mi.Invoke(obj, new object[] { true, 10 });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
