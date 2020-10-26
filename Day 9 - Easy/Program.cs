using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _100daysCoding
{
    class Program_Day8
    {
        static void Main(string[] args)
        {
            Console.Write("Input a number of elements in an array: ");
            int nElements = Convert.ToInt32(Console.ReadLine());

            int[] array = new int[nElements];

            for (int i = 0; i < nElements; ++i)
            {
                Console.Write($"Input the {i + 1}. element: ");
                array[i] = Convert.ToInt32(Console.ReadLine());
            }

            // Properly initializing Dictionary
            SortedDictionary<int, int> positions = new SortedDictionary<int, int>();
            for (int i = 0; i < nElements; ++i)
            {
                positions[array[i]] = 0;
            }

            // EndValue data and a temporary variable placeholder initialized
            int endVal = 0, temp = 0;

            for (int i = 0; i < nElements; ++i)
            {
                temp = Math.Max(temp, positions[array[i]]);
                positions[array[i]] = i + 1;
                endVal = Math.Max(endVal, i - temp + 1);
            }

            Console.WriteLine($"The length of the largest subarray of distinct elements is {endVal}.");

            Console.ReadLine();
        }
    }
}
