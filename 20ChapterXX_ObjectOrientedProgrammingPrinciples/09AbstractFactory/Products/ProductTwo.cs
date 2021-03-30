using _09AbstractFactory.Interfaces;

namespace _09AbstractFactory.Products
{
    public class ProductTwo : ISecond
    {
        public string GetName()
        {
            return "Second product";
        }
    }
}