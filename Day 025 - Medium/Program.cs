using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _100daysCoding
{
    class Program_Day25
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input all elements in a sequence: ");
            var split = Console.ReadLine().Split(' ');
            var intArr = (from entry in split select Convert.ToInt32(entry)).ToArray(); 

            var dictInt = intArr.GroupBy(x => x).ToDictionary(x => x.Key, o => o.Count());

            var duplicateResult = (from entry in dictInt where entry.Value == 2 select entry).ToList();
            try
            {
                Console.WriteLine($"Duplicate: {duplicateResult[0].Key}");
            }
            catch { }
            Console.ReadLine();
        }
    }
}
