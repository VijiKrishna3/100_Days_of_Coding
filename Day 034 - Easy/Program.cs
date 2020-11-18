using System;
using System.Collections.Generic;
using System.Linq;

namespace _100daysCoding
{
    class Program_Day34
    {
        static void Main(string[] args)
        {
            Console.WriteLine("List 7 -> 7 -> 7 -> 4 would be written as 7 7 7 4");
            Console.WriteLine("\nInput the linked list:");
            
            var lList = Console.ReadLine().Split(' ');
            var reList = (from entry in lList select Convert.ToInt32(entry)).ToList();

            Console.WriteLine("\nInput k: ");
            int k = Convert.ToInt32(Console.ReadLine());

            List<int> swap = new List<int>();
            int xReplace = reList.Max() + 1;


            for (int i = 0; i < reList.Count - k; ++i)
            {
                swap.Add(reList[i]);
                reList[i] = xReplace;
            }

            reList.AddRange(swap);

            Console.WriteLine("\nMoved list: ");
            for (int i = lList.Length - k; i < reList.Count; ++i)
            {
                Console.Write($"{reList[i]}");
                if (i != reList.Count - 1)
                    Console.Write($" -> ");
            }
                  
        }
    }
}
