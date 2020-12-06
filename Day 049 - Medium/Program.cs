using System;
using System.Collections.Generic;
using System.Linq;

namespace _100daysCoding
{
    class Program_Day49
    {
        static void Main(string[] args)
        {
            // 1,5,5 == 11
            int[] arr1 = { 1, 5, 11, 5 };

            // false: 9+3+1 = 13 == 16 = 12+4
            int[] arr2 = { 3, 4, 9, 1, 12 };

            Console.WriteLine($"arr1: {isDivisible(arr1)}");
            Console.WriteLine($"arr2: {isDivisible(arr2)}");
        }

        static bool isDivisible(int[] arr)
        {
            long sum = arr.Sum();

            // There can't be two subsets if the sum of elements isn't divisible into two subsets without a remainder
            if (sum % 2 == 1) return false;
            if (sum == 0) return true;

            // Initialize matrix for calculating divisibility
            bool[,] part = new bool[sum / 2 + 1, arr.Length + 1];
            for (int i = 1; i <= sum / 2; ++i) part[i, 0] = false;
            for (int i = 0; i <= arr.Length; ++i) part[0, i] = true;

            for (int i = 1; i <= sum / 2; ++i)
            {
                for (int j = 1; j <= arr.Length; ++j)
                {
                    part[i, j] = part[i, j - 1];
                    if (i >= arr[j - 1]) part[i, j] = part[i, j - 1] || part[i - arr[j - 1], j - 1];
                }
            }

            return part[sum / 2, arr.Length];
        }
    }
}
