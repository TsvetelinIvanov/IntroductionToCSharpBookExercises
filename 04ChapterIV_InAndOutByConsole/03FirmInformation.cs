using System;

namespace _03FirmInformation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Company Name: ");
            string firmName = Console.ReadLine();
            Console.Write("Company Address: ");
            string firmAddress = Console.ReadLine();
            Console.Write("Company Phone: ");
            string firmPhone = Console.ReadLine();
            Console.Write("Company Fax: ");
            string firmFaxe = Console.ReadLine();
            Console.Write("Company Web Site: ");
            string firmWebSite = Console.ReadLine();

            Console.Write("Manager Name: ");
            string managerFirstName = Console.ReadLine();
            Console.Write("Manager FamilyName: ");
            string managerFamilyName = Console.ReadLine();
            Console.Write("Manager Phone: ");
            string managerPhone = Console.ReadLine();

            Console.WriteLine("The company name is {0}, its address {1}, and you can contact by phone: {2}; and fax: {3}; or see the website: {4}.", firmName, firmAddress, firmPhone, firmFaxe, firmWebSite);
            Console.WriteLine("The manager is {0} {1}, and hi is accessible by phone: {2}.", managerFirstName, managerFamilyName, managerPhone);
        }
    }
}
