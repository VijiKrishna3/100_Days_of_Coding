using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _100daysCoding
{
    class Program_Day24
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input format: 0 3 2 6 will be automatically paired as [0,3], [2,6]");
            Console.Write("Input all intervals: ");

            var inputs = Console.ReadLine().Split(' ');

            /* Test subject:
             * var inputs = "0 3 2 6 3 4 6 9".Split(' ');
             * 
             * Output:
             * [3, 6] */

            List<Pair> intervalPairs = new List<Pair>();

            for (int i = 0; i < inputs.Length; i += 2)
            {
                intervalPairs.Add(new Pair(Convert.ToInt32(inputs[i]), Convert.ToInt32(inputs[i + 1])));
            }

            var queryFirst = (from entry in intervalPairs select entry.item1).ToArray();
            var querySecond = (from entry in intervalPairs select entry.item2).ToArray();
            Array.Sort(queryFirst);
            Array.Sort(querySecond);

            Pair set = new Pair(querySecond[0], queryFirst[querySecond.Length - 1]);

            Console.WriteLine($"The minimum set is: [{set.item1}, {set.item2}].");
            Console.ReadLine();
        }
    }

    class Pair
    {
        public int item1;
        public int item2;

        public Pair(int t1, int t2)
        {
            item1 = t1;
            item2 = t2;
        }
    }
}
