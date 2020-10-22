using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _100daysCoding
{
    class Program_Day3
    {
        public static void nonprime_check(bool[] arr)
        {
            arr[0] = true; arr[1] = true; // --> non prime
            for (int i = 2; i < arr.Length; ++i)
            {
                if (!arr[i])
                {
                    for (int j = 2*i; j <= arr.Length; j += i)
                    {
                        arr[j] = true; // --> automatically not prime
                    }
                    Console.WriteLine(i);
                }   
            }
        }

        static void Main(string[] args)
        {
            int n = 0;
            while (n <= 2)
            {
                Console.Write("Define the upper limit of prime number generator (must be >2): ");
                n = Convert.ToInt32(Console.ReadLine());
            }

            bool[] nprime = new bool[n+1]; // 0-100 is 101 places ---> assume prime = false
            nonprime_check(nprime);
            Console.ReadLine();
        }
    }
}
