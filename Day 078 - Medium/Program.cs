using System;
using System.Collections.Generic;
using System.Linq;

namespace _100daysCoding
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Input n: ");
            int n = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Input all elements of the list in one row (i.e. 5 4 3 2 6): ");
            string[] ins = Console.ReadLine().Split(' ');
            List<int> arr = (from entry in ins select Convert.ToInt32(entry)).ToList();

            Console.WriteLine($"Fresh number that isn't in list: {genUnique(n, arr)}.");
        }

        static int genUnique(int max, List<int> filled)
        {
            List<(int, int)> matches = new List<(int, int)>();
            Random rnd = new Random();
            filled.Sort();
            int x = 0;

            foreach (int i in filled)
            {
                if (x < i) matches.Add((x, i));
                x = i + 1;
            }

            if (x < max) matches.Add((x, max));

            int ret_idx = rnd.Next(0, matches.Count);
            return rnd.Next(matches[ret_idx].Item1, matches[ret_idx].Item2);
        }
    }
}
