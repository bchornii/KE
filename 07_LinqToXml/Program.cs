using System;
using System.Linq;
using System.Xml.Linq;

namespace _07_LinqToXml
{
    internal class Program
    {
        private static void Main()
        {
            ParseAndLoadExistingXml();
            Console.Read();
        }

        private static void PrintSimpleXml()
        {
            XElement doc =
                new XElement("Inventory",
                    new XElement("Car", new XAttribute("ID", "1000"),
                        new XElement("PetName", "Jimbo"),
                        new XElement("Color", "Red"),
                        new XElement("Make", "Ford")
                    )
                );

            doc.Descendants("PetName").Remove();
            Console.WriteLine(doc);
        }

        private static void CreateFullXDocument()
        {
            XDocument inventoryDoc =
                new XDocument(
                    new XDeclaration("1.0", "utf-8", "yes"),
                    new XComment("Current Inventory of cars!"),
                    new XProcessingInstruction("xml-stylesheet",
                        "href='MyStyles.css' title='Compact' type='text/css'"),
                    new XElement("Inventory",
                        new XElement("Car", new XAttribute("ID", "1"),
                            new XElement("Color", "Green"),
                            new XElement("Make", "BMW"),
                            new XElement("PetName", "Stan")
                        ),
                        new XElement("Car", new XAttribute("ID", "2"),
                            new XElement("Color", "Pink"),
                            new XElement("Make", "Yugo"),
                            new XElement("PetName", "Melvin")
                        )
                    )
                );
            inventoryDoc.Save("Inventory.xml");
            //Console.WriteLine(inventoryDoc);
        }

        private static void CreateRootAndChildren()
        {
            XElement inventoryDoc =
                new XElement("Inventory",
                    new XComment("Current Inventory of cars!"),
                    new XElement("Car", new XAttribute("ID", "1"),
                        new XElement("Color", "Green"),
                        new XElement("Make", "BMW"),
                        new XElement("PetName", "Stan")
                    ),
                    new XElement("Car", new XAttribute("ID", "2"),
                        new XElement("Color", "Pink"),
                        new XElement("Make", "Yugo"),
                        new XElement("PetName", "Melvin")
                    )
                );
            // Save to disk.
            inventoryDoc.Save("SimpleInventory.xml");
        }

        private static void MakeXElementFromArray()
        {
            // Create an anonymous array of anonymous types.
            var people = new[]
            {
                new {FirstName = "Mandy", Age = 32},
                new {FirstName = "Andrew", Age = 40},
                new {FirstName = "Dave", Age = 41},
                new {FirstName = "Sara", Age = 31}
            };

            var arrDataAsXElement = people.Select(p => new XElement("Person",
                new XAttribute("Age", p.Age),
                new XElement("FirstName", p.FirstName)
            ));
            var peopleDoc = new XElement("People", arrDataAsXElement);           

            Console.WriteLine(peopleDoc);
        }

        private static void ParseAndLoadExistingXml()
        {
            // Build an XElement from string.
            var myElement =
                @"<Car ID ='3'>
                    <Color>Yellow</Color>
                    <Make>Yugo</Make>
                  </Car>";

            var newElement = XElement.Parse(myElement);
            Console.WriteLine(newElement);
            Console.WriteLine();

            Console.WriteLine(new string('-', 80));

            // Load the SimpleInventory.xml file.
            XDocument myDoc = XDocument.Load("SimpleInventory.xml");
            Console.WriteLine(myDoc);
        }
    }
}
