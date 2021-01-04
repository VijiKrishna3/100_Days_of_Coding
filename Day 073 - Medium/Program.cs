using System;
using System.Collections.Generic;
using System.Linq;

namespace _100daysCoding
{
    class Program_Day73
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input all the sequence numbers in one line: ");
            var ins = Console.ReadLine().Split(' ');
            var arr = (from entry in ins select Convert.ToInt32(entry)).ToArray();

            Console.WriteLine($"Longest consecutive number count is {LongestConsecutive(arr)}.");
        }

        static int LongestConsecutive(int[] nums)
        {
            if (nums == null || nums.Length == 0) return 0;
            if (nums.Length == 1) return 1;

            Dictionary<int, int> cache = new Dictionary<int, int>();

            foreach (int n in nums)
                if (!cache.ContainsKey(n))
                    cache.Add(n, 0);

            int maxCount = 0;
            
            foreach(int n in nums)
            {
                int iter = n;
                int c = cache[n];
                if (c > 0) continue;
                while (cache.TryGetValue(iter, out int preCount) && iter != int.MaxValue)
                {
                    if (preCount > 0) { c += preCount; break; }
                    ++c;
                    ++iter;
                }

                cache[n] = c;
                maxCount = ((maxCount > c) ? maxCount : c);
            }

            return maxCount;
        }
    }
}
