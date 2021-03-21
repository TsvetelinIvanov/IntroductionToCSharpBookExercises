using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace _06OrderNames
{
    class Program
    {
        static void Main(string[] args)
        {            
            List<string> names = new List<string>();
            StreamReader streamReader = new StreamReader("file.txt", UTF8Encoding.UTF8);
            using (streamReader)
            {
                string line = streamReader.ReadLine();
                while (line != null)
                {
                    names.Add(line);
                    line = streamReader.ReadLine();
                }
            }

            names.Sort();            
            StreamWriter streamWriter = new StreamWriter("newFile.txt", false, UTF8Encoding.UTF8);
            using (streamWriter)
            {
                for (int i = 0; i < names.Count; i++)
                {
                    streamWriter.WriteLine(names[i]);
                    Console.WriteLine(names[i]);
                }
            }
        }
    }
}