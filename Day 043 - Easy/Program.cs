using System;

namespace _100daysCoding
{
    class Program_Day43
    {
        static void Main(string[] args)
        {
            Console.Write("Input n: ");
            long n = Convert.ToInt64(Console.ReadLine());

            Console.WriteLine($"The number of rounds equals {Math.Log2(n)}.");
        }
    }
}
