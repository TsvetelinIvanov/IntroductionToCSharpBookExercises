namespace _04MusicCompany
{
    public class Song
    {
        private string name;
        private double minutesLength;

        public Song(string name, double minutesLength)
        {
            this.name = name;
            this.minutesLength = minutesLength;
        }

        public override string ToString()
        {
            return $"Song: {this.name}, Time: {this.minutesLength:f2} min";
        }
    }
}