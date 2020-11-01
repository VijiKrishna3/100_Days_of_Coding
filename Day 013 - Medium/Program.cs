using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _100daysCoding
{
    class Program_Day13
    {
        static void Main(string[] args)
        {
            Console.Write("Input a number of elements in the array: ");
            int nElements = Convert.ToInt32(Console.ReadLine());

            int[] array = new int[nElements];
            int minimum = 0, sum_arr = 0, num_of_negs = 0;

            for (int i = 0; i < nElements; ++i)
            {
                Console.Write($"Input the {i + 1}. element: ");
                array[i] = Convert.ToInt32(Console.ReadLine());

                if (array[i] < 0)
                {
                    ++num_of_negs;
                    if (array[i] < minimum)
                    {
                        minimum = array[i];
                    }
                }

                sum_arr += array[i];
            }

            Console.WriteLine($"The maximum subarray sum equals {sum_arr - minimum}.");
            Console.ReadLine();
        }
    }
}
