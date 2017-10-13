using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming
{
    public class ClimbingStairs
    {
        private int ways;
        private int steps;
        private Dictionary<int, int> memoization = new Dictionary<int, int>();
        public int Ways
        {
            get
            {
                return ways;
            }
            private set
            {
                ways = value;
            }
        }
        public void CountWays(int n)
        {
            if (n < 0)
            {
                return;
            }
            else if(n==0)
            {
                steps++;
                return;
            }
            else
            {
                if (memoization.ContainsKey(n - 1))
                {
                    steps += memoization[n - 1];
                }
                else
                {
                    CountWays(n - 1);
                }
                if (memoization.ContainsKey(n - 2))
                {
                    steps += memoization[n - 2];
                }
                else
                {
                    CountWays(n - 2);
                }
            }
            if (!memoization.ContainsKey(n))
                memoization[n] = steps;
        }
    }
}
