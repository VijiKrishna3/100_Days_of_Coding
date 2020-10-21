using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace _100daysCoding
{
    class Program_Day4
    {

        /* WORST CASE SCENARIO (n-1 swaps -> no matches initially)
         * Test Input 1: 1 2 3 4 5 6
         * Test RndIn 1: 3 5 1 6 2 4
         * 
         * First Run: 3 4 1 6 2 5 - 1
         * Second Run: 3 4 1 2 6 5 - 2
         */
        static void Main(string[] args)
        {
            Console.Write("Number of pairs: ");
            int n = Convert.ToInt32(Console.ReadLine());

            Console.Write("\nInput pairs: \n");
            Pair[] pairs = new Pair[n];

            for (int i = 0; i < n; ++i) pairs[i] = new Pair();

            // Inputting arrays
            for (int i = 0; i < n; ++i)
            {
                Console.Write("Input the first member for pair {0}: ", i + 1);
                pairs[i].User1 = Convert.ToInt32(Console.ReadLine());

                Console.Write("Input the second member for pair {0}: ", i + 1);
                pairs[i].User2 = Convert.ToInt32(Console.ReadLine());
            
                // Swaps making sure the user1 is always smaller than user 2
                if (pairs[i].User2 < pairs[i].User1)
                {
                    (pairs[i].User2, pairs[i].User1) = (pairs[i].User1, pairs[i].User2);
                }
            }

            Console.Write("\nInput newly ordered array: \n");
            int[] toSortArray = new int[2 * n];

            // Input randomized array
            for (int i = 0; i < 2*n; ++i)
            {
                Console.Write("{0} : ", i + 1);
                toSortArray[i] = Convert.ToInt32(Console.ReadLine());
            }

            // Sorting randomized array (i.e user1 < user2)
            for (int i = 0; i < 2 * n; i += 2)
            {
                if (toSortArray[i] > toSortArray[i + 1])
                {
                    (toSortArray[i], toSortArray[i + 1]) = (toSortArray[i + 1], toSortArray[i]);
                }
            }

            // Initializing the new counter
            int swaps = 0;

            // Matching the jews
            for (int i = 0; i < n; ++i)
            {
                Pair customVal = new Pair();
                for (int j = i; j < 2 * n; ++j)
                {
                    if (pairs[i].User1 == toSortArray[j] && toSortArray[j] != pairs[i].User2)
                    {
                        customVal.User1 = j;
                    }
                    else if (pairs[i].User2 != toSortArray[j])
                    {
                        customVal.User2 = j;
                    }

                    if (customVal.User1 != 0 && customVal.User2 != 0)
                    {
                        (toSortArray[customVal.User1], toSortArray[customVal.User2]) = (toSortArray[customVal.User2], toSortArray[customVal.User1]);
                        ++swaps;

                        customVal.User1 = 0; customVal.User2 = 0;
                    }
                }
            }

            Console.WriteLine("Number of swaps: {0}", swaps);

            Console.ReadKey();
        }
    }

    public class Pair
    {
        public Pair()
        {
            this.User1 = 0;
            this.User2 = 0;
        }

        public int User1 { get; set; }
        public int User2 { get; set; }
    }
}
