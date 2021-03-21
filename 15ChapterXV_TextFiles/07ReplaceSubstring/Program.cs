using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace _07ReplaceSubstring
{
    class Program
    {
        static void Main(string[] args)
        {            
            string filePath = "file.txt";
            string fileContent = DoFileToString(filePath);
            fileContent = Regex.Replace(fileContent, "start", "finish");

            StreamWriter streamWriter = new StreamWriter("newFile.txt", false, UTF8Encoding.UTF8);
            streamWriter.Write(fileContent);
            streamWriter.Close();
        }

        public static string DoFileToString(string filePath)
        {            
            StringBuilder fileContentBuilder = new StringBuilder();
            StreamReader streamReader = new StreamReader(filePath, UTF8Encoding.UTF8);
            using (streamReader)
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    fileContentBuilder.Append(line);
                    if (!streamReader.EndOfStream)
                    {
                        fileContentBuilder.Append(Environment.NewLine);
                    }
                }
            }

            return fileContentBuilder.ToString();
        }
    }
}