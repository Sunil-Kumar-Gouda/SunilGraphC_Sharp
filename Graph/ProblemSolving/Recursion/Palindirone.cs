using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolving.Recursion
{
    class Palindirone
    {
        //For integer
        public static bool CheckPalindironeInt(int n)
        {
            return _CheckPalindironeIntH(n, n, 0);
        }
        /// <summary>
        /// CheckPalindironeInt Helper method
        /// </summary>
        /// <param name="n"></param>
        /// <param name="o"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        static bool _CheckPalindironeIntH(int n, int o, int r)
        {
            if (n == 0)
                return o == r;
            r = r * 10 + n % 10;
            return _CheckPalindironeIntH(n / 10, o, r);
        }
        //For string
        public static bool CheckPalindironeString(string s)
        {
            if (s?.Length == 0 || s?.Length == 1)
                return true;
            return !string.IsNullOrEmpty(s) && _CheckPalindironeStringH(s, 0);
        }
        /// <summary>
        /// CheckPalindironeString Helper
        /// </summary>
        /// <param name="s"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        static bool _CheckPalindironeStringH(string s,int i)
        {
            if (i == s.Length)
                return true;
            return _CheckPalindironeStringH(s, i + 1)&& s[s.Length-i-1]==s[i];
        }
    }
}
