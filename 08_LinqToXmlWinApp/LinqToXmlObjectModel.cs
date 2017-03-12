using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace _08_LinqToXmlWinApp
{
    public class LinqToXmlObjectModel
    {
        public static XDocument GetXmlInventory()
        {
            try
            {
                return XDocument.Load("Inventory.xml");
            }
            catch (FileNotFoundException e)
            {
                MessageBox.Show(e.Message);                
            }
            return null;
        }

        public static void InsertNewElement(string make, string color, string petName)
        {
            // Load document
            var inventoryDoc = XDocument.Load("Inventory.xml");

            // Generate random number for ID
            var r = new Random();

            // Make new XML element based on input parameters
            var newElement = new XElement("Car", new XAttribute("ID", r.Next(50000)),
                new XElement("Color", color),
                new XElement("Make", make),
                new XElement("PetName", petName));

            // Add to in-mem object
            inventoryDoc.Descendants("Inventory").First().Add(newElement);

            // Save document
            inventoryDoc.Save("Inventory.xml");
        }

        public static void LookUpColorsForMake(string make)
        {
            // Load current document
            var inventoryDoc = XDocument.Load("Inventory.xml");

            // Find the colors for a given make
            var makeInfo = inventoryDoc.Descendants("Car")
                .Where(c => (string) c.Element("Make") == make)
                .Select(c => c.Element("Color")?.Value);

            // Build string representation of each color
            var data = makeInfo.Distinct()
                .Aggregate(string.Empty, (current, item) => current + $"- {item}\n");

            // Show colors
            MessageBox.Show(data, $@"{make} colors: ");
        }
    }
}