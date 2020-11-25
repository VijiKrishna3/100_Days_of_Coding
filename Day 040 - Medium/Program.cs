using System;
using System.Linq;

namespace _100daysCoding
{
    class Program_Day40
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input the array in one line as in: 1 2 3 4");
            var ins = Console.ReadLine().Split(' ');
            var integers = (from entry in ins select Convert.ToInt32(entry));

            // Find values that appear only once - exactly two elements only
            var varDict = (from entry in integers select entry).GroupBy(f => f).ToDictionary(f => f.Key, f => integers.Count(x => x == f.Key));
            var solutions = (from entry in varDict where entry.Value == 1 select entry.Key).ToList();

            Console.WriteLine("\nThe elements: ");
            foreach (var k in solutions)
                Console.Write($"{k} ");
        }
    }
}
