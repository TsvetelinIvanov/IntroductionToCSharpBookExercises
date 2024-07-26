using System;

namespace _06FindTriangleArea
{
    class Program
    {
        static void Main(string[] args)
        {
            //choice which task to solve - a, b or c
            Console.WriteLine("Please, input your choice for finding triangle area - a (by three sides), b (by side and hight), or c (by two sides and angle):");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "a":
                    Console.WriteLine("Please, input value for a:");
                    double a = double.Parse(Console.ReadLine());
                    Console.WriteLine("Please, input value for b:");
                    double b = double.Parse(Console.ReadLine());
                    Console.WriteLine("Please, input value for c:");
                    double c = double.Parse(Console.ReadLine());
                    Console.WriteLine(FindArea(a, b, c));
                    
                    return;
                case "b":
                    Console.WriteLine("Please, input value for a:");
                    a = double.Parse(Console.ReadLine());
                    Console.WriteLine("Please, input value for h:");
                    double h = double.Parse(Console.ReadLine());
                    Console.WriteLine(FindArea(a, h));
                    
                    return;
                case "c":
                    Console.WriteLine("Please, input value for a:");
                    a = double.Parse(Console.ReadLine());
                    Console.WriteLine("Please, input value for b:");
                    b = double.Parse(Console.ReadLine());
                    Console.WriteLine("Please, input value for the angle between a and b:");
                    float angle = float.Parse(Console.ReadLine());
                    Console.WriteLine(FindArea(a, b, angle));
                    
                    return;
                default:
                    Console.WriteLine("Please, input a, b or c as a subtask choice!");
                    
                    return;
            }
        }

        static double FindArea(double a, double b, double c)
        {
            double p = (a + b + c) / 2;
            
            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }

        static double FindArea(double a, double h)
        {
            return a * h / 2;
        }        

        static double FindArea(double a, double b, float angle)
        {
            return a * b * Math.Sin(angle * Math.PI / 180) / 2;
        }
    }
}
