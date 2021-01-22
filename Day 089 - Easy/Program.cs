using System;
using System.Collections.Generic;

namespace _100daysCoding
{
    class Program_Day89
    {
        public class EgyptFraction
        {
            private List<int> sequence = new List<int>();

            private int GCD(int a, int b)
            {
                int c = a % b;
                while (c > 0) { a = b; b = c; c = a % b; }
                return b;
            }

            private void egyptFraction(int up, int down)
            {
                if (up == 1)
                {
                    sequence.Add(down);
                }
                else
                {
                    if (up <= 0) return;
                    int temp_down = Convert.ToInt32(Math.Ceiling((double)down / (double)up));
                    sequence.Add(temp_down);
                    int gcd = GCD((up * temp_down) - down, down * temp_down);
                    egyptFraction((up * temp_down) - down, down * temp_down);
                }
            }

            public void printResult()
            {
                foreach(var elem in sequence)
                {
                    Console.Write($"1/{elem}");
                    if (sequence[sequence.Count - 1] == elem) break;
                    Console.Write($" + ");
                }
                Console.WriteLine();
            }

            public EgyptFraction(int n, int m)
            {
                egyptFraction(n, m);
            }
        }

        static void Main(string[] args)
        {
            Console.Write("Input n: ");
            int n = Convert.ToInt32(Console.ReadLine());

            Console.Write("Input m: ");
            int m = Convert.ToInt32(Console.ReadLine());

            EgyptFraction newFrac = new EgyptFraction(n, m);
            newFrac.printResult();
        }
    }
}