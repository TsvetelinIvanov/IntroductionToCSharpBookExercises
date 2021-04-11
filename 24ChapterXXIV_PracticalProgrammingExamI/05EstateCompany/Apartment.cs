namespace _05EstateCompany
{
    public class Apartment : Estate
    {
        private int floor;

        public Apartment(string location, int squareMeterArea, decimal squareMeterPrice, int floor, bool hasElevator, bool isFurnished) : base(location, squareMeterArea, squareMeterPrice)
        {
            this.floor = floor;
            this.HasElevator = hasElevator;
            this.IsFurnished = isFurnished;
        }

        public bool HasElevator { get; set; }

        public bool IsFurnished { get; set; }

        public override string ToString()
        {
            string elevatorPresence = this.HasElevator ? "Yes" : "No";
            string furniturePresence = this.IsFurnished ? "Yes" : "No";
            return base.ToString() + $", Floor: {this.floor}, Elevator: {elevatorPresence}, Furnished: {furniturePresence}.";
        }
    }
}