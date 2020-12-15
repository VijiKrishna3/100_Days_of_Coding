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

            var idx = arr.FindIndex(f => f == arr.Min());
            Console.WriteLine($"The most profitable option would be to buy them at {arr.Min()}, " +
                              $"and sell them at {arr.GetRange(idx, arr.Count - idx).Max()}");
        }
    }
}
