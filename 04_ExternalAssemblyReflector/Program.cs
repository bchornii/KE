using System;
using System.Reflection;

// Assembly name constist of:
// 1 - Name
// 2 - Version
// 3 - Public key
// 4 - Culture

namespace _04_ExternalAssemblyReflector
{
    internal class Program
    {
        private static void Main()
        {
            Console.WriteLine("***** External Assembly Viewer *****");

            do
            {
                Console.WriteLine("\nEnter an assembly to evaluate");
                Console.Write("or enter Q to quit: ");

                // Get name of assembly.
                var asmName = Console.ReadLine();

                // Does the user want to quit?
                if (asmName?.ToUpper() == "Q")
                {
                    break;
                }

                // Try to load assembly
                try
                {
                    var assembly = Assembly.LoadFrom(asmName ?? string.Empty);
                    DisplayTypesInAssembly(assembly);
                }
                catch
                {
                    Console.WriteLine("Sorry, can't find assembly.");
                }

            } while (true);
        }

        private static void DisplayTypesInAssembly(Assembly assembly)
        {
            Console.WriteLine("\n***** Types in Assembly *****");
            Console.WriteLine($"-> {assembly.FullName}");
            var types = assembly.GetTypes();
            foreach (var type in types)
            {
                Console.WriteLine($"Type: {type}");
            }
            Console.WriteLine();
        }
    }
}
