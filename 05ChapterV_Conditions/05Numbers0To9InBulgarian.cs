using System;

namespace _05Numbers0To9InBulgarian
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            switch (n)
            {
                case 0:
                    Console.WriteLine("нула");
                    break;
                case 1:
                    Console.WriteLine("едно");
                    break;
                case 2:
                    Console.WriteLine("две");
                    break;
                case 3:
                    Console.WriteLine("три");
                    break;
                case 4:
                    Console.WriteLine("четири");
                    break;
                case 5:
                    Console.WriteLine("пет");
                    break;
                case 6:
                    Console.WriteLine("шест");
                    break;
                case 7:
                    Console.WriteLine("седем");
                    break;
                case 8:
                    Console.WriteLine("осем");
                    break;
                case 9:
                    Console.WriteLine("девет");
                    break;
                default:
                    Console.WriteLine("неизвестно");
                    break;
            }
        }
    }
}
