namespace _05EstateCompany
{
    public class House : Estate
    {
        public House(string location, int squareMeterArea, decimal squareMeterPrice, int builtUpSquareMeterArea, int notBuiltUpSquareMeterArea, int floorsCount, bool isFurnished) : base(location, squareMeterArea, squareMeterPrice)
        {
            this.BuiltUpSquareMeterArea = builtUpSquareMeterArea;
            this.NotBuiltUpSquareMeterArea = notBuiltUpSquareMeterArea;
            this.FloorsCount = floorsCount;
            this.IsFurnished = isFurnished;
        }

        public int BuiltUpSquareMeterArea { get; set; }

        public int NotBuiltUpSquareMeterArea { get; set; }

        public int FloorsCount { get; set; }

        public bool IsFurnished { get; set; }

        public override string ToString()
        {
            string furniturePresence = this.IsFurnished ? "Yes" : "No";
            
            return base.ToString() + $", Built Up Area: {this.BuiltUpSquareMeterArea} square meters, Not Built Up Area: {this.NotBuiltUpSquareMeterArea} square meters, Floors: {this.FloorsCount}, Furnished: {furniturePresence}.";
        }
    }
}
