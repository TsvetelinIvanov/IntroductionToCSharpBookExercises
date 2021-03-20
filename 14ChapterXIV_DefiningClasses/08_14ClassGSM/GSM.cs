namespace _08_14ClassGSM
{
    public class GSM
    {
        private static GSM nokiaN95 = new GSM("Nokia N95", "Nokia", 99.9m, "unknown", "BL-6F", 12, 12, 4.3, 4096);

        private string model;
        private string manufacturer;
        private decimal price;
        private string owner;
        private Battery battery;
        private Display display;

        public GSM(string model, string manufacturer, decimal price, string owner)
        {
            this.Model = model;
            this.Manufacturer = manufacturer;
            this.Price = price;
            this.Owner = owner;
            this.Battery = new Battery();
            this.Display = new Display();
        }

        public GSM(string model, string manufacturer, decimal price, string owner, string batteryModel, int hoursIdle, int hoursTalk, BatteryType batteryType, double displaySize, int displayColors)
        {
            this.Model = model;
            this.Manufacturer = manufacturer;
            this.Price = price;
            this.Owner = owner;
            this.Battery = new Battery(batteryModel, hoursIdle, hoursTalk, batteryType);
            this.Display = new Display(displaySize, displayColors);
        }

        public GSM(string model, string manufacturer, decimal price, string owner, string batteryModel, int hoursIdle, int hoursTalk, double displaySize, int displayColors) : this(model, manufacturer, price, owner, batteryModel, hoursIdle, hoursTalk, BatteryType.LiIon, displaySize, displayColors)
        {
            
        }

        public static GSM NokiaN95
        {
            get { return nokiaN95; }
        }

        public string Model
        {
            get { return this.model; }
            set { this.model = value; }
        }

        public string Manufacturer
        {
            get { return this.manufacturer; }
            set { this.manufacturer = value; }
        }

        public decimal Price
        {
            get { return this.price; }
            set { this.price = value; }
        }

        public string Owner
        {
            get { return this.owner; }
            set { this.owner = value; }
        }       

        public Battery Battery
        {
            get { return this.battery; }
            set { this.battery = value; }
        }

        public Display Display
        {
            get { return this.display; }
            set { this.display = value; }
        }

        public static string GetNokiaN95()
        {
            return NokiaN95.ToString();
        }

        public override string ToString()
        {
            return $"Model: {this.Model}; Manufacturer: {this.Manufacturer}; Price: {this.Price:f2}; Owner: {this.Owner}; Battery: {this.Battery}; Display: {this.Display}.";
        }
    }
}