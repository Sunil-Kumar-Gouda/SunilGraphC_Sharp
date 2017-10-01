using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting.MergeSort
{
    public class MergeSort
    {
        int[] sortedData;
        MergeSort(int[] data)
        {
            sortedData = data;
            CallSort(data);
        }
        private void CallSort(int[] data)
        {
            if (data == null || data.Length <= 1)
                return;
        }
        private void Sort(int[] data, int start, int last)
        {
            if (last-start<1)
                return;
            int mid = ( last-start) / 2;
            Sort(data, start, mid);
            Sort(data, mid + 1, last);
            Merge(start, mid, last);
        }
        private void Merge(int start,int mid,int last)
        {
            if (last - start < 1)
                return;
            int n = last - start + 1;
            int[] aux = new int[last - start + 1];
            for (int m = 0; m < n; m++)
            {
                aux[m] = sortedData[m + start];
            }
            int k = start;
            int i = 0;
            int j = (n -1)/ 2 + 1; ;
            int count = 0;
            while(count<n)
            {
                if(i==(n-1)/2 || aux[i]>= aux[j])
                {
                    sortedData[k++] = aux[j++];
                    count++;
                }
                if(j==n||aux[j]>aux[i])
                {
                    sortedData[k++] = aux[i++];
                    count++;
                }

            }

        }


    }
}
