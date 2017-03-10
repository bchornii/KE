using System;
using System.Linq;
using System.Reflection;

namespace _06_ApplyingAttributes
{
    internal class Program
    {
        private static void Main()
        {
            Console.WriteLine("***** Value of VehicleDescriptionAttribute *****\n");
            ReflectOnAttrsUsingEarlyBinding();
            Console.Read();
        }

        // Reflect on attrib using early binding
        private static void ReflectOnAttrsUsingEarlyBinding()
        {
            // Get type
            var type = typeof(Motorcycle);

            //// Get all atribs on Motorcycle
            //var customAttrs = type.GetCustomAttributes(false)
            //    .OfType<VehicleDescriptionAttribute>();          
            //
            //// Print the description
            //foreach (var customAttr in customAttrs)
            //{
            //    Console.WriteLine($"-> {customAttr.Description}");
            //}

            // Another wat to get attribute
            var customAttrs = type.GetCustomAttribute<VehicleDescriptionAttribute>();
            Console.WriteLine($"-> {customAttrs.Description}");
        }
    }

    // This class can be saved to disk.
    [Serializable]
    //[Obsolete("Use another vehicle!")]
    [VehicleDescription("This is great vehicle")]
    public class Motorcycle
    {
        //static Motorcycle() { }

        // However, this field will not be persisted.
        [NonSerialized] private float weightOfCurrentPassengers;

        // These fields are still serializable.
        private bool hasRadioSystem;
        private bool hasHeadSet;
        private bool hasSissyBar;
    }

    // A custom attribute.
    public sealed class VehicleDescriptionAttribute : Attribute
    {
        public string Description { get; set; }
        public VehicleDescriptionAttribute(string vehicalDescription)
        {
            Description = vehicalDescription;
        }
        public VehicleDescriptionAttribute() { }
    }
}
