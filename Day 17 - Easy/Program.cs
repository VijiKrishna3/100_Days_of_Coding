using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _100daysCoding
{
    class Program_Day17
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter all the integers that you want to know the GCD of in a line: ");
            string _s = Console.ReadLine();
            int[] arr = _s.Split(' ').Select(o => Convert.ToInt32(o)).ToArray();

            Console.WriteLine($"{GCD(arr)}");
            Console.ReadLine();
        }

        static int GCD(int[] numbers)
        {
            return numbers.Aggregate(GCD);
        }

        static int GCD(int a, int b)
        {
            return b == 0 ? a : GCD(b, a % b);
        }
    }
}
