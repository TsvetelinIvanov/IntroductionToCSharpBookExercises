using System;

namespace _01ConvertFromDecimalToBinary
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputNumberString = Console.ReadLine();

            bool isInteger = int.TryParse(inputNumberString, out int integer);
            if (isInteger)
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

                string integerBinary = ConvertIntToBinary(integer);
                Console.WriteLine(integerBinary);
            }
            else
            {
                char sign = '0';
                if (inputNumberString[0] == '-')
                {
                    sign = '1';
                }

                Console.WriteLine(sign);
                inputNumberString = FixFloatSign(inputNumberString);

                float realNumber = float.Parse(inputNumberString);
                realNumber = Math.Abs(realNumber);

                if (realNumber > 0)
                {
                    float fractalPart = realNumber % 1;
                    int wholePart = (int)(realNumber - fractalPart);

                    ConvertFloatToBinaryIEEE754(fractalPart, wholePart, out string fractionPartBinary, out string exponentBinary);

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

        private static string ConvertIntToBinary(int decimalNumber)
        {
            string binaryNumber = string.Empty;
            while (decimalNumber != 0)
            {
                int currentBit = decimalNumber % 2;
                decimalNumber /= 2;
                binaryNumber = currentBit + binaryNumber;
            }

            return binaryNumber;
        }

        private static string FixFloatSign(string inputRealNumberString)
        {
            string fixedRealNumberString = string.Empty;
            for (int i = 0; i < inputRealNumberString.Length; i++)
            {
                if (inputRealNumberString[i] == ',')
                {
                    fixedRealNumberString += '.';
                }
                else
                {
                    fixedRealNumberString += inputRealNumberString[i];
                }
            }

            return fixedRealNumberString;
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
            else //if the number is between 0 and 1
            {
                exponentValue = CalculateNegativeExponentCase(fractionPartBinary);
                fractionPartBinary = RemoveFirstBits(fractionPartBinary, exponentValue + 1);
                exponentValue = 127 - exponentValue - 1;
            }

            exponentBinary = ConvertIntToBinary(exponentValue);
        }

        private static string ConvertFractionToBinary(float fractalPart)
        {
            string binaryFraction = string.Empty;
            int bitsCount = 0;
            float fractal = fractalPart;
            while (fractalPart != 0 && bitsCount <= 46)
            {
                float multiplied = fractal * 2;
                fractal = multiplied % 1;
                float currentBit = multiplied - fractal;
                binaryFraction += currentBit;
                bitsCount++;
            }

            return binaryFraction;
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
            if (exponentBinary.Length < 8) //filling all 8 bits
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
            string mantisa = string.Empty;
            if (fractionPartBinary.Length < 23) // filling all 23 bits
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
