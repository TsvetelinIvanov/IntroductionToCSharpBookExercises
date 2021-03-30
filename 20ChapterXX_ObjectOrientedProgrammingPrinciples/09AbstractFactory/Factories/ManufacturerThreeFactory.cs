using _09AbstractFactory.Interfaces;
using _09AbstractFactory.Products;

namespace _09AbstractFactory.Factories
{
    public class ManufacturerThreeFactory : IProductFactory
    {
        public IFirst GetFirst()
        {
            return new ProductOne();
        }

        public ISecond GetSecond()
        {
            return new ProductTwo();
        }
    }
}