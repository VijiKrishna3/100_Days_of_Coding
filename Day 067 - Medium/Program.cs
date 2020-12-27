using System;

namespace _100daysCoding
{
    class Program_Day67
    {
        static void Main(string[] args)
        {
            Console.Write("Integer a: ");
            int a = Convert.ToInt32(Console.ReadLine());

            Console.Write("Integer b: ");
            int b = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"{a}/{b} = {divide(a, b)}");
        }

        static int divide(int a, int b)
        {
            if (a < b || b == 0) return 0;
            if (a == b) return 1;
            if (b == 1) return a;

            int div = 0;
            while (a > b)
            {
                a -= b;
                ++div;
            }

            return div;
        }
    }
}
