using System;

namespace _100daysCoding
{
    class Program_Day28
    {
        static void Main(string[] args)
        {
            Console.Write("Enter n: ");
            Int64 n = Convert.ToInt64(Console.ReadLine());

            Console.WriteLine($"The square root of {n} is {Math.Sqrt(n)}.");
        }
    }
}
