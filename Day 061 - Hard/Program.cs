using System;
using System.Collections.Generic;
using System.Linq;

namespace _100daysCoding
{
    class Program_Day61
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input all the sequence numbers in one line: ");
            var ins = Console.ReadLine().Split(' ');
            var arr = (from entry in ins select Convert.ToInt32(entry)).ToList();

            Console.WriteLine($"Length of the longest increasing subsequent array is {LongestSequence(arr)}.");
        }

        public static int LongestSequence(List<int> nums)
        {
            int counter = 0;

            if (nums.Count > 0)
            {
                counter = 1;
                int[] dp = new int[nums.Count];
                dp[0] = nums[0];
                for (int i = 1; i < nums.Count; i++)
                {
                    if (nums[i] < dp[0])
                        dp[0] = nums[i];
                    else if (nums[i] > dp[counter - 1])
                        dp[counter++] = nums[i];
                    else
                        dp[BinaryArray(dp, -1, counter - 1, nums[i])] = nums[i];
                }
            }
            return counter;
        }

        public static int BinaryArray(int[] a, int left, int right, int element)
        {
            while (right - left > 1)
            {
                int middle = (right + left) / 2;
                if (a[middle] >= element)
                    right = middle;
                else
                    left = middle;
            }
            return right;
        }
    }
}
