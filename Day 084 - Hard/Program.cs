using System;

namespace _100daysCoding
{
    class Program_Day84
    {
        static void Main(string[] args)
        {
            Console.Write("Enter n: ");
            int n = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"You will need {muchoSquaro(n)} numbers squared to reach {n}.");
        }

        static int muchoSquaro(int n)
        {
            int[] dp = new int[n + 1];
            for (int i = 1; i <= n; ++i)
            {
                dp[i] = int.MaxValue;
                for (int j = 1; j * j <= i; ++j)
                    dp[i] = (dp[i] < dp[i - j * j] + 1) ? dp[i] : dp[i - j * j] + 1;
            }

            return dp[n];
        }
    }
}
