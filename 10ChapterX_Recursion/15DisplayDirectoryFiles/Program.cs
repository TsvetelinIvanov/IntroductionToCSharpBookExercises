using System;
using System.IO;

namespace _15DisplayDirectoryFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Console.ReadLine();//C:\
            TraverseDirectories(new DirectoryInfo(path));
        }

        static void TraverseDirectories(DirectoryInfo parentDirectory)
        {
            try
            {
                foreach (DirectoryInfo directory in parentDirectory.GetDirectories())
                {
                    Console.WriteLine("Found dir:  " + directory.FullName);
                    TraverseDirectories(directory);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            try
            {
                foreach (FileInfo file in parentDirectory.GetFiles())
                {
                    Console.WriteLine("Found file: " + file.FullName);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}