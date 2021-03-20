using System.Collections.Generic;
using System.Text;

namespace _15_19GSMCallHistory
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
        private List<Call> callHistory;

        public GSM(string model, string manufacturer, decimal price, string owner)
        {
            this.Model = model;
            this.Manufacturer = manufacturer;
            this.Price = price;
            this.Owner = owner;
            this.Battery = new Battery();
            this.Display = new Display();
            this.CallHistory = new List<Call>();
        }

        public GSM(string model, string manufacturer, decimal price, string owner, string batteryModel, int hoursIdle, int hoursTalk, BatteryType batteryType, double displaySize, int displayColors)
        {
            this.Model = model;
            this.Manufacturer = manufacturer;
            this.Price = price;
            this.Owner = owner;
            this.Battery = new Battery(batteryModel, hoursIdle, hoursTalk, batteryType);
            this.Display = new Display(displaySize, displayColors);
            this.CallHistory = new List<Call>();
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

        public List<Call> CallHistory
        {
            get { return callHistory; }
            set { callHistory = value; }
        }


        public static string GetNokiaN95()
        {
            return NokiaN95.ToString();
        }

        public void AddCall(string date, string time, int duration)
        {            
            this.CallHistory.Add(new Call(date, time, duration));
        }

        public void DeleteCall(Call callToRemove)
        {
            this.CallHistory.Remove(callToRemove);
        }

        public void ClearCallHistory()
        {
            this.CallHistory.Clear();
        }

        public string GetCallHistory()
        {
            StringBuilder callHistoryBuilder = new StringBuilder();
            foreach (Call call in this.CallHistory)
            {
                callHistoryBuilder.AppendLine(call.ToString());
            }

            return callHistoryBuilder.ToString().TrimEnd();
        }

        public string CalculateBill(decimal pricePerMinute)
        {
            decimal bill = 0;
            foreach (Call call in this.CallHistory)
            {
                bill += call.Duration * pricePerMinute;
            }

            return $"{bill:f2} lv.";
        }


        public override string ToString()
        {
            return $"Model: {this.Model}; Manufacturer: {this.Manufacturer}; Price: {this.Price:f2}; Owner: {this.Owner}; Battery: {this.Battery}; Display: {this.Display}.";
        }
    }
}