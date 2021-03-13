using System;
using System.IO;
using System.Security;
using System.Text;

namespace _09FileContentToString
{
    class Program
    {
        static void Main(string[] args)
        {
            string errorMessage = null;
            string filePath = Console.ReadLine();

            try
            {
                string fileContent = FileToString(filePath);
                Console.WriteLine(fileContent);
            }
            catch (ArgumentNullException ane)
            {
                errorMessage = ane.Message;
            }
            catch (ArgumentException ae)
            {
                errorMessage = ae.Message;
            }
            catch (PathTooLongException ptle)
            {
                errorMessage = ptle.Message;
            }
            catch (DirectoryNotFoundException dnfe)
            {
                errorMessage = dnfe.Message;
            }
            catch (FileNotFoundException fnfe)
            {
                errorMessage = fnfe.Message;
            }
            catch (IOException ioe)
            {
                errorMessage = ioe.Message;
            }
            catch (UnauthorizedAccessException uae)
            {
                errorMessage = uae.Message;
            }
            catch (NotSupportedException nse)
            {
                errorMessage = nse.Message;
            }
            catch (SecurityException se)
            {
                errorMessage = se.Message;
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
            }
            finally
            {
                if (errorMessage != null)
                {
                    Console.WriteLine(errorMessage);
                }
            }
        }

        private static string FileToString(string filePath)
        {
            string fileContent = File.ReadAllText(filePath, Encoding.UTF8);

            return fileContent;
        }
    }
}