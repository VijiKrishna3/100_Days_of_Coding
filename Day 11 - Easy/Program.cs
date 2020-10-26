using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _100daysCoding
{
    class Program_Day11
    {
        static void Main(string[] args)
        {
            Console.Write("Input a number of elements in the list: ");
            int nElements = Convert.ToInt32(Console.ReadLine());

            int[] array = new int[nElements];
            string output = "";

            for (int i = 0; i < nElements; ++i)
            {
                Console.Write($"Input the {i + 1}. element: ");
                array[i] = Convert.ToInt32(Console.ReadLine());

                // Auto swapping every second element
                if (i % 2 == 1)
                {
                    (array[i - 1], array[i]) = (array[i], array[i - 1]);
                    output += array[i - 1] + " -> " + array[i];

                    if (i != nElements - 1)
                    {
                        output += " -> ";
                    }
                }
            }

            Console.WriteLine("\n" + output);
            Console.ReadKey();
            
        }
    }
}
