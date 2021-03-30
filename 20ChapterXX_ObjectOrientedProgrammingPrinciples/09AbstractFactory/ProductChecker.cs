using _09AbstractFactory.Enums;
using _09AbstractFactory.Factories;
using _09AbstractFactory.Interfaces;
using System;

namespace _09AbstractFactory
{
    public class ProductChecker
    {
        private IProductFactory factory;
        private Manufacturer manufacturer;

        public ProductChecker(Manufacturer manufacturer)
        {
            this.manufacturer = manufacturer;
        }

        public void CheckProducts()
        {
            switch (manufacturer)
            {
                case Manufacturer.ManufacturerOne:
                    factory = new ManufacturerOneFactory();
                    break;
                case Manufacturer.ManufacturerTwo:
                    factory = new ManufacturerTwoFactory();
                    break;
                case Manufacturer.ManufacturerThree:
                    factory = new ManufacturerThreeFactory();
                    break;
            }
            
            Console.WriteLine($"{manufacturer}: First Product -> {factory.GetFirst().GetName()}; Second Product: -> {factory.GetSecond().GetName()}.");
        }
    }
}