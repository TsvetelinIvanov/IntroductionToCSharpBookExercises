namespace _03ShortestPathBetweenJuctions
{
    public class RequestedPath
    {
        public RequestedPath(string start, string destination, bool areInTheSameComponent, bool areEqual, bool areReversed)
        {
            this.Start = start;
            this.Destination = destination;
            this.AreInTheSameComponent = areInTheSameComponent;
            this.AreEqual = areEqual;
            this.AreReversed = areReversed;
        }

        public string Start { get; }
        
        public string Destination { get; }
        
        public bool AreInTheSameComponent { get; }
        
        public bool AreEqual { get; }
        
        public bool AreReversed { get; }        
    }
}