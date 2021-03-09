using System;
using System.Linq;

namespace _12SumPolinomios
{
    class Program
    {
        static void Main()
        {
            string firstPolinomiosString = "  " + Console.ReadLine() + "  ";
            string secondPolinomiosString = "  " + Console.ReadLine() + "  ";           

            Sum(firstPolinomiosString, secondPolinomiosString);
        }

        static void Sum(string firstPolinomiosString, string secondPolinomiosString)
        {
            int[] firstPolinomiosArray = new int[1000];
            int[] secondPolinomiosArray = new int[1000];
            int[] summedPolinomiosArray = new int[1000];

            GetPolinomios(firstPolinomiosString, firstPolinomiosArray);
            GetPolinomios(secondPolinomiosString, secondPolinomiosArray);

            for (int i = 0; i < firstPolinomiosArray.Length; i++)
            {
                summedPolinomiosArray[i] += firstPolinomiosArray[i] + secondPolinomiosArray[i];
            }

            PrintPolinomiosArray(summedPolinomiosArray);
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

        static int GetX(string polinomiosString, int[] array, int i)
        {
            int value = 0;
            int degree = 0;
            int index = GetValue(polinomiosString, i - 1, ref value);
            GetDegree(polinomiosString, i + 1, ref degree);
            array[degree] += value;

            return index;//returns the index that have to be checked next
        }

        static int GetValue(string polinomiosString, int index, ref int value)
        {
            string number = string.Empty;
            int result;
            while (int.TryParse(polinomiosString[index].ToString(), out _))
            {
                number += polinomiosString[index].ToString();
                index--;
            }

            if (number == string.Empty)
            {
                number += "1";
            }

            string reversedNumber = string.Empty;
            foreach (char digit in number.Reverse())
            {
                reversedNumber += digit;
            }

            result = int.Parse(reversedNumber);
            if (polinomiosString[index] == '-')
            {
                result *= -1;
            }

            value = result;

            return index;//returns the index that have to be checked next
        }

        static void GetDegree(string polinomiosString, int index, ref int degree)
        {
            string stringDegree = string.Empty;
            int result;
            if (polinomiosString[index] == '^')
            {
                index++;
                while (int.TryParse(polinomiosString[index].ToString(), out _))
                {
                    stringDegree += polinomiosString[index].ToString();
                    index++;
                }

                if (stringDegree == string.Empty)
                {
                    stringDegree += "1";
                }
                
                result = int.Parse(stringDegree);
            }
            else
            {
                result = 1;
            }

            degree = result;
        }

        static void PrintPolinomiosArray(int[] polinomiosArray)
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