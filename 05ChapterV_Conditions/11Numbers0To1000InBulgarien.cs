using System;

namespace _11Numbers0To1000InBulgarian
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter a number:");
            int param = int.Parse(Console.In.ReadLine());
            if (param < 1000 && param > 0)
            {
                int temp = param;
                switch (temp / 100)
                {
                    case 0:
                        break;
                    case 1:
                        Console.Write("сто ");
                        break;
                    case 2:
                        Console.Write("двеста ");
                        break;
                    case 3:
                        Console.Write("триста ");
                        break;
                    case 4:
                        Console.Write("четиристотин ");
                        break;
                    case 5:
                        Console.Write("петстотин ");
                        break;
                    case 6:
                        Console.Write("шестотин ");
                        break;
                    case 7:
                        Console.Write("седемстотин ");
                        break;
                    case 8:
                        Console.Write("осемстотин ");
                        break;
                    case 9:
                        Console.Write("деветстотин ");
                        break;
                    default:
                        Console.WriteLine("Error report!");
                        break;
                }

                if (temp / 100 != 0 && temp % 100 != 0 && temp % 10 == 0)
                {
                    Console.Write("и ");
                }

                switch (temp / 10 % 10)
                {
                    case 0:
                        break;
                    case 1:
                        {
                            if (param / 100 != 0 && param % 10 != 0)
                            {
                                Console.Write("и ");
                            }

                            switch (temp % 10)
                            {
                                case 0:
                                    Console.WriteLine("десет");
                                    break;
                                case 1:
                                    Console.WriteLine("единадесет");
                                    break;
                                case 2:
                                    Console.WriteLine("дванадесет");
                                    break;
                                case 3:
                                    Console.WriteLine("тринадесет");
                                    break;
                                case 4:
                                    Console.WriteLine("четиринадесет");
                                    break;
                                case 5:
                                    Console.WriteLine("петнадесет");
                                    break;
                                case 6:
                                    Console.WriteLine("шестнадесет");
                                    break;
                                case 7:
                                    Console.WriteLine("седемнадесет");
                                    break;
                                case 8:
                                    Console.WriteLine("осемнадесет");
                                    break;
                                case 9:
                                    Console.WriteLine("деветнадесет");
                                    break;
                                default:
                                    Console.WriteLine("Error report!");
                                    break;
                            }
                        }

                        break;
                    case 2:
                        Console.Write("двадесет");
                        break;
                    case 3:
                        Console.Write("тридесет");
                        break;
                    case 4:
                        Console.Write("четиредесет");
                        break;
                    case 5:
                        Console.Write("педесет");
                        break;
                    case 6:
                        Console.Write("шестдесет");
                        break;
                    case 7:
                        Console.Write("седемдесет");
                        break;
                    case 8:
                        Console.Write("осемдесет");
                        break;
                    case 9:
                        Console.Write("деветдесет");
                        break;
                    default:
                        Console.WriteLine("Error report!");
                        break;
                }

                if (temp / 10 != 0 && temp % 10 != 0 && temp / 10 % 10 != 1)
                {                    
                    Console.Write(" и ");
                }

                switch (temp % 10)
                {
                    case 0:
                        if (temp / 10 % 10 == 1)
                        {
                            break;
                        }

                        Console.WriteLine();
                        break;
                    case 1:
                        if (temp / 10 % 10 == 1)
                        {
                            break;
                        }                            

                        Console.WriteLine("едно");
                        break;
                    case 2:
                        if (temp / 10 % 10 == 1)
                        {
                            break;
                        }

                        Console.WriteLine("две");
                        break;
                    case 3:
                        if (temp / 10 % 10 == 1)
                        {
                            break;
                        }

                        Console.WriteLine("три");
                        break;
                    case 4:
                        if (temp / 10 % 10 == 1)
                        {
                            break;
                        }

                        Console.WriteLine("четири");
                        break;
                    case 5:
                        if (temp / 10 % 10 == 1)
                        {
                            break;
                        }

                        Console.WriteLine("пет");
                        break;
                    case 6:
                        if (temp / 10 % 10 == 1)
                        {
                            break;
                        }

                        Console.WriteLine("шест");
                        break;
                    case 7:
                        if (temp / 10 % 10 == 1)
                        {
                            break;
                        }

                        Console.WriteLine("седем");
                        break;
                    case 8:
                        if (temp / 10 % 10 == 1)
                        {
                            break;
                        }

                        Console.WriteLine("осем");
                        break;
                    case 9:
                        if (temp / 10 % 10 == 1)
                        {
                            break;
                        }

                        Console.WriteLine("девет");
                        break;
                    default:
                        Console.WriteLine("Error report!");
                        break;
                }
            }
            else if (param == 1000)
            {
                Console.WriteLine("хиляда");
            }
            else if (param == 0)
            {
                Console.WriteLine("нула");
            }
            else
            {
                Console.WriteLine("Out of range!");
            }
        }
    }
}
