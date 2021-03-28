using System;
using System.Text;

namespace _09Cars
{
    class Program
    {
        static void Main(string[] args)
        {
            CarCatalogue carCatalogue = new CarCatalogue();
            StringBuilder outputBuilder = new StringBuilder();
            while (true)
            {                
                string[] commandLine = Console.ReadLine().Split();
                string command = commandLine[0];
                if (command == "Add")
                {
                    outputBuilder.AppendLine(carCatalogue.Add(new Car(commandLine[1], commandLine[2], commandLine[3], int.Parse(commandLine[4]), decimal.Parse(commandLine[5]))));
                }
                else if (command == "GetByBrandAndModel")
                {
                    bool[] usedProperties = { true, true, false, false };
                    outputBuilder.AppendLine(carCatalogue.GetCarsByName(new Car(commandLine[1], commandLine[2], string.Empty, 0, 0), usedProperties));
                }                
                else if (command == "GetByYearRange")
                {
                    outputBuilder.AppendLine(carCatalogue.YearSearch(int.Parse(commandLine[1]), int.Parse(commandLine[2])));
                }
                else if (command == "GetByPriceRange")
                {
                    outputBuilder.AppendLine(carCatalogue.PriceSearch(decimal.Parse(commandLine[1]), decimal.Parse(commandLine[2])));
                }
                else if (command == "End")
                {
                    break;
                }
            }

            Console.Write(outputBuilder);
        }
    }
}