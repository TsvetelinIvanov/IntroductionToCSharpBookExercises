using System;
using System.IO;

namespace _04CompareTextFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader firstStreamReader = new StreamReader("file1.txt");
            StreamReader secondStreamReader = new StreamReader("file2.txt");
            
            int equalLinesCount = 0;
            int differentLinesCount = 0;
            
            using (firstStreamReader)
            {
                using (secondStreamReader)
                {
                    StreamWriter streamWriter = new StreamWriter("newFile.txt", false);
                    using (streamWriter)
                    {                        
                        string firstFileLine = firstStreamReader.ReadLine();
                        string secondFileLine = secondStreamReader.ReadLine();
                        while (firstFileLine != null && secondFileLine != null)
                        {                            
                            if (firstFileLine.CompareTo(secondFileLine) == 0)
                            {
                                equalLinesCount++;
                            }
                            else
                            {
                                differentLinesCount++;
                            }

                            firstFileLine = firstStreamReader.ReadLine();
                            secondFileLine = secondStreamReader.ReadLine();
                        }

                        streamWriter.WriteLine(equalLinesCount);
                        streamWriter.WriteLine(differentLinesCount);
                    }
                }
            }
            
            Console.WriteLine("The number of lines that are the same is: " + equalLinesCount);
            Console.WriteLine("The number of lines that are different is: " + differentLinesCount);
        }
    }
}