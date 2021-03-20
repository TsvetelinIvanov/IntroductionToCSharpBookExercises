using System;
using System.Collections.Generic;
using System.Text;

namespace _25_27Fraction
{
    public class FractionTest
    {
        public static void TestFraction()
        {
            string firstInputLine = Console.ReadLine();
            string secondInputLine = Console.ReadLine();

            Fraction a = Fraction.Parse(firstInputLine);
            Fraction b = Fraction.Parse(secondInputLine);

            if ((a != null) && (b != null))
            {                
                Console.WriteLine(a.ToString());                
                Console.WriteLine(b.ToString());

                Fraction c = a + b;
                Console.WriteLine(c.ToString());
                Console.WriteLine(c.DecimalValue);

                Fraction d = a - b;
                Console.WriteLine(d.ToString());
                Console.WriteLine(d.DecimalValue);
            }
        }
    }
}