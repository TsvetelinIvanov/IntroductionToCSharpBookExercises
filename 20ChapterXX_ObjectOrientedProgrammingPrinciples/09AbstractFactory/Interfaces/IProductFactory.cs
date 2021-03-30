namespace _09AbstractFactory.Interfaces
{
    public interface IProductFactory
    {
        IFirst GetFirst();

        ISecond GetSecond();
    }
}