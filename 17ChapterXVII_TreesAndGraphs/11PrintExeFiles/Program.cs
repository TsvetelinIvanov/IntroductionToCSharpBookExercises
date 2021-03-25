using System;
using System.IO;
using System.Text.RegularExpressions;

namespace _11PrintExeFiles
{
    class Program
    {
        //input example:C:\WINDOWS\        
        //expected output: it depends of file system
        public static Regex exeRegex = new Regex("[.]*\\.exe$");

        public static void Main()
        {
            //string directoryPath = "C:\\WINDOWS\\";
            string directoryPath = Console.ReadLine();
            TraverseDirectory(new DirectoryInfo(directoryPath));
        }

        private static void TraverseDirectory(DirectoryInfo directory)
        {
            try
            {
                FileInfo[] files = directory.GetFiles();
                foreach (FileInfo file in files)
                {
                    if (exeRegex.IsMatch(file.FullName))
                    {
                        Console.WriteLine(file.FullName);
                    }
                }

                DirectoryInfo[] children = directory.GetDirectories();
                foreach (DirectoryInfo child in children)
                {
                    TraverseDirectory(child);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.GetType() + ": " + e.Message);
            }
        }
    }
}