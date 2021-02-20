using System;

namespace EncryptionXV
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string encryptedLetter = string.Empty;
            string encryptedLetters = string.Empty;
            for (int i = 0; i < n; i++)
            {
                char letter = char.Parse(Console.ReadLine());
                encryptedLetter = Encrypt(letter);
                encryptedLetters += encryptedLetter;                
            }

            Console.WriteLine(encryptedLetters);
        }

        static string Encrypt(char letter)
        {
            string encryptedLetter = string.Empty;
            int lastDigit = letter % 10;
            int firstDigit = 0;
            int currentDigit = letter;
            while (currentDigit > 0)
            {
                firstDigit = currentDigit % 10;
                currentDigit = currentDigit / 10;
            }

            int firstSymbol = letter + lastDigit;
            char firstChar = (char)firstSymbol;
            int lastSymbol = letter - firstDigit;
            char lastChar = (char)lastSymbol;
            encryptedLetter = "" + firstChar + firstDigit + lastDigit + lastChar;

            return encryptedLetter;
        }
    }
}
