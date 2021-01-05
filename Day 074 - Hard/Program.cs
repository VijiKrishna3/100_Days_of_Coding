using System;
using System.Linq;

namespace _100daysCoding
{
    class Program_Day74
    {
        static void Main(string[] args)
        {
            Console.Write("Enter all the coin values: ");
            var ins = Console.ReadLine().Split(' ');
            var coins = (from entry in ins select Convert.ToInt32(entry)).ToArray();

            Console.Write("Enter the number you want to build with the coins: ");
            int n = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"\nYou will need {muchoCoins(coins, n)} coins to get {n}.");
        }

        static int muchoCoins(int[] coins, int n)
        {
            int[] dp = new int[n + 1];
            for (int i = 1; i <= n; ++i)
            {
                dp[i] = int.MaxValue;
                foreach (int coin in coins)
                    if (i >= coin && (dp[i - coin] != int.MaxValue))
                        dp[i] = ((dp[i] < dp[i - coin] + 1) ? dp[i] : dp[i - coin] + 1);
            }
            return (dp[n] == int.MaxValue) ? -1 : dp[n];
        }
    }
}
