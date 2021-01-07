using System;

namespace _100daysCoding
{
    class Program_Day76
    {
        static void Main(string[] args)
        {
            Console.Write("Enter which number of the Fibonnaci sequence do you want: ");
            int n = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"Your number is {Fib_N(n)}.");
        }

        static long Fib_N(int n)
        {
            if (n == 0) return 0;

            long a = 0, b = 1;

            for (int i = 2; i <= n; ++i)
                (a, b) = (b, (a + b));

            return b;
        }
    }
}
