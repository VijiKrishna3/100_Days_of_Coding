using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _100daysCoding
{
    class Program_Day12
    {
        static void Main(string[] args)
        {
            Console.Write("Enter string one: ");
            string s1 = Console.ReadLine();

            Console.Write("\nEnter string two: ");
            string s2 = Console.ReadLine();

            // If strings not equally sized - no mapping can exist
            if (s1.Length != s2.Length)
            {
                Console.WriteLine("false");
                goto end;
            }

            Dictionary<char, char> dict = new Dictionary<char, char>();

            for (int i = 0; i < s1.Length; ++i)
            {
                if (!dict.ContainsKey(s1[i]))
                {
                    dict.Add(s1[i], s2[i]);
                }
                else if (!dict.ContainsValue(s2[i]))
                {
                    char t; dict.TryGetValue(s1[i], out t);
                    if ( t != s2[i])
                    {
                        Console.WriteLine("false");
                        goto end;
                    }
                }
            }

            Console.WriteLine("true");

        end:
            Console.ReadLine();
        }
    }
}
