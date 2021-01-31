using System;
using System.Collections.Generic;
using System.Linq;

namespace _100daysCoding
{
    class Program_Day95
    {
        static void Main(string[] args)
        {
            Console.Write("Input nums for array: ");
            string[] ss = Console.ReadLine().Split(' ');
            List<int> arr = (from entry in ss select Convert.ToInt32(entry)).ToList();

            intList list = new intList(arr);
            Console.Write("Insert i: ");
            int i = Convert.ToInt32(Console.ReadLine());

            Console.Write("Insert j: ");
            int j = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"The sum of elements between i and j is {list.sum(i, j)}");
        }

        public class intList
        {
            private long total;
            List<long> prefixSum;

            public intList(List<int> arr)
            {
                total = 0;
                prefixSum = new List<long>();
                foreach(int e in arr)
                {
                    total += e;
                    prefixSum.Add(total);
                }
            }

            public long sum(int i, int j)
            {
                if (i < 0 || j >= prefixSum.Count) throw new Exception("Indexes invalid for this operation.");
                if (i >= j) return 0;
                else if (i == 0) return prefixSum[j - 1];
                else return prefixSum[j - 1] - prefixSum[i - 1];
            }
        }
    }
}
