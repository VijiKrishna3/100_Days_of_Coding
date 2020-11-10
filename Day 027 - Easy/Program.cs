using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _100daysCoding
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input a 32-bit number (i.e. 1111 0000 1111 0000 1111 0000 1111 0000): ");
            string s = Console.ReadLine();
            s = s.Replace('0', '"').Replace('1', '0').Replace('"', '1');
            Console.WriteLine($"Output: {s}");
            Console.ReadLine();
        }
    }
}
