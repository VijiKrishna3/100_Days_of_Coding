using System;
using System.Linq;

namespace _100daysCoding
{
    class Program_Day91
    {
        static void Main(string[] args)
        {
            Console.Write("Input a string: ");
            string param = Console.ReadLine();

            Console.WriteLine($"Balanced string would look like {balance(param)}.");
        }

        static string balance(string p)
        {
            int[] x = new int[] { p.Count(x => x == '('), p.Count(x => x == ')') };
            int totalBracketsMissing = Math.Max(x[0], x[1]);

            return string.Concat(Enumerable.Repeat("()", totalBracketsMissing));
        }
    }
}
