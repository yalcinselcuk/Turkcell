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

        public static string GetPasswordStrength(this string value)
        {
            bool includeLetter = false;
            bool includeDigit = false;
            bool includeSymbol = false;

            value.ToCharArray().ToList().ForEach( c =>
            {
                if (char.IsLetter(c))
                {
                    includeLetter = true;
                }
                else if (char.IsDigit(c))
                {
                    includeDigit = true;
                }
                else
                {
                    includeSymbol = true;
                }
            });
            string result = string.Empty;
            if(includeLetter && includeDigit && includeSymbol) 
            {
                result = "Güçlü";
            }else if(includeLetter && includeDigit && !includeSymbol)
            {
                result = "orta";
            }
            else
            {
                result = "zayıf";
            }
            return result;
        }
    }
}
