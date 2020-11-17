using System;

namespace _100daysCoding
{
    class Program_Day30
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter string one: ");
            string s1 = Console.ReadLine();

            Console.WriteLine("\nEnter string two: ");
            string s2 = Console.ReadLine();

            Console.WriteLine($"\nNumber of needed changes is {computeChanges(s1, s2)}.");
        }

        static int computeChanges(string s1, string s2)
        {
            int changes_min = (Math.Max(s1.Length, s2.Length));

            if (s1.Length > s2.Length)
                (s1, s2) = (s2, s1);


            foreach (var c in s1)
            {
                if (s2.Contains(c))
                    --changes_min;
            }

            return changes_min;
        }
    }
}
