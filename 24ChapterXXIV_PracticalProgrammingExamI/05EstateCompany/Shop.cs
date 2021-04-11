namespace _05EstateCompany
{
    public class Shop : Estate
    {
        public Shop(string location, int squareMeterArea, decimal squareMeterPrice) : base(location, squareMeterArea, squareMeterPrice)
        {

        }

        public override string ToString()
        {
            return base.ToString() + ".";
        }
    }
}