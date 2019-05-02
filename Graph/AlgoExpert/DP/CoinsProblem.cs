using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoExpert.DP
{
    class CoinsProblem
    {
        public static int MinimumNumberOfCoinsForChange(int n,int []coinTypes)
        {
            int[] change = Enumerable.Repeat(int.MaxValue, n + 1).ToArray();
            int remaining;
            int toCompare;
            change[0] = 0;
            foreach(int coin in coinTypes)
            {
                for(int i=0;i<change.Length;i++)
                {
                    //The required coin value should be greater than the available coin which u are iterating
                    if(coin<=i)
                    {
                        remaining = i - coin;
                        if (change[remaining] == int.MaxValue)
                            toCompare = int.MaxValue;
                        else
                            toCompare = change[remaining];
                        change[i] = Math.Min(toCompare, change[i]);
                    }
                }
            }
            return change[n] == int.MaxValue ? -1: change[0] ;
        }


        public static int numberOfWaysToMakeChange(int n, int[] denoms)
        {
            int[] ways = new int[n + 1];
            foreach(int denom in denoms)
            {
                for(int amount=0;amount<= n;amount++)
                {
                    if(amount>=denom)
                        ways[amount] += ways[amount-denom];
                }
            }
            return ways[n];
        }
    }
}
