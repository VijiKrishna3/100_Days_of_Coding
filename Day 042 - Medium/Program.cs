using System;
using System.Linq;

namespace _100daysCoding
{
    class Program_Day42
    {
        /*You are given an array of nonnegative integers.
         * Let's say you start at the beginning of the array and are trying to advance to the end.
         * You can advance at most, the number of steps that you're currently on. Determine whether you can get to the end of the array.
         * For example, given the array [1, 3, 1, 2, 0, 1], we can go from indices 0 -> 1 -> 3 -> 5, so return true.
         * Given the array [1, 2, 1, 0, 0], we can't reach the end, so return false.
         *
         * Another test array [1, 5, 0, 0, 0, 0, 2] should return true
         */

        static void Main(string[] args)
        {
            Console.WriteLine("Input the array in one line as in: 1 2 3 4");
            var ins = Console.ReadLine().Split(' ');
            var integers = (from entry in ins select Convert.ToInt32(entry)).ToList();

            int[] myUltraBigSchlong = new int[integers.Count];
            int min;

            myUltraBigSchlong[integers.Count - 1] = 0;

            for (int i = integers.Count - 2; i >= 0; i--)
            {
                if (integers[i] == 0)
                {
                    myUltraBigSchlong[i] = int.MaxValue;
                }

                else if (integers[i] >= integers.Count - i - 1)
                {
                    myUltraBigSchlong[i] = 1;
                }
                else
                {
                    min = int.MaxValue;

                    for (int j = i + 1; j < integers.Count && j <= integers[i] + i; j++)
                        if (min > myUltraBigSchlong[j]) min = myUltraBigSchlong[j];

                    if (min != int.MaxValue) myUltraBigSchlong[i] = min + 1;
                    else myUltraBigSchlong[i] = min;
                }
            }

            if (myUltraBigSchlong[0] == int.MaxValue)
                Console.WriteLine("false");
            else
                Console.WriteLine("true");
        }
    }
}
