namespace _08_14ClassGSM
{
    public class Display
    {
        private double displaySize;
        private int displayColors;

        public Display()
        {
            this.displaySize = 4.3;
            this.displayColors = 4096;
        }

        public Display(double displaySize, int displayColors)
        {            
            this.displaySize = displaySize;
            this.displayColors = displayColors;
        }

        public double DisplaySize
        {
            get { return this.displaySize; }
        }

        public int DisplayColors
        {
            get { return this.displayColors; }
        }

        public override string ToString()
        {
            return $"Display Size: {this.DisplaySize}, Display Colors: {this.DisplayColors}";
        }
    }
}