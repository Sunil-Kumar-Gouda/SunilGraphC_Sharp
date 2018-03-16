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
        static Dictionary<char, int> dc = new Dictionary<char, int>();
        static Dictionary<int, char> dc2 = new Dictionary<int, char>();
        static void Main(string[] args)
        {
            Console.WriteLine(RomanIntegerHelper.RomanToInteger("mcmxlix"));
            int t = ConvertToDecimal("mcmxlix");
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
        public static string Repeat(this char c,int count)
        {
           return Enumerable.Repeat(c, count).Aggregate(
                //1. First parameter accumulator
                new StringBuilder(),
                //2. Func<AccumulatorValue,array item,AccumulatorValue
                (accumulator,item)=>accumulator.Append(item),
                //3. What to return from the accumulator by aggregate method
                ac=>ac.ToString()
                );
        }
    }
}
