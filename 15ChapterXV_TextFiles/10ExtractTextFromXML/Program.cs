using System;
using System.IO;
using System.Net;
using System.Xml;

namespace _10ExtractTextFromXML
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string filePath = "xmlFile.xml";                
                XmlTextReader xmlReader = new XmlTextReader(filePath);                
                while (xmlReader.Read())
                {
                    switch (xmlReader.NodeType)
                    {
                        case XmlNodeType.Text:
                            Console.WriteLine(xmlReader.Value);
                            break;
                    }
                }
            }            
            catch (IOException ioe)
            {
                Console.WriteLine(ioe.Message);
            }
            catch (WebException we)
            {
                Console.WriteLine(we.Message);
            }
            catch (UriFormatException ufe)
            {
                Console.WriteLine(ufe.Message);
            }
            catch (FormatException fe)
            {
                Console.WriteLine(fe.Message);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
            catch (XmlException xmle)
            {
                Console.WriteLine(xmle.Message);
            }
        }
    }
}