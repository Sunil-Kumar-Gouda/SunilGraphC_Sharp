using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming
{
    public class CoinChange
    {
        public long getWays(long n, long[] c)
        {
            long p = 0;
            getWaysH(n, c, c.Length - 1, ref p);
            return p;
        }
        static void getWaysH(long n, long[] c, int i, ref long ways)
        {
            if (n == 0)
            {
                ways++;
                return;
            }
            if (n < 0 || i < 0)
                return;
            getWaysH(n - c[i], c, i, ref ways);
            getWaysH(n, c, i - 1, ref ways);
        }
    }
}
