using System;
using System.Linq;

namespace PriceComparator.Utils
{
    static class StringExtensions
    {
        public static string DigitsOnly(this string input)
        {
            return new string(input.Where(char.IsDigit).ToArray());
        }

        public static Tuple<double, double> ToTermRange(this string input)
        {
            return new Tuple<double, double>(0, 0);
        }
    }
}
