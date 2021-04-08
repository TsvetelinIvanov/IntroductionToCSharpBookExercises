using System;
using System.Text;

namespace _01StringBuilderSubstring
{
    public static class StringBuilderSubstringExtensionMethod
    {
        public static StringBuilder Substring(this StringBuilder stringBuilder, int index, int length)
        {
            StringBuilder substringBuilder = new StringBuilder();
            try
            {
                for (int i = index; i < index + length; i++)
                {
                    substringBuilder.Append(stringBuilder[i]);
                }
            }
            catch (ArgumentOutOfRangeException aore)
            {
                Console.WriteLine(aore.Message);
            }

            return substringBuilder;
        }
    }
}