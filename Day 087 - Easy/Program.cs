using System;
using System.Collections.Generic;
using System.Linq;

namespace _100daysCoding
{
    class Program_Day87
    {
        static void Main(string[] args)
        {
            Console.Write("Input the whole array in a single line (i.e. 5 4 7 2): ");
            string[] ins = Console.ReadLine().Split(' ');
            int[] arr = (from entry in ins select Convert.ToInt32(entry)).ToArray();

            Console.Write("Enter k: ");
            int k = Convert.ToInt32(Console.ReadLine());

            int[] resArr = rotateArr(arr, k);
            Console.WriteLine("\nThe rotated array looks like this: ");
            foreach(int el in resArr)
                Console.Write($"{el} ");
        }

        static int[] rotateArr(int[] arr, int k)
        {
            if (k > arr.Length || k < 0) return arr;

            List<int> x = new List<int>();
            x.AddRange(arr[k..]);
            x.AddRange(arr.Take(k));

            return x.ToArray();
        }
    }
}

/*
 * This problem was asked by Amazon.
Given an array and a number k that's smaller than the length of the array, rotate the array to the right k elements in-place.
 */