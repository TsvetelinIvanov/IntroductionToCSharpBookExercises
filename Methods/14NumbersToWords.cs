using System;

namespace _14NumbersToWords
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                Letterize(num);
            }
        }

        static void Letterize(int number)
        {
            int firstNumber = Math.Abs(number / 100);
            int secondNumber = Math.Abs((number / 10) % 10);
            int secondAndThirdNumber = Math.Abs(number % 100);
            int thirdNumber = Math.Abs(number % 10);
            string firstWord = string.Empty;
            string secondWord = string.Empty;
            string secondAndThirdWord = string.Empty;
            string thirdWord = string.Empty;
            string numberWord = string.Empty;

            switch (firstNumber)
            {
                case 1:
                    firstWord = "one-hundred";
                    break;
                case 2:
                    firstWord = "two-hundred";
                    break;
                case 3:
                    firstWord = "three-hundred";
                    break;
                case 4:
                    firstWord = "four-hundred";
                    break;
                case 5:
                    firstWord = "five-hundred";
                    break;
                case 6:
                    firstWord = "six-hundred";
                    break;
                case 7:
                    firstWord = "seven-hundred";
                    break;
                case 8:
                    firstWord = "eight-hundred";
                    break;
                case 9:
                    firstWord = "nine-hundred";
                    break;
                default:
                    break;
            }

            switch (secondNumber)
            {
                case 2:
                    secondWord = "twenty";
                    break;
                case 3:
                    secondWord = "thirty";
                    break;
                case 4:
                    secondWord = "forty";
                    break;
                case 5:
                    secondWord = "fifty";
                    break;
                case 6:
                    secondWord = "sixty";
                    break;
                case 7:
                    secondWord = "seventy";
                    break;
                case 8:
                    secondWord = "eighty";
                    break;
                case 9:
                    secondWord = "ninety";
                    break;
                default:
                    break;
            }

            switch (secondAndThirdNumber)
            {
                case 10:
                    secondAndThirdWord = "ten";
                    break;
                case 11:
                    secondAndThirdWord = "eleven";
                    break;
                case 12:
                    secondAndThirdWord = "twelve";
                    break;
                case 13:
                    secondAndThirdWord = "thirteen";
                    break;
                case 14:
                    secondAndThirdWord = "fourteen";
                    break;
                case 15:
                    secondAndThirdWord = "fifteen";
                    break;
                case 16:
                    secondAndThirdWord = "sixteen";
                    break;
                case 17:
                    secondAndThirdWord = "seventeen";
                    break;
                case 18:
                    secondAndThirdWord = "eighteen";
                    break;
                case 19:
                    secondAndThirdWord = "nineteen";
                    break;
                default:
                    break;
            }

            switch (thirdNumber)
            {
                case 1:
                    thirdWord = "one";
                    break;
                case 2:
                    thirdWord = "two";
                    break;
                case 3:
                    thirdWord = "three";
                    break;
                case 4:
                    thirdWord = "four";
                    break;
                case 5:
                    thirdWord = "five";
                    break;
                case 6:
                    thirdWord = "six";
                    break;
                case 7:
                    thirdWord = "seven";
                    break;
                case 8:
                    thirdWord = "eight";
                    break;
                case 9:
                    thirdWord = "nine";
                    break;
                default:
                    break;
            }

            if (number == 0)
            {
                numberWord = "zero";
            }
            else if (number > -10 && number < 10)
            {
                numberWord = thirdWord;
            }
            else if (number > -100 && number < 100)
            {
                if (Math.Abs(number / 10) == 1)
                {
                    numberWord = secondAndThirdWord;
                }
                else
                {
                    numberWord = secondWord + " " + thirdWord;
                }
            }
            else if (number > 999)
            {
                numberWord = "too large";
            }
            else if (number < -999)
            {
                numberWord = "too small";
            }
            else if ((number % 10 == 0) && (number / 10 % 10 == 0))
            {
                numberWord = firstWord;
            }
            else if (Math.Abs(number / 10 % 10) == 1)
            {
                numberWord = firstWord + " and " + secondAndThirdWord;
            }
            else if ((number / 10 % 10) == 0)
            {
                numberWord = firstWord + " and " + thirdWord;
            }
            else if (number % 10 == 0)
            {
                numberWord = firstWord + " and " + secondWord;
            }
            else
            {
                numberWord = firstWord + " and " + secondWord + " " + thirdWord;
            }


            if (number < 0 && number > -1000)
            {
                numberWord = "minus " + numberWord;
            }

            Console.WriteLine(numberWord);
        }
    }
}
