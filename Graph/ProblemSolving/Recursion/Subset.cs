using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolving.Recursion
{
    class Subset
    {
        public static void PrintAllPossibleStringsOfKLength(char[] set, int k)
        {
            _PrintAllPossibleStringsOfKLengthH(set, "", k);
        }
        static void _PrintAllPossibleStringsOfKLengthH(char[] set, string prefix, int k)
        {
            if (k == 0)
                Console.WriteLine(prefix);
            for (int i = 0; i < set.Length; i++)
            {
                String newPrefix = prefix + set[i];
                _PrintAllPossibleStringsOfKLengthH(set, newPrefix, k - 1);
            }
        }
        public static void PrintAllBinaryNumberNoConsecutive1(int k)
        {
            _PrintAllBinaryNumberNoConsecutive1H("", k, false);
        }
        static void _PrintAllBinaryNumberNoConsecutive1H(string prefix, int k, bool isOne)
        {
            if (k == 0)
            {
                Console.WriteLine(prefix);
                return;
            }
            if (isOne)
            {
                _PrintAllBinaryNumberNoConsecutive1H(prefix+"0",k-1,!isOne);
            }
            else
            {
                _PrintAllBinaryNumberNoConsecutive1H(prefix + "0", k - 1, isOne);
                _PrintAllBinaryNumberNoConsecutive1H(prefix + "1", k - 1, !isOne);
            }
        }
    }
}
