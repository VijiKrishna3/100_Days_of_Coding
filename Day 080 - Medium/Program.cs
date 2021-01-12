using System;

namespace _100daysCoding
{
    class Program_Day80
    {
        static void Main(string[] args)
        {
            for(int i = 0; i < 10; ++i)
            {
                Console.WriteLine($"Toss {i + 1}: {(toss_unbiased() ? 1 : 0)}");
            }
        }

        static bool toss_unbiased()
        {
            int res = Convert.ToInt32(toss_biased()) - Convert.ToInt32(toss_biased());
            if (res < 0) return false;
            else if (res > 0) return true;
            else return toss_unbiased();
        }

        static Random rnd = new Random();
        // Assume this is the "secret" biased method.
        static bool toss_biased()
        {
            if (rnd.NextDouble() > 0.89) return true;
            else return false;
        }
    }
}
