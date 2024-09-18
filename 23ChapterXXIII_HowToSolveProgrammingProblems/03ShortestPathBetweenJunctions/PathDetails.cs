namespace _03ShortestPathBetweenJunctions
{
    public class PathDetails
    {        
        public PathDetails(bool isReversed)
        {
            this.IsReversed = isReversed;
            this.Road = string.Empty;
            this.Cost = 0;            
        }

        public bool IsReversed { get; }
        
        public string Road { get; set; }
        
        public int Cost { get; set; }        
    }
}
