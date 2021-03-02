using System;

namespace _19PrimeNumbersSieveOfErathostens
{
    class Program
    {
        static void Main(string[] args)
        {
            int maxNum = 10000000;            
            bool[] flags = new bool[maxNum + 1];
            for (int i = 2; i <= maxNum; i++) 
            {
                flags[i] = true;
            }
            
            for (int i = 2; i <= maxNum; i++)
            {                
                if (flags[i])
                {                    
                    for (int j = i * 2; j <= maxNum; j += i)
                    {
                        flags[j] = false;
                    }                        
                }
            }

            for (int i = 0; i <= maxNum; i++)
            {
                if (flags[i])
                {
                    Console.Write(i + " ");
                }
            }

            Console.WriteLine();
        }
    }
}