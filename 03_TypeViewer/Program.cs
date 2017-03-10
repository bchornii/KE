using System;
using System.Linq;

namespace _03_TypeViewer
{
    internal class Program
    {
        private static void Main()
        {
            Console.WriteLine("***** Welcome to MyTypeViewer *****");

            do
            {
                Console.WriteLine("\nEnter a type name to evaluate");
                Console.Write("or enter Q to quit: ");
                // Get name of type.
                var typeName = Console.ReadLine();
                // Does user want to quit?
                if (typeName?.ToUpper() == "Q")
                {
                    break;
                }

                // Try to display type.
                try
                {
                    var t = Type.GetType(typeName, false);
                    Console.WriteLine("");
                    ListVariousStats(t);
                    ListFields(t);
                    ListProperties(t);
                    ListMethods(t);
                    ListInterfaces(t);
                }
                catch
                {
                    Console.WriteLine("Sorry, can't find type");
                }
            } while (true);
        }

        private static void ListMethods(Type type)
        {
            Console.WriteLine("**** Methods ****");
            var mi = type.GetMethods();
            //foreach (var methodInfo in mi)
            //{
            //    // Get return type
            //    var retVal = methodInfo.ReturnType.FullName;
            //    var methodParams = methodInfo.GetParameters()
            //        .Aggregate("(", (current, methodParam) => current + $"{methodParam.ParameterType} {methodParam.Name}");
            //    methodParams += ")";
            //    Console.WriteLine($"-> {retVal} {methodInfo.Name} {methodParams}");
            //}
            // because each of the XXXInfo types has overriden ToString method we could do
            foreach (var methodInfo in mi)
            {
                Console.WriteLine($"-> {methodInfo}");
            }
            Console.WriteLine();
        }

        private static void ListFields(Type type)
        {
            Console.WriteLine("**** Fields ****");
            var fi = type.GetFields().Select(f => f.Name);
            foreach (var fieldName in fi)
            {
                Console.WriteLine($"-> {fieldName}");
            }
            Console.WriteLine();
        }

        private static void ListProperties(Type type)
        {
            Console.WriteLine("**** Properties ****");
            var pr = type.GetProperties().Select(p => p.Name);
            foreach (var propName in pr)
            {
                Console.WriteLine($"-> {propName}");
            }
            Console.WriteLine();
        }

        private static void ListInterfaces(Type type)
        {
            Console.WriteLine("**** Interfaces ****");
            var ifaces = type.GetInterfaces();
            foreach (var iface in ifaces)
            {
                Console.WriteLine($"-> {iface.Name}");
            }
            Console.WriteLine();
        }

        // Just for good measure.
        private static void ListVariousStats(Type t)
        {
            Console.WriteLine("***** Various Statistics *****");
            Console.WriteLine("Base class is: {0}", t.BaseType);
            Console.WriteLine("Is type abstract? {0}", t.IsAbstract);
            Console.WriteLine("Is type sealed? {0}", t.IsSealed);
            Console.WriteLine("Is type generic? {0}", t.IsGenericTypeDefinition);
            Console.WriteLine("Is type a class type? {0}", t.IsClass);
            Console.WriteLine();
        }
    }
}
