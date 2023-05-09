using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace usingDelegates
{
    public class FilterHelper
    {
        //ilan verildi
        //public delegate bool criteria(int item);
        public List<int> Filter(List<int> numbers, Func<int,bool> aday)
        {
            List<int> filtered = new();
            foreach (int number in numbers)
            {
                if (aday(number))
                {
                    filtered.Add(number);
                }
            }
            return filtered;
        }
    }
}
