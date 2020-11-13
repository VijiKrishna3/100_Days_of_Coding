using System;
using System.Collections.Generic;

namespace _100daysCoding
{
    class Program_Day29
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the number of bits: ");
            int n = Convert.ToInt32(Console.ReadLine());

            var res = gray_code(n);
            foreach (var x in res)
                Console.WriteLine(x);
        }

        static List<string> gray_code(int n)
        {
            List<string> result = new List<string>();

            if (n == 0)
            {
                return result;
            }
            else if (n == 1)
            {
                result.Add("0");
                result.Add("1");
                return result;
            }

            int cntr = 0;
            while (cntr != Math.Pow(2, n))
            {
                ++cntr;
            }

            /* Permutations for 2bit with 2 for loops
             * 
             * var str = "";
                            str += x;
                            str += y;
                            result.Add(str);
                            ++cntr; */


            return result;
        }
    }
}
