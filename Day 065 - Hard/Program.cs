using System;
using System.Collections.Generic;
using System.Linq;

namespace _100daysCoding
{
    class Program_Day65
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter all strings with spaces as seperators (i.e: code edoc da d >>>> [code, edoc, da, d]:");
            var strings = Console.ReadLine().Split(' ');

            List<Match> palindromes = new List<Match>();

            for (int i = 0; i < strings.Length; ++i)
                for (int j = 0; j < strings.Length; ++j)
                    if (i != j)
                        if (matching(strings[i], strings[j]))
                            palindromes.Add(new Match(i, j));

            foreach (Match m in palindromes)
                Console.WriteLine($"({m.i}, {m.j})");

        }

        static bool matching(string a, string b)
        {
            string conc = a + b;
            string rev = new string(conc.Reverse().ToArray());
            if (conc == rev) return true;
            else return false;
        }

        public class Match
        {
            public int i, j;
            public Match(int i, int j)
            {
                this.i = i;
                this.j = j;
            }
        }
    }
}
