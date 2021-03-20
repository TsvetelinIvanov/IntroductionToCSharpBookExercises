namespace _08_14ClassGSM
{
    public class Battery
    {
        private string batteryModel;
        private int hoursIdle;
        private int hoursTalk;        
        private BatteryType batteryType;

        public Battery(string batteryModel, int hoursIdle, int hoursTalk, BatteryType batteryType)
        {
            this.batteryModel = batteryModel;
            this.hoursIdle = hoursIdle;
            this.hoursTalk = hoursTalk;            
            this.batteryType = batteryType;
        }

        public Battery(string batteryModel, int hoursIdle, int hoursTalk) : this(batteryModel, hoursIdle, hoursTalk, BatteryType.LiIon)
        {            
            
        }

        public Battery() : this("BL-6F", 1, 1)
        {
            
        }

        public string BatteryModel
        {
            get { return this.batteryModel; }
        }

        public int HoursIdle
        {
            get { return this.hoursIdle; }
        }

        public int HoursTalk
        {
            get { return this.hoursTalk; }
        }        

        public BatteryType BatteryType
        {
            get { return this.batteryType; }
        }

        public override string ToString()
        {
            return $"Hours Idle: {this.HoursIdle}, Hours Talk: {this.HoursTalk}, Battery Model: {this.BatteryModel}, Battery Type: {this.BatteryType}";
        }
    }
}