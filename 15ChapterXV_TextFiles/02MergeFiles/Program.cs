using System.IO;
using System.Text;

namespace _02MergeFiles
{
    class Program
    {
        static void Main(string[] args)
        {            
            StreamReader firstStreamReader = new StreamReader("file1.txt", UTF8Encoding.UTF8);
            StreamReader secondStreamReader = new StreamReader("file2.txt", UTF8Encoding.UTF8);

            StringBuilder firstTextBuilder = new StringBuilder();
            using (firstStreamReader)
            {
                firstTextBuilder.Append(firstStreamReader.ReadToEnd());                
            }

            StringBuilder secondTextBuilder = new StringBuilder();
            using (secondStreamReader)
            {
                secondTextBuilder.Append(secondStreamReader.ReadToEnd());                
            }

            StreamWriter streamWriter = new StreamWriter("mergedFile.txt", false, UTF8Encoding.UTF8);
            using (streamWriter)
            {
                streamWriter.WriteLine(firstTextBuilder);
                streamWriter.WriteLine(secondTextBuilder);
            }
        }
    }
}