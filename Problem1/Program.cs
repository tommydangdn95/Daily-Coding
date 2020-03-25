using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem1
{

    /** Problem
     * Given a list of numbers and a number k, return whether any two numbers from the list add up to k.
     *For example, given [10, 15, 3, 7] and k of 17, return true since 10 + 7 is 17.
     */
    class Program
    {
        static void Main(string[] args)
        {
            int[] lists = new int[] { 10, 15, 3, 17, 14 };
            var isHasPair = HasPairWithSum(lists, 17);
            if (isHasPair)
            {
                Console.WriteLine("Has Pair");
            }
            else
            {
                Console.WriteLine("Doesn't");
            }

        }

        public static bool HasPairWithSum(int[] pairSum, int sum)
        {
            foreach(var item in pairSum)
            {
                var remain = sum - item;
                if (pairSum.Contains(remain))
                    return true;
            }

            return false;
        }
    }
}
