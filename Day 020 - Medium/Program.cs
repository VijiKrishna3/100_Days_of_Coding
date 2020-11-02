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

            // Minimizing array to only the highest countables
            var freq_s = from entry in subsets orderby entry.Value descending select entry;
            var newlist = from entry in freq_s where entry.Value == freq_s.First().Value select entry;

            // Now what can happen if we have i.e. 3 6 9 5 10 20 -> final input is 3 5 10 20 although neither can be devided by 3.
            // To counteract that, we will perform another modulo check on the new-found array
            var _n = newlist.ToList();
            var _nClean = _n.ToDictionary(o => o.Key, val => 0);

            for (int i = 0; i < _n.Count; ++i)
            {
                for (int j = 0; j < _n.Count; ++j)
                {
                    if (i != j && (_n[j].Key % _n[i].Key == 0 || _n[i].Key % _n[j].Key == 0))
                    {
                        ++_nClean[_n[i].Key];
                        ++_nClean[_n[j].Key];
                    }
                }
            }

            var _nFreq = from entry in _nClean orderby entry.Value descending select entry;
            var _nFinal = from entry in _nFreq where entry.Value == _nFreq.First().Value select entry;

            Console.Write("The largest subset is: ");
            foreach (var val in _nFinal)
                Console.Write($"{ val.Key} ");

            Console.ReadLine();
        }
    }
}
