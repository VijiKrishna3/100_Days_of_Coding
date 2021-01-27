using System;
using System.Linq;

namespace _100daysCoding
{
    class Program_Day93
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter line of numbers (that will represent the array i.e. 1 2 3 4 5 6 = [1, 2, 3, 4, 5, 6].");
            string[] ins = Console.ReadLine().Split(' ');
            int[] arr = (from entry in ins select Convert.ToInt32(entry)).ToArray();

            Console.Write("Enter k to shift by: ");
            int k = Convert.ToInt32(Console.ReadLine());

            shift(arr, k);
            Console.WriteLine("\nThe array after shifting is: ");
            foreach (int elem in arr)
                Console.Write($"{elem} ");
        }

        // Time - O(n); Space - O(1)
        static void shift(int[] arr, int k)
        {
            k = k % arr.Length; // in case k > array length
            int gcd = GCD(k, arr.Length), x;

            for (int i = 0; i < gcd; ++i)
            {
                int temp = arr[i], j = i;
                while (true)
                {
                    x = j + k;
                    if (x >= arr.Length) x -= arr.Length;
                    if (x == i) break;
                    arr[j] = arr[x];
                    j = x;
                }
                arr[j] = temp;
            }
        }

        static int GCD(int x, int y)
        {
            return (y == 0) ? x : GCD(y, x % y);
        }
    }
}
