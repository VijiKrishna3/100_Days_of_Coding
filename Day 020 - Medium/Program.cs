using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _100daysCoding
{
    class Program_Day20
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter all the elements of the list in a single line: ");
            string _s = Console.ReadLine();
            int[] arr = _s.Split(' ').Select(o => Convert.ToInt32(o)).ToArray();

            var subsets = arr.ToDictionary(key => key, value => 0);

            // So if a number can be devided by a subset, we increase the number's value
            // Whatever value has the most elements in the end is the biggest subset

            for(int i = 0; i < arr.Length; ++i)
            {
                for (int j = 0; j < arr.Length; ++j)
                {
                    if (i != j && (arr[j] % arr[i] == 0 || arr[i] % arr[j] == 0))
                    {
                        ++subsets[arr[i]];
                        ++subsets[arr[j]];
                    }
                }
            }

            var freq_s = from entry in subsets orderby entry.Value descending select entry;

            var newlist = from entry in freq_s where entry.Value == freq_s.First().Value select entry;

            Console.Write("The largest subset is: ");
            foreach (var val in newlist)
                Console.Write($"{ val.Key} ");

            Console.ReadLine();
        }
    }
}
