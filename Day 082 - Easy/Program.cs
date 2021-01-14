using System;
using System.Collections.Generic;
using System.Linq;

namespace _100daysCoding
{
    class Program_Day82
    {
        static void Main(string[] args)
        {
            Console.Write("Input n: ");
            int n = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"{n} is a palindrome check says: {fancyPalindrome(n)}.");
        }

        static bool fancyPalindrome(int n)
        {
            List<int> num = new List<int>();
            while (n != 0)
            {
                num.Add(n % 10);
                n /= 10;
            }

            return Enumerable.SequenceEqual(num, num.ToArray().Reverse());
        }
    }
}
