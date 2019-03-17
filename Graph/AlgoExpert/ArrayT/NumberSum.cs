using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoExpert.ArrayT
{
    class NumberSum
    {
        public static int[] TwoNumberSum(int[] array, int targetSum)
        {
            Array.Sort(array);
            int j = array.Length - 1;
            int i = 0;
            int sum;
            while (i < j)
            {
                sum = array[i] + array[j];
                if (sum == targetSum)
                    return new[] { array[i], array[j] };
                else if (sum < targetSum)
                    i++;
                else
                    j++;
            }
            return new int[] { };
        }

        /// <summary>
        /// Using Dictionary
        /// </summary>
        /// <param name="array"></param>
        /// <param name="targetSum"></param>
        /// <returns></returns>
        public static int[] TwoNumberSumH(int[] array, int targetSum)
        {
            HashSet<int> set = new HashSet<int>();
            int i = 0;
            int remaining;
            while(i<array.Length)
            {
                remaining = targetSum - array[i];
                if (set.Contains(remaining))
                {
                    return remaining > array[i] ? new int[] { array[i], remaining }: new int[] { remaining,array[i] };
                }
                else
                {
                    set.Add(array[i]);
                }
            }
            return new int[] { };
        }

        public static List<int[]> ThreeNumberSum(int[] array,int targetSum)
        {
            int i = 0;
            int j, k;
            int actualSum;
            var list = new List<int[]>();
            Array.Sort(array);
            while(i<array.Length)
            {
                j = i + 1;
                k = array.Length-1;
                while(j<k)
                {
                    actualSum = array[i] + array[j] + array[k];
                    if (targetSum == actualSum)
                    {
                        list.Add(new int[] { array[i], array[j], array[k] });
                        j++;
                        k--;
                    }
                    else if (actualSum < targetSum)
                        j++;
                    else
                        k--;
                }
                i++;
            }
            return list;
        }
    }
}
