using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _100daysCoding
{
    class Program_Day22
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input two strings: ");
            string[] s = Console.ReadLine().Split(' ');

            Console.WriteLine("Input the text content");
            var t = Console.ReadLine().Split(' ');

            int i = 0;
            var dict = t.ToDictionary(value => ++i,o => o);

            var keywords = from entry in dict where entry.Value == s[0] || entry.Value == s[1] select entry;
            int minimumWords = dict.Count();

            for (int k = 0; k < keywords.Count(); ++k)
                if (keywords.ElementAt(k).Value == s[0])
                    for (int j = 0; j < keywords.Count(); ++j)
                        if (keywords.ElementAt(j).Value == s[1])
                            minimumWords = Math.Min(minimumWords, Math.Abs(keywords.ElementAt(j).Key - keywords.ElementAt(k).Key)- 1);
                    

            Console.WriteLine($"\nThere are {minimumWords} words in between {s[0]} and {s[1]}");
            Console.ReadLine();
        }
    }
}
