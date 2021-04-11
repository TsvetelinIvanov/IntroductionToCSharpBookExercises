namespace _05EstateCompany
{
    public class Area : Estate
    {
        public Area(string location, int squareMeterArea, decimal squareMeterPrice) : base(location, squareMeterArea, squareMeterPrice)
        {

        }

        public override string ToString()
        {
            return base.ToString() + ".";
        }
    }
}