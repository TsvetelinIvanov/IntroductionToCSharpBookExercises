using System;

namespace _14DecimalToHexadecimal
{
    class Program
    {
        static void Main(string[] args)
        {
            const int Base = 16;
            int number = int.Parse(Console.ReadLine());

            if (number == 0)
            {
                Console.WriteLine(0);
                
                return;
            }

            string numberToBaseString = string.Empty;
            while (number > 0)
            {
                int reminder = number % Base;
                string reminderString = reminder.ToString();
                if (reminder >= 10)
                {
                    switch (reminder)
                    {
                        case 10:
                            reminderString = "A";
                            break;
                        case 11:
                            reminderString = "B";
                            break;
                        case 12:
                            reminderString = "C";
                            break;
                        case 13:
                            reminderString = "D";
                            break;
                        case 14:
                            reminderString = "E";
                            break;
                        case 15:
                            reminderString = "F";
                            break;                        
                    }
                }

                numberToBaseString = reminderString + numberToBaseString;
                number /= Base;
            }
            
            Console.WriteLine(numberToBaseString);
        }
    }
}
