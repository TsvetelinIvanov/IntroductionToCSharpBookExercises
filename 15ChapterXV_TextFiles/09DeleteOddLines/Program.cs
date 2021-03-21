using System;
using System.IO;
using System.Text;

namespace _09DeleteOddLines
{
    class Program
    {
        static void Main(string[] args)
        {            
            StreamReader streamReader = new StreamReader("file.txt", UTF8Encoding.UTF8);            
            StringBuilder fileContentBuilder = new StringBuilder();

            using (streamReader)
            {
                int lineCounter = 0;               
                string line = streamReader.ReadLine();
                while (line != null)
                {
                    lineCounter++;
                    if (lineCounter % 2 == 0)
                    {
                        fileContentBuilder.AppendLine(line);
                    }

                    line = streamReader.ReadLine();
                }
            }
                        
            StreamWriter streamWriter = new StreamWriter("file.txt", false, UTF8Encoding.UTF8);
            using (streamWriter)
            {
                streamWriter.Write(fileContentBuilder.ToString());
            }
        }
    }
}