using System;
using System.Linq;

namespace _100daysCoding
{
    class Program_Day77
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the array in one line (i.e. 5 4 6 7): ");
            string[] ins = Console.ReadLine().Split(' ');
            int[] arr = (from entry in ins select Convert.ToInt32(entry)).ToArray();

            Console.WriteLine($"Can this array be in non-descending order: {nonDescendable(arr)}.");
        }

        static bool nonDescendable(int[] arr)
        {
            // Initialize all the needed variables.
            int i = 0, x = arr.Length, j = x - 1;

            // Can be non-descendable if the size of the array is 1 or 2
            if (x == 1 || x == 2) return true;

            // Find the element out of order
            while ((i < x - 1) && (arr[i] <= arr[i + 1])) ++i;

            // If that element is not at the complete end the array can be modified.
            if (i >= x - 2) return true;

            // Find the swap number (in the cross array -> j > i)
            while ((j > i) && (arr[j - 1] <= arr[j])) --j;

            // Check boundaries on each side of given number -> if possible return true so array is modifiable.
            if ((j == i + 1) && (i == 0 || arr[i] <= arr[j + 1] || arr[i - 1] <= arr[j])) return true;

            // Otherwise return false.
            return false;
        }
    }
}
