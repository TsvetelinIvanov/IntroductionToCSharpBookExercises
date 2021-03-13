using System;
using System.IO;

namespace _10FileContentToNewFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputFileName = Console.ReadLine();
            string outputFileName = Console.ReadLine();
            //string outputPath = filePath.Substring(0, filePath.LastIndexOf('\\'));
            //outputPath = string.Concat(outputPath, "\\", outputName);
            try
            {
                byte[] content = ReadBinaryFile(inputFileName);
                File.WriteAllBytes(outputFileName, content);
                if (CheckEquality(File.ReadAllBytes(inputFileName), File.ReadAllBytes(outputFileName)))
                {
                    Console.WriteLine("Files are the same.");
                }
                else
                {
                    Console.WriteLine("Files are not the same.");
                }
            }
            catch (PathTooLongException ptle)
            {
                Console.WriteLine(ptle.Message);
            }
            catch (DirectoryNotFoundException dnfe)
            {
                Console.WriteLine(dnfe.Message);
            }
            catch (FileNotFoundException fnfe)
            {
                Console.WriteLine(fnfe.Message);
            }
            catch (NotSupportedException)
            {
                Console.WriteLine("path is in an invalid format");
            }
            catch (UnauthorizedAccessException uae)
            {
                Console.WriteLine(uae.Message);                
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
            catch (IOException ioe)
            {
                Console.WriteLine(ioe.Message);
            }
        }

        private static byte[] ReadBinaryFile(string path)
        {
            return File.ReadAllBytes(path);
        }

        private static bool CheckEquality(byte[] content, byte[] newContent)
        {
            if (content.Length != newContent.Length)
            {
                return false;
            }
                
            for (int i = 0; i < content.Length; i++)
            {
                if (content[i] != newContent[i])
                {
                    return false;
                }                    
            }

            return true;
        }       
    }
}