using System;

namespace _11_CalculateMyAge10Years
{
    class Program
    {
        static void Main(string[] args)
        {
            int age = 0;
            string ageString = "";
            ageString = Console.ReadLine();
            try
            {
                age = int.Parse(ageString);
                if (age <= 0 || age > 120)
                {
                    throw new OverflowException();
                }
                Console.WriteLine(age + 10);
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Age missing.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Not a valid number.");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Not a valid age.");
            }
        }
    }
}
