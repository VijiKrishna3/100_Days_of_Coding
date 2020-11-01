using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _100daysCoding
{
    class Program_Day10
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

            // Usage of goto is only because of unecessary code repetiton

            // Begin checking array pivot points:
            // If array[0] is smaller than array[n-1] then arraay wasn't rotated

            if (array[0] < array[nElements-1])
            {
                Console.WriteLine($"\nThe array was rotated at element {array[0]}.");
                goto end;
            }

            // If that isn't the case, the easiest search that satisfies O(n log n) is binary.
            int minimum = array[0];
            int start = 0, end = nElements, temp;

            for (int i = 0; i < Math.Log(nElements, 2); ++i)
            {
                temp = (end + start) / 2;
                
                // If array before centerpoint is smaller than last number in array then it's pivoted before center
                if (array[nElements-1] > array[temp-1])
                {
                    end = temp;
                    if (array[temp-1] < minimum)
                    {
                        minimum = array[temp];
                    }
                }
                else
                {
                    start = temp;
                    if (array[temp] < minimum)
                    {
                        minimum = array[temp];
                    }
                }
            }

            Console.WriteLine($"\nThe array was rotated at element {minimum}.");

        end:
            Console.ReadLine();
            System.Environment.Exit(1);
        }
    }
}
