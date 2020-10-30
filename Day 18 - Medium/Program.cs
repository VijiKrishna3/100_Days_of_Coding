using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _100daysCoding
{
    class Program_Day18
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter all the elements of the list in a single line: ");
            string _s = Console.ReadLine();
            int[] arr = _s.Split(' ').Select(o => Convert.ToInt32(o)).ToArray();

            var arrFrequency = arr.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());

            // "Legacy" Sort
            var freq_s = from entry in arrFrequency orderby entry.Value descending select entry;

            // LINQ Sort
            var ordered = arrFrequency.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

            var bigBoy = freq_s.First();

            // "You can assume that such element exists." -> i.e. one element, must exist
            Console.WriteLine($"\nThe element that appears the most and more than half of the time is: {bigBoy.Key}.");
            Console.ReadLine();
        }
    }
}
