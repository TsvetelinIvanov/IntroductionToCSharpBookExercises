using System;

namespace _01MakeHighQualityCode
{
    class Program
    {
        static void Main(string[] args)
        {
            int switchValue = 10;
            int iterationsInLoopCount = 5;
            switch (switchValue)
            {
                case 8:
                    {
                        Console.WriteLine("We are in case 8.");
                        break;
                    }
                case 9:
                    {
                        iterationsInLoopCount = 0;
                        break;
                    }
                case 10:
                    {
                        int number = 5;
                        Console.WriteLine(number);
                        break;
                    }               
                default:
                    {
                        Console.WriteLine("We are in default.");
                        Console.WriteLine("hoho ");
                        for (int i = 0; i < iterationsInLoopCount; i++)
                        {
                            Console.WriteLine(i - 'f');
                        }

                        break;
                    }
            }

            Console.WriteLine("We finished the switch-case loop!");
        }
    }
}
