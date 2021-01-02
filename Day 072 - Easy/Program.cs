using System;
using System.Text;

namespace _100daysCoding
{
    class Program_Day72
    {
        static void Main(string[] args)
        {
            Console.Write("Input string one: ");
            string a = Console.ReadLine();

            Console.Write("Input string two: ");
            string b = Console.ReadLine();

            Console.WriteLine($"Can the two strings be matched: {canBeMatched(a, b)}");
        }

        static bool canBeMatched(string a, string b)
        {
            if (a.Length != b.Length) return false;
            if (a == b) return true;

            StringBuilder sBuild = new StringBuilder(a); 
            for (int i = a.Length - 1; i >= 0; --i)
            {
                sBuild.Insert(0, a[i]);
                if (sBuild.ToString(0, a.Length) == b) return true;
            }

            return false;
        }
    }
}
