using Combinatorics.Collections;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _100daysCoding
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input all digits in a line i.e. 123: ");
            var n = Console.ReadLine().ToList();

            bool changes = false;
            for (int i = n.Count - 1; i > 0; --i)
            {
                if (n[i - 1] < n[i])
                {
                    ++n[i - 1];
                    --n[n.FindLastIndex(a => a == n[i - 1])];
                    changes = true;
                    n.Sort(i, n.Count - i, null);
                    break;
                }
            }

            if (!changes)
                n.Reverse();

            foreach (var x in n)
                Console.Write($"{x}");
        }
    }
}
