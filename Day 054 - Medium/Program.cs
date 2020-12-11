using System;
using System.Collections;
using System.Collections.Generic;

namespace _100daysCoding
{
    class Program_Day54
    {
        static void Main(string[] args)
        {
            // We will be creating the "linked list" of numbers as an iterating array
            // i.e. 5 -> 1 -> 8 -> 0 -> 3
            int[] arr = { 5, 1, 8, 0, 3 };

            Console.Write("Input k: ");
            int k = Convert.ToInt32(Console.ReadLine());

            Array.Sort(arr, Comparer<int>.Create((x, y) => { return x < k ? -1 : 0; }));

            foreach (var e in arr)
                Console.Write($"{e} -> ");
        }
    }
}
