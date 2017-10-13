using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming
{
    class MaximumProfitIntStock
    {
        private int[] prices;
        private int maximumProfit;
        public int []Prices { get; set; }
        public int MaximumProfit
        {
            get
            {
                return maximumProfit;
            }
            private set
            {
                maximumProfit = value;
            }
        }
        public MaximumProfitIntStock(int []prices)
        {
            Prices = prices;
        }
        /// <summary>
        /// Brute Force method to find out the maximum difference. Complexity O(n^2).
        /// Loop runs (n*(n-1))/2
        /// </summary>
        public void FindMaximumProfit()
        {
            MaximumProfit = 0;
            for(int i=0;i<Prices.Length-1;i++)
            {
                int profit;
                for(int j=i+1;j<Prices.Length;j++)
                {
                    profit = Prices[j] - Prices[i];
                    if (profit > MaximumProfit)
                        MaximumProfit = profit;
                }
            }
        }
        /// <summary>
        /// Dynamic Programming single pass.
        /// </summary>
        public void FindMaximumProfitDynamic()
        {
            MaximumProfit = 0;
            int minimumPrice= int.MaxValue;
            for (int i=0;i<Prices.Length;i++)
            {
                if (Prices[i] < minimumPrice)
                    minimumPrice = Prices[0];
                else if (Prices[i] - minimumPrice > MaximumProfit)
                    MaximumProfit = Prices[i] - minimumPrice;
            }
        }
    }
}
