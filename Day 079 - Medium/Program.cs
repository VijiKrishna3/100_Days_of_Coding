using System;
using System.Linq;

namespace _100daysCoding
{
    class Program_Day79
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the rotated sorted array in one line (i.e. 5 6 7 1 2 3 4): ");
            string[] ins = Console.ReadLine().Split(' ');
            int[] array = (from entry in ins select Convert.ToInt32(entry)).ToArray();

            Console.Write("Enter the element which you want to find: ");
            int elem = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"Element is at index {findIndex(array, elem)}.");
        }

        static int findIndex(int[] arr, int elem)
        {
            if (arr == null || arr.Length == 0) return -1;

            int leftIdx = 0, rightIdx = arr.Length - 1;
            int midIdx = (rightIdx - leftIdx) / 2 + leftIdx;

            while (leftIdx != rightIdx)
            {
                if (elem <= arr[midIdx] && elem <= arr[leftIdx] && arr[leftIdx] > arr[midIdx])
                    rightIdx = midIdx;
                else if (elem >= arr[midIdx] && elem >= arr[leftIdx] && arr[leftIdx] > arr[midIdx])
                    leftIdx = midIdx;
                else if (elem <= arr[midIdx] && elem >= arr[leftIdx])
                    rightIdx = midIdx;
                else
                    leftIdx = midIdx + 1;

                midIdx = (rightIdx - leftIdx) / 2 + leftIdx;
            }

            return (arr[midIdx] == elem) ? midIdx : -1;
        }
    }
}
