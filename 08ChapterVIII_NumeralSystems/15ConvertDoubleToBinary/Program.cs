using System;

namespace _15ConvertDoubleToBinary
{
    class Program
    {
        static void Main(string[] args)
        {
            string numberString = Console.ReadLine();
            bool isInt = int.TryParse(numberString, out int integer);
            if (isInt)
            {
                if (integer == 0)
                {
                    Console.WriteLine(0);
                    return;
                }

                if (integer < 0)
                {
                    integer ^= int.MinValue;
                }
                string integerBinaryString = ConvertIntToBinary(integer);
                Console.WriteLine(integerBinaryString);
            }
            else
            {
                char sign = '0';
                if (numberString[0] == '-')
                {
                    sign = '1';
                }

                Console.WriteLine(sign);
                numberString = FixFloatSign(numberString);

                float realNumber = float.Parse(numberString);
                realNumber = Math.Abs(realNumber);

                if (realNumber > 0)
                {
                    float fractionalPart = realNumber % 1;
                    int wholePart = (int)(realNumber - fractionalPart);

                    ConvertFloatToBinaryIEEE754(fractionalPart, wholePart, out string fractionPartBinary, out string exponentBinary);

                    string exponent = FillExponent(exponentBinary);
                    Console.WriteLine(exponent);

                    string mantisa = FillMantisa(fractionPartBinary);
                    Console.WriteLine(mantisa);
                }
                else
                {
                    Console.WriteLine(new string('0', 8));
                    Console.WriteLine(new string('0', 23));
                }
            }
        }

        private static string ConvertIntToBinary(int integer)
        {
            string binaryNumberString = string.Empty;
            while (integer != 0)
            {
                int currentBit = integer % 2;
                integer /= 2;
                binaryNumberString = currentBit + binaryNumberString;
            }

            return binaryNumberString;
        }

        private static string FixFloatSign(string numberString)
        {
            string fixedNumber = string.Empty;
            for (int i = 0; i < numberString.Length; i++)
            {
                if (numberString[i] == ',')
                {
                    fixedNumber += '.';
                }
                else
                {
                    fixedNumber += numberString[i];
                }
            }

            return fixedNumber;
        }

        private static void ConvertFloatToBinaryIEEE754(float fractalPart, int wholePart, out string fractionPartBinary, out string exponentBinary)
        {
            fractionPartBinary = ConvertFractionToBinary(fractalPart);
            int exponentValue;
            if (wholePart >= 1)
            {
                string wholePartBinary = ConvertIntToBinary(wholePart);
                exponentValue = 127 + wholePartBinary.Length - 1;
                string startOfFraction = RemoveFirstBits(wholePartBinary, 1);
                fractionPartBinary = startOfFraction + fractionPartBinary;
            }
            else //if the number is between 0 and 1:
            {
                exponentValue = CalculateNegativeExponentCase(fractionPartBinary);
                fractionPartBinary = RemoveFirstBits(fractionPartBinary, exponentValue + 1);
                exponentValue = 127 - exponentValue - 1;
            }

            exponentBinary = ConvertIntToBinary(exponentValue);
        }

        private static string ConvertFractionToBinary(float fractionalalPart)
        {
            string binaryNumber = string.Empty;
            int bitsCount = 0;
            float fractional = fractionalalPart;
            while (fractionalalPart != 0 && bitsCount <= 46)
            {
                float multiplied = fractional * 2;
                fractional = multiplied % 1;
                float currentBit = multiplied - fractional;
                binaryNumber += currentBit;
                bitsCount++;
            }

            return binaryNumber;
        }

        private static string RemoveFirstBits(string wholePartBinary, int bitsCount)
        {
            string wholePartWitoutFirstBit = string.Empty;
            for (int i = bitsCount; i < wholePartBinary.Length; i++)
            {
                wholePartWitoutFirstBit += wholePartBinary[i];
            }

            return wholePartWitoutFirstBit;
        }

        private static int CalculateNegativeExponentCase(string fractionPartBinary)
        {
            int firstOneSignPossition = 0;
            for (int i = 0; i < fractionPartBinary.Length; i++)
            {
                if (fractionPartBinary[i] == '1')
                {
                    firstOneSignPossition = i;
                    break;
                }
            }

            return firstOneSignPossition;
        }

        private static string FillExponent(string exponentBinary)
        {
            string exponent;
            if (exponentBinary.Length < 8)
            {
                string zeroesFill = new string('0', 8 - exponentBinary.Length);
                exponent = zeroesFill + exponentBinary;
            }
            else
            {
                exponent = exponentBinary;
            }

            return exponent;
        }

        private static string FillMantisa(string fractionPartBinary)
        {
            string mantisa = null;
            if (fractionPartBinary.Length < 23)
            {
                string zeroesFill = new string('0', 23 - fractionPartBinary.Length);
                mantisa = fractionPartBinary + zeroesFill;
            }
            else
            {
                for (int i = 0; i < 23; i++)
                {
                    mantisa += fractionPartBinary[i];
                }
            }

            return mantisa;
        }
    }
}