using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace _100daysCoding
{
    class Program_Day52
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Which n-th perfect number do you want: ");
            int n = Convert.ToInt32(Console.ReadLine());

            Stopwatch t1 = new Stopwatch();

            t1.Start();
            Console.WriteLine($"\nNumber is : {findNthPerfect(n)}");
            t1.Stop();

            Console.WriteLine($"Time elapsed (my): {t1.ElapsedMilliseconds}");
            t1.Reset();

            t1.Start();
            Console.WriteLine($"\nNumber is : {findNthPerfectANSHD(n)}");
            t1.Stop();

            Console.WriteLine($"Time elapsed (anshd): {t1.ElapsedMilliseconds}");

        }

        static int[] maxes = new int[]{ 19, 28, 37, 46, 55, 64, 73, 82, 91 };
        static int[] startPoints = new int[] { 9, 8, 7, 6, 5, 4, 3, 2, 1 };
        static long findNthPerfect(int n)
        {
            if (n <= 9) return maxes[n - 1];

            long mult = 10;
            int cntr = 9;
            while (true)
            {
                for (int i = 0; i < 9; ++i)
                {
                    // maximumThreshold - the maximum number in the loop it can go to - say 50000 can go to 55000 maximum. (higher than that and sum is above 10)
                    var maximumThreshold = maxes[i] * mult;

                    // val - value that is set like 1 * 10 * 10 i.e. first it's 100 then it's 1000 etc.. the startpoint since we hardcoded the first 9 numbers.
                    long val = (i + 1) * mult * 10 + startPoints[i];

                    for (; val <= maximumThreshold; val += 9)
                    {
                        long sum = 0;
                        for (long x = val; x > 0; x /= 10) sum += x % 10;
                        if (sum == 10) cntr++;
                        if (cntr == n) return val;
                    }
                }
                mult *= 10;
            }
        }

        static long findNthPerfectANSHD(int n)
        {
            int count = 0;

            for (long r = 19;; r += 9)
            {
                long sum = 0;

                for (long x = r; x > 0; x = x / 10)
                { sum = sum + x % 10; }

                if (sum == 10)
                    count++;

                if (count == n)
                    return r;
            }
        }
    }
}
