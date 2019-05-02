using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoExpert.Recursion
{
    class Permutation
    {
        public void GetPermutation(int []array, List<List<int>> permutation)
        {
            if (array.Length == 0)
                permutation= new List<List<int>>(0);
            var perm = new List<int>();
            //_PermutationHelper(array, perm, permutation);
            _PermutationHelperEFfec(array, perm, permutation, 0);
        }

        private void _PermutationHelperEFfec(int []array, List<int> perm, List<List<int>> permutation,int startIndex)
        {
            if (startIndex >= array.Length)
                permutation.Add(perm);
            else
            {
                for (int i = startIndex; i < array.Length; i++)
                {
                    List<int> newPermutation = new List<int>(perm);
                    newPermutation.Add(array[i]);
                    _Swap(array, startIndex, i);
                    _PermutationHelperEFfec(array, newPermutation, permutation, startIndex + 1);
                    _Swap(array, startIndex, i);
                }
            }
        }

        private void _Swap(int []array,int i,int j)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
        private void _PermutationHelper(int []array, List<int> perm, List<List<int>> perms)
        {
            if (array.Length == 0)
                perms.Add(perm);
            else
            {
                for(int i=0;i<array.Length;i++)
                {
                    var cpArray = array.Where(x => x != array[i]).ToArray();
                    var newPermutation = new List<int>(perm);
                    newPermutation.Add(array[i]);
                    _PermutationHelper(cpArray, newPermutation, perms);
                }
            }
        }
    }
}
