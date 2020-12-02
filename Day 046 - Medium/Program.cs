using System;
using System.Linq;

namespace _100daysCoding
{
    class Program_Day46
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input the array in one line as in: 1 2 3 4");
            var ins = Console.ReadLine().Split(' ').ToList();
            var integers = (from entry in ins orderby Convert.ToInt32(entry) select Convert.ToInt32(entry)).ToList();

            Console.Write("Input index of number: ");
            int idx = Convert.ToInt32(Console.ReadLine());

            int sortedIndexNext = integers.FindIndex(p => p == Convert.ToInt32(ins[idx])) + 1;

            // Means the element is the greatest
            if (sortedIndexNext >= integers.Count)
                Console.WriteLine("null");
            else
                Console.WriteLine($"{ins.FindIndex(b => b == integers[sortedIndexNext].ToString())}");
        }
    }
}
