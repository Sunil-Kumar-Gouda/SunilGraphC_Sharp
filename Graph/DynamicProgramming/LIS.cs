using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming
{
    public static class LIS
    {
        public static int LongestIncreasingSubsequence(int[] ar)
        {
            int[] lis = Enumerable.Repeat(1,ar.Length).ToArray();
            for (int i = 1; i < ar.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (ar[i] > ar[j] && (lis[j] + 1) > lis[i])
                        lis[i] = lis[j] + 1;
                }
            }
            int max = -1;
            for (int j = 0; j < lis.Length; j++)
            {
                if (lis[j] > max)
                    max = lis[j];
            }
            return max;
        }
    }
}
