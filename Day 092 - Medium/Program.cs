using System;
using System.Linq;

namespace _100daysCoding
{
    class Program_Day92
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter line of numbers: ");
            string[] ins = Console.ReadLine().Split(' ');
            int[] arr = (from entry in ins select Convert.ToInt32(entry)).ToArray();

            int[] ret = findSmallerValues(arr);
            Console.WriteLine("\nThe returned array is: ");
            foreach (int elem in ret)
                Console.Write($"{elem} ");
        }

        static int[] findSmallerValues(int[] arr)
        {
            if (arr.Length == 0) return new int[] { };

            int[] counts = new int[arr.Length];

            for (int j = arr.Length - 1; j >= 0; --j)
                for (int i = j + 1; i < arr.Length; ++i)
                    if (arr[i] < arr[j])
                        ++counts[j];

            return counts;
        }
    }
}
