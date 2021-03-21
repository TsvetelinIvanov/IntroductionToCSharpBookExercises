using System.Text.RegularExpressions;
using System.IO;

namespace _11DeleteWordsStartWithTest
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader("file.txt");
            string fileContent = reader.ReadToEnd();
            reader.Close();

            fileContent = Regex.Replace(fileContent, @"\btest\w+", "");
            fileContent = Regex.Replace(fileContent, @"\btest\b", "");

            StreamWriter writer = new StreamWriter("newFile.txt");
            writer.Write(fileContent);
            writer.Close();
        }
    }
}