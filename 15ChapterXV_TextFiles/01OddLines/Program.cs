using System;
using System.IO;
using System.Text;

namespace _01OddLines
{
    class Program
    {
        static void Main(string[] args)
        {            
            StreamReader streamReader = new StreamReader("file.txt", UTF8Encoding.UTF8);
            using (streamReader)
            {
                int lineCounter = 0;
                string oddLineContent = streamReader.ReadLine();
                while (oddLineContent != null)
                {
                    lineCounter++;
                    if (lineCounter % 2 != 0)
                    {
                        Console.WriteLine(oddLineContent);
                    }

                    oddLineContent = streamReader.ReadLine();
                }
            }
        }
    }
}