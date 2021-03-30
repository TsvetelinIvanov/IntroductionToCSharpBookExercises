using System;
using System.Linq;

namespace _04Workers
{
    class Program
    {
        static void Main(string[] args)
        {
            Worker[] workers = new Worker[]
            {
                new Worker("Ivan", "Ivanov", 1037.89m, 8),
                new Worker("Goran", "Bonchev", 907.19m, 6),
                new Worker("Irena", "Venkova", 789.89m, 7),
                new Worker("Fikret", "Vergilov", 1110.08m, 8),
                new Worker("Boyan", "Fibelov", 1190.91m, 10),
                new Worker("Vanka", "Ronkova", 1165.89m, 8),
                new Worker("Fidos", "Slavkov", 653.17m, 4),
                new Worker("Sofka", "Kocheva", 701.13m, 7),
                new Worker("John", "Markovski", 3067.11m, 8),
                new Worker("Stefan", "Prodanov", 1417.09m, 12)
            };

            Array.Sort(workers);
            Console.WriteLine(string.Join(Environment.NewLine, workers.Select(w => w)));
        }
    }
}