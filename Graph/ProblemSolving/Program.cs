using DynamicProgramming;
using ProblemSolving.Recursion;
using ProblemSolving.Roman_Integer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolving
{
    class Program
    {
        static void SpiralTraversealOfMatrix()
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());
            bool isCompleted = true;
            int i = 0, j = 0, kthNumber = 0, v = 0;
            int ub = 0, db = n - 1, lb = 0, rb = n - 1;
            int[,] ar = new int[n, n];
            /*  1 2 3
                4 5 6
                7 8 9
            */
            for (int r = 0; r < n; r++)
                for (int c = 0; c < n; c++)
                    ar[i, j] = ++v;
            v = 0;
            while (true)
            {
                isCompleted = true;
                //right
                for (j = lb; j <= rb; j++)
                {
                    v++;
                    isCompleted = false;
                    if (v == k)
                    {
                        kthNumber = ar[i, j];
                        isCompleted = true;
                    }
                }
                if (isCompleted)
                    break;
                j = rb;
                rb--;

                //down
                for (i = ub + 1; i <= db; i++)
                {
                    v++;
                    isCompleted = false;
                    if (v == k)
                    {
                        kthNumber = ar[i, j];
                        isCompleted = true;
                    }
                }
                if (isCompleted)
                    break;
                i = db;
                db--;

                //left
                for (j = rb; j >= lb; j--)
                {
                    v++;
                    isCompleted = false;
                    if (v == k)
                    {
                        kthNumber = ar[i, j];
                        isCompleted = true;
                    }
                }
                if (isCompleted)
                    break;
                j = lb;
                lb++;

                //up
                for (i = db; i >= ub + 1; i--)
                {
                    v++;
                    isCompleted = false;
                    if (v == k)
                    {
                        kthNumber = ar[i, j];
                        isCompleted = true;
                    }
                }
                if (isCompleted)
                    break;
                ub++;
                i = ub;
            }
            Console.WriteLine(kthNumber);
        }
        static Dictionary<char, int> dc = new Dictionary<char, int>();
        static Dictionary<int, char> dc2 = new Dictionary<int, char>();
        static void Main(string[] args)
        {
            //int n = int.Parse(Console.ReadLine());
            //int []bst = Array.ConvertAll(Console.ReadLine().Split(new char []{ ' ' }),chs=>int.Parse(chs));
            Console.WriteLine(TreeProblem.TreeProblem.CountLeafAfterRemove(new int[] {-1, 0 ,0 ,1 ,1}, 0));
            //SpiralTraversealOfMatrix();
            //bool isPalindrone = Palindirone.CheckPalindironeInt(1112111);
            //Subset.PrintAllBinaryNumberNoConsecutive1(2);

            //var convertingStringArrayToDouble=Array.ConvertAll(args, x => double.Parse(x));

            //CoinChange coin = new CoinChange();
            //long[] c = new long[3] { 1, 2, 3 };
            //Console.WriteLine(coin.getWays(4, c));
            //Console.WriteLine(RomanIntegerHelper.RomanToInteger("mcmxlix"));
            //int t = ConvertToDecimal("mcmxlix");
        }
        public static int ConvertToDecimal(string numerals)
        {
            numerals = numerals.ToUpper();
            dc['M'] = 1000;
            dc['D'] = 500;
            dc['C'] = 100;
            dc['L'] = 50;
            dc['X'] = 10;
            dc['V'] = 5;
            var result = numerals
                .ToCharArray()
                .Reverse()
                .Select(c => dc[c])
                .Aggregate(
                    new { MaxValue = 0, RunningTotal = 0 },
                    (state, item) => new
                    {
                        MaxValue = Math.Max(state.MaxValue, item),
                        RunningTotal = item >= state.MaxValue ? state.RunningTotal + item : state.RunningTotal - item
                    },
                    aggregate => aggregate.RunningTotal);

            return result;
        }
        public static string ConvertToNumerals(int number)
        {
            dc2[1000] = 'M';
            dc2[500] = 'D';
            dc2[100] = 'C';
            dc2[50] = 'L';
            dc2[10] = 'X';
            dc2[5] = 'V';
            Stack<int> stcNumbers = new Stack<int>();
            stcNumbers.Push(1);
            Func<int, Stack<int>, string> numeralsEnumerator = (int numberToConvert, Stack<int> availableNumerals) =>
            {
                if (numberToConvert == 0)
                {
                    return string.Empty;
                }

                int currentNumeral = availableNumerals.Peek();

                int quotient = numberToConvert / currentNumeral;
                int remainder = numberToConvert % currentNumeral;

                string numberAsNumerals = dc2[currentNumeral].Repeat(quotient);
                return numberAsNumerals;
            };

            var result = numeralsEnumerator(number, stcNumbers)
                     .Aggregate(
                        new StringBuilder(),
                        (sb, numerals) => sb.Append(numerals),
                        sb => sb.ToString());

            return result;
        }
    }
    static class RepeatChar
    {
        public static string Repeat(this char c, int count)
        {
            return Enumerable.Repeat(c, count).Aggregate(
                 //1. First parameter accumulator
                 new StringBuilder(),
                 //2. Func<AccumulatorValue,array item,AccumulatorValue
                 (accumulator, item) => accumulator.Append(item),
                 //3. What to return from the accumulator by aggregate method
                 ac => ac.ToString()
                 );
        }
    }
}
