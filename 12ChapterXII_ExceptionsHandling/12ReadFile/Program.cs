using System;
using System.IO;

namespace _12ReadFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Console.ReadLine();            
            try
            {
                string content = GetContent(path);
                Console.WriteLine(content);
            }
            catch (PathTooLongException)
            {
                Console.WriteLine($"The path to the file - {path}, is too long!");
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("Cannot find directory!");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"The file specified in path - {path}, was not found!");
            }
            catch (NotSupportedException)
            {
                Console.WriteLine($"The path to the file - {path}, is in an invalid format!");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Path specified a file that is read-only!");
                Console.WriteLine("-or-");
                Console.WriteLine("This operation is not supported on the current platform!");
                Console.WriteLine("-or-");
                Console.WriteLine("Path specified a directory!");
                Console.WriteLine("-or-");
                Console.WriteLine("The user does not have the required permission!");
            }
            catch (ArgumentException)
            {
                Console.WriteLine($"The path to the file - {path}, is invalid!");
            }
        }

        private static string GetContent(string path)
        {
            return File.ReadAllText(path);
        }
    }
}