using System;

namespace _08ReadTypeVariable
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please enter desired variable type (int, double or string): ");//or "For string: enter \"0\"; for int: enter \"1\"; for double: enter \"2.\""
            string x = Console.ReadLine();//or int.Parse(Console.ReadLine());
            switch (x)
            {
                case "string"://or case 0:
                    string s = Console.ReadLine();
                    Console.WriteLine(s + "*");
                    break;
                case "int"://or case 1:
                    int i = int.Parse(Console.ReadLine());
                    i = i + 1;
                    Console.WriteLine(i);
                    break;
                case "double"://or case 2:
                    double d = double.Parse(Console.ReadLine());
                    d = d + 1; Console.WriteLine(d);
                    break;                
                default:
                    break;
            }
        }
    }
}
