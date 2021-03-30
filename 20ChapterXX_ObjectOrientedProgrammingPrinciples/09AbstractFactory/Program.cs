using _09AbstractFactory.Enums;
using System;

namespace _09AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Implementation of Abstract Factory Pattern:");

            ProductChecker checker = new ProductChecker(Manufacturer.ManufacturerOne);
            checker.CheckProducts();

            checker = new ProductChecker(Manufacturer.ManufacturerTwo);
            checker.CheckProducts();

            checker = new ProductChecker(Manufacturer.ManufacturerThree);
            checker.CheckProducts();
        }
    }
}