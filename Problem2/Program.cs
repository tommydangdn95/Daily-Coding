using System;

namespace Problem2
{
    class Program
    {
        /** Problem
         * Given an array of integers, return a new array such that each element at index i of the new array is the product of all the numbers in the original array except the one at i.
         * For example, if our input was [1, 2, 3, 4, 5], the expected output would be [120, 60, 40, 30, 24]. If our input was [3, 2, 1], the expected output would be [2, 3, 6]
         * 
         */
        static void Main(string[] args)
        {
            int[] arrays = new int[] { 0, 0, 3, 4, 5 };
            var newProductArrays = ProductArray(arrays);
            Console.Write("[ ");
            foreach(var item in newProductArrays)
            {
                Console.Write(item + " ");
            }
            Console.Write(" ]");
        }

        private static int[] ProductArray(int[] arrays)
        {
            int[] newArrays = new int[arrays.Length];
            int products = 1;
            var countNumberZero = 0;
            for(int i=0;i<arrays.Length; i++)
            {
                if(arrays[i] !=0)
                {
                    products *= arrays[i];
                }
                else
                {
                    countNumberZero++;
                }
            }

           
            switch (countNumberZero)
            {
                case 0:
                    for (int i = 0; i < arrays.Length; i++)
                    {
                        newArrays[i] = products / arrays[i];
                    }
                    break;
                case 1:
                    for (int i=0; i< arrays.Length; i++)
                    {
                        if(arrays[i] == 0)
                        {
                            newArrays[i] = products;
                        }
                    }
                    break;
                default:
                    break;
            }

            return newArrays;
        }
    }
}
