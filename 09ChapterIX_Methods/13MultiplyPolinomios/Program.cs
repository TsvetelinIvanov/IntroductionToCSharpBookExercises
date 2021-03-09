using System;
using System.Linq;

namespace _13MultiplyPolinomios
{
    class Program
    {      
        static void Main()
        {
            string firstPolinomiosString = "  " + Console.ReadLine().Replace(" ", "") + "  ";
            string secondPolinomiosString = "  " + Console.ReadLine().Replace(" ", "") + "  ";

            MultiplyPolinomios(firstPolinomiosString, secondPolinomiosString);
        }

        static void MultiplyPolinomios(string firstPolinomiosString, string secondPolinomiosString)
        {
            int[] firstPolinomiosArray = new int[1000];
            int[] secondPolinomiosArray = new int[1000];
            int[] multipliedPolinomiosArray = new int[2000];

            GetPolinomios(firstPolinomiosString, firstPolinomiosArray);
            GetPolinomios(secondPolinomiosString, secondPolinomiosArray);

            for (int i = 0; i < firstPolinomiosArray.Length; i++)
            {
                for (int j = 0; j < firstPolinomiosArray.Length; j++)
                {
                    multipliedPolinomiosArray[i + j] += firstPolinomiosArray[i] * secondPolinomiosArray[j];
                }
            }

            PrintPolinomios(multipliedPolinomiosArray);
        }

        static void GetPolinomios(string polinomiosString, int[] polinomiosArray)
        {
            for (int i = polinomiosString.Length - 1; i >= 0; i--)
            {
                string currentSymbol = polinomiosString[i].ToString();
                if (currentSymbol == "X" || currentSymbol == "x")
                {
                    i = GetX(polinomiosString, polinomiosArray, i);
                }

                if (int.TryParse(currentSymbol, out _))
                {
                    int testingIndex = i - 1;
                    while (int.TryParse(polinomiosString[testingIndex].ToString(), out _))
                    {
                        testingIndex--;
                    }

                    if (polinomiosString[testingIndex] == '+' || polinomiosString[testingIndex] == '-')
                    {
                        int freeValue = 0;
                        i = GetValue(polinomiosString, i, ref freeValue);
                        polinomiosArray[0] += freeValue;
                    }
                }
            }
        }

        static int GetX(string polinomiosString, int[] polinomiosArray, int i)
        {
            int value = 0;
            int degree = 0;
            int index = GetValue(polinomiosString, i - 1, ref value);
            GetDegree(polinomiosString, i + 1, ref degree);
            polinomiosArray[degree] += value;

            return index;//returns the index that have to be checked next
        }

        static int GetValue(string polinomiosString, int index, ref int value)
        {
            string numberString = string.Empty;
            int result;
            while (int.TryParse(polinomiosString[index].ToString(), out _))
            {
                numberString += polinomiosString[index].ToString();
                index--;
            }

            if (numberString == string.Empty)
            {
                numberString += "1";
            }

            string reversedNumberString = string.Empty;
            foreach (char digit in numberString.Reverse())
            {
                reversedNumberString += digit;
            }

            result = int.Parse(reversedNumberString);
            if (polinomiosString[index] == '-')
            {
                result *= -1;
            }

            value = result;

            return index;//returns the index that have to be checked next
        }

        static void GetDegree(string polinomiosString, int index, ref int degree)
        {
            string degreeString = string.Empty;
            int result;
            if (polinomiosString[index] == '^')
            {
                index++;
                while (int.TryParse(polinomiosString[index].ToString(), out _))
                {
                    degreeString += polinomiosString[index].ToString();
                    index++;
                }

                if (degreeString == string.Empty)
                {
                    degreeString += "1";
                }

                result = int.Parse(degreeString);
            }
            else
            {
                result = 1;
            }

            degree = result;
        }

        static void PrintPolinomios(int[] polinomiosArray)
        {
            string polinomiosString = string.Empty;
            for (int i = polinomiosArray.Length - 1; i > 0; i--)
            {
                if (polinomiosArray[i] != 0)
                {
                    if (polinomiosString.Length > 0)
                    {
                        if (polinomiosArray[i] > 0)
                        {
                            polinomiosString += "+";
                        }
                    }

                    if (polinomiosArray[i] != 1)
                    {
                        polinomiosString += polinomiosArray[i];
                    }

                    polinomiosString += "X";
                    if (i > 1)
                    {
                        polinomiosString += "^" + i;
                    }
                }
            }

            if (polinomiosString.Length > 0 && polinomiosArray[0] > 0)
            {
                polinomiosString += "+";
            }

            if (polinomiosArray[0] != 0)
            {
                polinomiosString += polinomiosArray[0];
            }

            if (polinomiosString == string.Empty)
            {
                polinomiosString = "0";
            }

            Console.WriteLine(polinomiosString);
        }
    }
}