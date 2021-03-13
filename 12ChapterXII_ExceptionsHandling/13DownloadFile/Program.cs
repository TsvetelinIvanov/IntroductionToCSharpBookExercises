using System;
using System.Net;

namespace _13DownloadFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string address = Console.ReadLine();
            string fileName = Console.ReadLine();
            WebClient webClient = new WebClient();
            try
            {
                webClient.DownloadFile(address, fileName);
                Console.WriteLine("Donwload Complete.");
            }
            catch (ArgumentNullException ane)
            {
                Console.WriteLine(ane.Message);
            }            
            catch (WebException we)
            {
                Console.WriteLine(we.Message);
            }
            catch (NotSupportedException nse)
            {
                Console.WriteLine(nse.Message);
            }
            finally
            {
                webClient.Dispose();
            }
        }
    }
}