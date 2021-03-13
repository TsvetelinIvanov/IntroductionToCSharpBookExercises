using System;
using System.IO;

namespace _11FileParseException
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Console.ReadLine();
            try
            {
                ParseLine(path);
            }
            catch (FileParseException fpe)
            {
                Console.WriteLine(fpe.Message);
            }
        }

        static void ParseLine(string path)
        {
            StreamReader input;
            try
            {
                input = new StreamReader(path);
            }
            catch (IOException e)
            {
                throw new FileParseException(path, e);
            }

            string line;            
            int row = 0;
            while ((line = input.ReadLine()) != null)
            {
                row++;                
                try
                {
                    decimal number = decimal.Parse(line);
                    Console.WriteLine(number);
                }
                catch (Exception)
                {
                    throw new FileParseException(path, row);
                }
            }
        }
    }
}