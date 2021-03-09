using System;

namespace _04PassionDays
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal shoppingMoney = decimal.Parse(Console.ReadLine());            
            int purchases = 0;
            string command = Console.ReadLine();
            while (command != "mall.Enter")
            {
                command = Console.ReadLine();
            }

            command = Console.ReadLine();
            while (command != "mall.Exit")
            {
                foreach (char action in command)
                {
                    if (action >= 'A' && action <= 'Z')
                    {
                        decimal price = action * 0.5m;
                        if (shoppingMoney < price)
                        {
                            continue;
                        }                            

                        shoppingMoney -= price;
                        purchases++;
                    }
                    else if (action >= 'a' && action <= 'z')
                    {
                        decimal price = action * 0.3m;
                        if (shoppingMoney < price)
                        {
                            continue;
                        }                            

                        shoppingMoney -= price;
                        purchases++;
                    }
                    else if (action == '%')
                    {
                        if (shoppingMoney > 0)
                        {
                            shoppingMoney /= 2m;
                            purchases++;
                        }
                    }
                    else if (action == '*')
                    {
                        shoppingMoney += 10m;
                    }
                    else
                    {
                        decimal price = action;
                        if (shoppingMoney < price)
                        {
                            continue;
                        }                            

                        shoppingMoney -= price;
                        purchases++;
                    }
                }

                command = Console.ReadLine();
            }

            if (purchases == 0)
            {
                Console.WriteLine("No purchases. Money left: {0:f2} lv.", shoppingMoney);
            }
            else
            {
                Console.WriteLine($"{purchases} purchases. Money left: {shoppingMoney:f2} lv.");
            }
        }
    }
}
