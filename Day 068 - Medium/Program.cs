using System;
using System.Diagnostics;

namespace _100daysCoding
{
    class Program_Day68
    {
        static void Main(string[] args)
        {
            Console.Write("Enter x: ");
            int x = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter y: ");
            int y = Convert.ToInt32(Console.ReadLine());


            // The following code is used to benchmark the perforamnce numbers between
            // the standard Math.Pow implementation and this recursive one.

            Stopwatch comparison = new Stopwatch();

            comparison.Start();
            Console.WriteLine($"Standard x^y = \n{Math.Pow(x, y)}");
            comparison.Stop();

            Console.WriteLine($"Time elapsed {comparison.Elapsed}");
            comparison.Reset();

            comparison.Start();
            Console.WriteLine($"Custom x^y = \n{customPow(x, y)}");
            comparison.Stop();

            Console.WriteLine($"Time elapsed {comparison.Elapsed}");
        }

        static double customPow(int x, int y)
        {
            if (y == 0) return 1;
            if (y == 1) return x;

            if (y % 2 == 0) return customPow(x, y / 2) * customPow(x, y / 2);
            else return x * customPow(x, (y - 1) / 2) * customPow(x, (y - 1) / 2);
        }
    }
}
