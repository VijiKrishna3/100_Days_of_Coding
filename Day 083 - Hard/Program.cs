using System;
using System.Linq;
using MoreLinq;

namespace _100daysCoding
{
    class Program_Day83
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input all sets in order (pairs of two). ");
            Console.WriteLine("Inputs hould be as: '4 9 5 2' to get [(4, 9), (5, 2)]");

            Console.Write("Input: ");
            string[] ins = Console.ReadLine().Split(' ');

            int[] ax = (from entry in ins select Convert.ToInt32(entry)).ToArray();
            int[] ex = stabPoints(ax);

            Console.WriteLine("The minimum set array is: ");
            Console.Write($"[{ex[0]}, {ex[1]}]");
        }

        static int[] stabPoints(int[] ax)
        {
            return new int[] { ax.Where((_, i) => i % 2 == 1).Min(), ax.Where((_, i) => i % 2 == 0).Max() };
        }
    }
}
