using System;

namespace _100daysCoding
{
    class Program_Day63
    {
        static void Main(string[] args)
        {
            Console.Write("Enter x: ");
            int x = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter y: ");
            int y = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter b: ");
            int b = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"Result: {returnFunct(x, y, b)}");
        }

        static int returnFunct(int a, int b, int x)
        {
            return (a * x) - b * (x - 1);
        }
    }
}
