﻿using System;

namespace _25_27Fraction
{
    public class Fraction
    {
        private int fractionNumerator;
        private int fractionDenominator;

        private Fraction(int fractionNumerator, int fractionDenominator)
        {
            try
            {
                if (fractionDenominator == 0)
                {
                    throw new DivideByZeroException("Division by zero!");
                }

                this.fractionNumerator = fractionNumerator;
                this.fractionDenominator = fractionDenominator;
            }
            catch (DivideByZeroException dbze)
            {
                Console.WriteLine(dbze.Message);
            }
        }

        public int FractionNumerator
        {
            get { return this.fractionNumerator; }
            private set { this.fractionNumerator = value; }
        }

        public int FractionDenominator
        {
            get { return this.fractionDenominator; }
            private set
            {
                if (value == 0)
                {
                    throw new DivideByZeroException("Division by zero!");
                }

                this.fractionDenominator = value;
            }
        }

        public string DecimalValue
        {
            get
            {
                decimal decimalValue = Math.Round(this.fractionNumerator / (decimal)this.fractionDenominator, 2);

                return "(" + decimalValue.ToString("0.00") + ")";
            }
        }

        public static Fraction operator +(Fraction a, Fraction b)
        {
            int denominator = TheLeastCommonMultiple(a.fractionDenominator, b.fractionDenominator);
            int numerator = a.fractionNumerator * denominator / a.fractionDenominator + b.fractionNumerator * denominator / b.fractionDenominator;
            Fraction newFraction = new Fraction(numerator, denominator);
            Simplification(newFraction);

            return newFraction;
        }

        public static Fraction operator -(Fraction a, Fraction b)
        {
            int denominator = TheLeastCommonMultiple(a.fractionDenominator, b.fractionDenominator);
            int numerator = a.fractionNumerator * denominator / a.fractionDenominator - b.fractionNumerator * denominator / b.fractionDenominator;
            Fraction newFraction = new Fraction(numerator, denominator);
            Simplification(newFraction);

            return newFraction;
        }

        private static int TheLeastCommonMultiple(int firstNumber, int secondNumber)
        {
            return firstNumber * secondNumber / GreatestCommonDivisor(firstNumber, secondNumber);
        }

        private static int GreatestCommonDivisor(int firstNumber, int secondNumber)
        {
            if (firstNumber != 0)
            {
                int number1 = Math.Abs(firstNumber);
                int number2 = Math.Abs(secondNumber);
                if (number1 != number2)
                {
                    if (number1 > number2)
                    {
                        return GreatestCommonDivisor(number1 - number2, number2);
                    }
                    else
                    {
                        return GreatestCommonDivisor(number1, number2 - number1);
                    }
                }

                return number1;
            }
            else
            {
                return secondNumber;
            }
        }

        private static void Simplification(Fraction fract)
        {
            int commonDivisor = GreatestCommonDivisor(fract.FractionNumerator, fract.FractionDenominator);

            fract.FractionNumerator /= commonDivisor;
            fract.FractionDenominator /= commonDivisor;
        }

        public static Fraction Parse(string fractionAsString)
        {
            try
            {
                int fractionNumerator;
                int fractionDenominator;
                string[] fractionParts = fractionAsString.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
                bool isNumeratorCorrect = int.TryParse(fractionParts[0], out fractionNumerator);
                if (isNumeratorCorrect == false)
                {
                    throw new FormatException();
                }

                if (fractionParts.Length > 1)
                {
                    bool isDenominatorCorrect = int.TryParse(fractionParts[1], out fractionDenominator);
                    if (isDenominatorCorrect == false)
                    {
                        throw new FormatException("Given string is not a valid fraction!");
                    }

                    if (fractionDenominator == 0)
                    {
                        throw new DivideByZeroException("Division by zero!");
                    }
                }
                else
                {
                    fractionDenominator = 1;
                }

                if (fractionDenominator < 0)
                {
                    fractionDenominator = (-1) * fractionDenominator;
                    fractionNumerator = (-1) * fractionNumerator;
                }

                Fraction result = new Fraction(fractionNumerator, fractionDenominator);
                Simplification(result);
                Console.WriteLine("The fraction is valid!");

                return result;
            }
            catch (FormatException fe)
            {
                Console.WriteLine(fe.Message);
            }
            catch (DivideByZeroException dbze)
            {
                Console.WriteLine(dbze.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Unexpected error occured! " + e.Message);
            }

            return default(Fraction);
        }

        public override string ToString()
        {
            try
            {
                if (this == default(Fraction))
                {
                    throw new NullReferenceException("This is not a valid fraction!");
                }

                if (this.fractionDenominator == 0)
                {
                    throw new DivideByZeroException("Division by zero!");
                }

                string result = this.fractionNumerator + "/" + this.fractionDenominator;
                //Console.Write(result);

                return result;
            }
            catch (DivideByZeroException dbze)
            {
                return dbze.Message;
            }
            catch (NullReferenceException nre)
            {
                return nre.Message;
            }
        }
    }
}
