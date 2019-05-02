using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgoExpert.ArrayT;
using AlgoExpert.Recursion;
using System.Diagnostics;

namespace AlgoExpert
{
    class Program
    {
        static void Main(string[] args)
        {
           var answer= NumberSum.ThreeNumberSum(new int[] { 12, 3, 1, 2, -6, 5, -8, 6 }, 0);
            var permutations = new List<List<int>>();
            new Permutation().GetPermutation(new int[]{1,2,3 },permutations);
            Debugger.Break(); ;
        }
    }
}
