using System;
using System.Linq;

namespace _100daysCoding
{
    class Program_Day55
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input all the array numbers in one line");
            var ins = Console.ReadLine().Split(' ').ToList();
            var arr = (from entry in ins select (Convert.ToInt64(entry) * Convert.ToInt64(entry))).ToArray();
            Array.Sort(arr);

            foreach (var e in arr)
                Console.Write($"{e} ");
        }
    }
}
