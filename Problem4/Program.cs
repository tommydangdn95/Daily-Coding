using System;

namespace Problem4
{
    class Program
    {
        /*Given an array of integers, find the first missing positive integer in linear time and constant space. 
         * In other words, find the lowest positive integer that does not exist in the array. 
         * The array can contain duplicates and negative numbers as well.
         * For example, the input [3, 4, -1, 1] should give 2. The input [1, 2, 0] should give 3.
         *
         * 
         ** */
        static void Main(string[] args)
        {
            int a = FindMissingNumber(new int[] { 3, 4, -1, 1 });
            Console.WriteLine(a);
        }

        static int FindMissingNumber(int[] arrays)
        {
            for(int i =0; i< arrays.Length; i++)
            {
                while(arrays[i] != i + 1)
                {
                    if (arrays[i] <= 0 || arrays[i] > arrays.Length)
                        break;
                    if (arrays[i] == arrays[arrays[i] - 1])
                        break;
                    int temp = arrays[i];
                    arrays[i] = arrays[temp - 1];
                    arrays[temp - 1] = temp;
                }
            }

            for(int i = 0;i < arrays.Length; i++)
            {
                while(arrays[i] != i + 1)
                {
                    return i + 1;
                }
            }

            return arrays.Length + 1;
        }
    }
}
