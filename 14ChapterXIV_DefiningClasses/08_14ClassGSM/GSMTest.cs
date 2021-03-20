using System.Text;

namespace _08_14ClassGSM
{
    public class GSMTest
    {
        private const string Model = "Galaxy J6+";
        private const string Manufacturer = "Samsung";
        private const decimal Price = 599.99m;
        private const string Owner = "Ivan Ivanov";
        private const string BatteryModel = "EB-BJ800ABE";
        private const int HoursIdle = 168;
        private const int HoursTalk = 48;
        private const BatteryType BatteryType1 = BatteryType.LiIon;
        private const double DisplaySze = 5.6;
        private const int DisplayColors = 16000;

        public static string TestGSM()
        {
            GSM[] gsms = new GSM[]
            {
                new GSM(Model, Manufacturer, Price, Owner),
                new GSM(Model, Manufacturer, Price, Owner, BatteryModel, HoursIdle, HoursTalk, BatteryType1, DisplaySze, DisplayColors),
                new GSM(Model, Manufacturer, Price, Owner, BatteryModel, HoursIdle, HoursTalk, DisplaySze, DisplayColors)
            };

            StringBuilder gsmBuilder = new StringBuilder();
            foreach (GSM gsm in gsms)
            {
                gsmBuilder.AppendLine(gsm.ToString());
            }

            gsmBuilder.Append(GSM.GetNokiaN95());

            return gsmBuilder.ToString();
        }
    }
}
