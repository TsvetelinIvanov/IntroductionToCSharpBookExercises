using _09AbstractFactory.Interfaces;

namespace _09AbstractFactory.Products
{
    public class ProductOne : IFirst
    {
        public string GetName()
        {
            return "First Product";
        }
    }
}