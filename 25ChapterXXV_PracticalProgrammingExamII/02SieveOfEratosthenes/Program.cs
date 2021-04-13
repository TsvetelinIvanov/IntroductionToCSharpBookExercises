using System;
using System.Collections.Generic;

namespace _02SieveOfEratosthenes
{
    class Program
    {
        static void Main(string[] args)
        {
            const int TenThousandthPrimeNumber = 104729;

            int dimension = int.Parse(Console.ReadLine());
            int primesCount = dimension * dimension;

            int sieveSize = TenThousandthPrimeNumber + 1;
            bool[] sieve = new bool[sieveSize];

            List<int> primes = new List<int>();            
            for (int i = 2; i < sieve.Length; i++)
            {
                if (!sieve[i])
                {
                    primes.Add(i);
                    if (primes.Count == primesCount)
                    {
                        break;
                    }                    
                    
                    int step = i;
                    while (step < sieveSize)
                    {
                        sieve[step] = true;
                        step = step + i;
                    }
                }
            }

            PrintMatrix(dimension, primes);
        }

        private static void PrintMatrix(int dimension, List<int> primes)
        {
            int index = 0;
            for (int row = 0; row < dimension; row++)
            {
                for (int col = 0; col < dimension; col++)
                {
                    Console.Write("{0,7}", primes[index]);
                    index++;
                }

                Console.WriteLine();
            }
        }
    }
}