using Combinatorics.Collections;
using System;
using System.Diagnostics;
using System.Linq;

namespace _100daysCoding
{
    class Program_Day38
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input all digits in a line i.e. 123: ");
            var n = Console.ReadLine();
            var sN = (from entry in n select entry).ToList();

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            var p = new Permutations<char>(sN, GenerateOption.WithoutRepetition);
            stopwatch.Stop();

            string temp = "";

            Console.WriteLine(stopwatch.Elapsed);
            Console.WriteLine("\nHere are all the permutations:");
            
            foreach (var v in p)
            {
                temp = string.Join("", v);

                Console.WriteLine(temp);

                temp = "";
            }
        }
    }
}
