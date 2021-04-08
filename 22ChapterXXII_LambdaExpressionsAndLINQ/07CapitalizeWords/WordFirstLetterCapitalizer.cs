using System.Globalization;

namespace _07CapitalizeWords
{
    public static class WordFirstLetterCapitalizer
    {
        public static string ToTitleCase(this string imput)
        {
            CultureInfo cultureInfo = new CultureInfo("en-US");
            TextInfo textInfo = cultureInfo.TextInfo;

            return textInfo.ToTitleCase(imput).ToString();
        }
    }
}