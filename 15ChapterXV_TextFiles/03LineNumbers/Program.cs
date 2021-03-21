using System.IO;
using System.Text;

namespace _03LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {            
            string inputFile = "file.txt";
            string outputFile = "newFile.txt";            
            string inputFileContent = DoFileToString(inputFile);
            
            StreamWriter streamWriter = new StreamWriter(outputFile, false, UTF8Encoding.UTF8);
            streamWriter.Write(inputFileContent);
            streamWriter.Close();
        }

        public static string DoFileToString(string filePath)
        {            
            StringBuilder fileContentBuilder = new StringBuilder();            
            using (StreamReader streamReader = new StreamReader(filePath, UTF8Encoding.UTF8))
            {
                string line;
                int counter = 0;
                while ((line = streamReader.ReadLine()) != null)
                {
                    counter++;
                    fileContentBuilder.AppendLine(counter + ". " + line);                                     
                }
            }

            return fileContentBuilder.ToString().TrimEnd();
        }
    }
}