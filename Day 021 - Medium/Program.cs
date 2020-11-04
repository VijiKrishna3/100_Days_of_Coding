using MoreLinq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _100daysCoding
{
    class Program_Day21
    {
        static void Main(string[] args)
        {
            Console.Write("Input the 8-bit number (i.e. 01010101): ");
            string s = Console.ReadLine();
            Console.WriteLine($"Output: {string.Join("", s.Batch(2).SelectMany(x => x.Reverse()))}");
            Console.ReadLine();
        }
    }
}
