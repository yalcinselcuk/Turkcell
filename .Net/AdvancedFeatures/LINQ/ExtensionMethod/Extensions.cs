using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethod
{
    public static class Extensions
    {
        public static double GetSquare(this int value)
        {
            return Math.Pow(value, 2);
        }

        public static string MergeWords(this string value)
        {
            return value.Replace(" ","");
        }
    }
}
