using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace _01ValidateEmailAddresses
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex mailRegex = new Regex(@"^[a-zA-Z_]+@[a-z]+\.[a-z]{2,4}$");
            List<string> validUsersData = new List<string>();
            string[] usersData = File.ReadAllLines("mails.txt");
            for (int i = 0; i < usersData.Length; i++)
            {
                string mail = usersData[i].Split().Last();
                if (mailRegex.IsMatch(mail))
                {
                    validUsersData.Add(usersData[i]);
                }
            }

            File.WriteAllLines("validMails.txt", validUsersData);
        }
    }
}