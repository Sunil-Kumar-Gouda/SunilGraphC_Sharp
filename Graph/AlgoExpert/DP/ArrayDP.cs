using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoExpert.DP
{
    public class ArrayDP
    {
        /// <summary>
        /// Time : O(n), Space : O(n)
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public int MaxSubsetSumNoAdjacent(int []array)
        {
            switch(array.Length)
            {
                case 0: return 0;
                case 1: return array[0];
            }
            array[1] = Math.Max(array[0], array[1]);

            for (int i=2;i<array.Length;i++)
            {
                array[i] = Math.Max(array[i - 1], array[i - 2] + array[i]);
            }
            return array[array.Length-1] ;
        }

        public int MaxSubsetSumNoAdjacentEff(int[] array)
        {
            switch (array.Length)
            {
                case 0: return 0;
                case 1: return array[0];
            }
            int first = array[0];
            int second = Math.Max(array[0], array[1]);

            for (int i = 2; i < array.Length; i++)
            {
                array[i] = Math.Max(second, first + array[i]);
                first = second;
                second = array[i];
            }
            return second;
        }
    }
}
