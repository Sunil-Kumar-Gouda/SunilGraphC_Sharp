using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolving.Roman_Integer
{
    public static class RomanIntegerHelper
    {
        public static int RomanToInteger(string roman)
        {
            char c1, c2;
            int integer = 0;
            int partialSum = 0;
            int i = 0;
            int? length = roman?.Length;
            Dictionary<char, int> dc = new Dictionary<char, int>();
            dc['M'] =1000;
            dc['D'] =500;
            dc['C'] =100;
            dc['L'] = 50;
            dc['X'] =10;
            dc['V'] =5;
            dc['I'] =1;

            if (length == null || length == 0)
                return -1;
            roman = roman.ToUpper();
            while (i < length - 1)
            {
                c1 = roman[i];
                c2 = roman[i + 1];
                if(dc[c1]<dc[c2])
                {
                    partialSum = dc[c2] - dc[c1];
                    i = i + 2;
                }
                else
                {
                    partialSum = dc[c1];
                    i = i + 1;
                }
                integer += partialSum;
            }
            if (i != length)
                integer += dc[roman[i]];
            return integer;
        }

    }
}
