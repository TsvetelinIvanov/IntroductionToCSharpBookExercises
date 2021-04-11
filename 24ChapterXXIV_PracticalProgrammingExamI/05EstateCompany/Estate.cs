namespace _05EstateCompany
{
    public abstract class Estate
    {
        private string location;

        public Estate(string location, int squareMeterArea, decimal squareMeterPrice)
        {
            this.location = location;
            this.SquareMeterArea = squareMeterArea;
            this.SquareMeterPrice = squareMeterPrice;
        }

        public int SquareMeterArea { get; set; }

        public decimal SquareMeterPrice { get; set; }

        public decimal TotalPrice => this.SquareMeterArea * this.SquareMeterPrice;

        public override string ToString()
        {
            return $"Type: {this.GetType().Name}, Area: {this.SquareMeterArea} square meters, Price: ${this.SquareMeterPrice:f2} per square meter (${TotalPrice:f2} in total), Location: {this.location}";
        }
    }
}