using System.Linq;
using System.Text;

namespace _15_19GSMCallHistory
{
    public class GSMCallHistoryTest
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

        private const string Date = "19.III.2021";
        private const string StartTime1 = "10:00";
        private const string StartTime2 = "10:30";
        private const string StartTime3 = "11:10";
        private const int Duration1 = 1;
        private const int Duration2 = 10;
        private const int Duration3 = 18;
        private const decimal PricePerMinute = 0.37m;

        public string TestGSM()
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

        public string TestCallHistory()
        {
            Call call1 = new Call(Date, StartTime1, Duration1);
            Call call2 = new Call(Date, StartTime2, Duration2);
            Call call3 = new Call(Date, StartTime3, Duration3);
            GSM gsm = new GSM(Model, Manufacturer, Price, Owner, BatteryModel, HoursIdle, HoursTalk, BatteryType1, DisplaySze, DisplayColors);
            gsm.CallHistory.Add(call1);
            gsm.CallHistory.Add(call2);
            gsm.CallHistory.Add(call3);

            StringBuilder callHistoryBuilder = new StringBuilder();
            callHistoryBuilder.AppendLine(gsm.GetCallHistory());
            callHistoryBuilder.AppendLine(gsm.CalculateBill(PricePerMinute));
            Call longestCall = gsm.CallHistory.OrderByDescending(c => c.Duration).FirstOrDefault();
            if (longestCall != null)
            {
                gsm.CallHistory.Remove(longestCall);
            }

            callHistoryBuilder.AppendLine(gsm.CalculateBill(PricePerMinute));
            gsm.ClearCallHistory();
            callHistoryBuilder.AppendLine(gsm.CalculateBill(PricePerMinute));
            callHistoryBuilder.AppendLine(gsm.GetCallHistory());

            return callHistoryBuilder.ToString().TrimEnd();
        }
    }
}