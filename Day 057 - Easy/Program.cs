using System;
using System.Linq;

namespace _100daysCoding
{
    class ProgramDay57
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Write the stock prices in chronological order: ");
            var ins = Console.ReadLine().Split(' ').ToList();
            var arr = (from entry in ins select Convert.ToInt64(entry)).ToList();

            int bestProfitIndex = 0;
            for (int idx = 1; idx < arr.Count; ++idx)
            {
                if (arr.GetRange(idx, arr.Count - idx).Max() - arr[idx] >
                    arr.GetRange(bestProfitIndex, arr.Count - bestProfitIndex).Max() - arr[bestProfitIndex])
                    bestProfitIndex = idx;
            }

            Console.WriteLine($"The most profitable option would be to buy them at {arr[bestProfitIndex]}, " +
                              $"and sell them at {arr.GetRange(bestProfitIndex, arr.Count - bestProfitIndex).Max()}");
        }
    }
}
