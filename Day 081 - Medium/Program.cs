using System;
using System.Linq;

namespace _100daysCoding
{
    class Program_Day81
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Insert all array elements in one line (i.e. 1 1 0 1)");
            string[] ins = Console.ReadLine().Split(' ');
            int[] arr = (from entry in ins select Convert.ToInt32(entry)).ToArray();

            Console.WriteLine($"This array can be jumped through: {isJumpable(arr)}");
        }

        static bool isJumpable(int[] arr)
        {
            Array.Resize(ref arr, arr.Length - 1);

            int steps = 0;
            foreach (int x in arr)
            {
                steps = (steps > x) ? steps : x;
                if (steps == 0) return false;
                --steps;
            }

            return true;
        }
    }
}
