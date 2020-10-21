using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _100daysCoding
{
    class Program_Day5
    {
        static void Main(string[] args)
        {
            Console.Write("Input a string: ");
            string inputLine = Console.ReadLine();

            // This is a necessary conversion because strings are immutable in C#
            char[] inputArr = inputLine.ToCharArray();
            
            for (int i = 0; i < inputLine.Length - 1; ++i)
            {
                if (inputArr[i] == inputArr[i + 1])
                {
                    for (int j = i + 1; j < inputLine.Length; ++j)
                    {
                        (inputArr[i + 1], inputArr[j]) = (inputArr[j], inputArr[i + 1]);
                    }
                }
            }

            string output = new string(inputArr);

            for (int i = 0; i < inputLine.Length - 1; ++i)
            {
                if (inputArr[i] == inputArr[i + 1])
                {
                    Console.WriteLine("None.");
                    Console.ReadLine();
                    System.Environment.Exit(0);
                }
            }

           
            Console.WriteLine(output);

            Console.ReadLine();
        }
    }
}
