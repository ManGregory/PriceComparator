using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceComparator.Utils
{
    static class StringExtensions
    {
        public static string ToDigitsOnly(this string input)
        {
            return new string(input.Where(char.IsDigit).ToArray());
        }

        public static Tuple<double, double> ToTermRange(this string input)
        {
            return new Tuple<double, double>(0, 0);
        }
    }
}
