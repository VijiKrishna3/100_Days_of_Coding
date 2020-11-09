using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _100daysCoding
{
    class Program_Day26
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input a string consisting of (, ), and/or * :");
            string ws = Console.ReadLine();

            Solution1(ws);
            Solution2(ws);

            Console.ReadLine();
        }

        // This method only works if the string can be sorted/manipulated/the order doesn't matter.
        static void Solution1(string ws)
        {
            int openbracket = ws.Count(f => f == '(');
            int closedbracket = ws.Count(f => f == ')');
            int replacements = ws.Count(f => f == '*');

            Console.WriteLine($"Open: {openbracket}\n" +
                $"Closed: {closedbracket}\n" +
                $"Replacements: {replacements}");

            if ((openbracket == closedbracket))
            {
                Console.WriteLine($"\nBalanced.");
            }
            else if (Math.Max(openbracket, closedbracket) <= (Math.Min(openbracket, closedbracket) + replacements))
            {
                Console.WriteLine($"\nBalanced.");
            }
            else
            {
                Console.WriteLine($"\nUnbalanced.");
            }
        }

        // This method should work every time
        static void Solution2(string ws)
        {
            Dictionary<int, char> PositionChar = new Dictionary<int, char>();
            bool broken = false;
            bool balanced = false;

            // Determines which of brackets there are more
            int bracketMatcher = Math.Max(ws.Count(f => f == '('), ws.Count(f => f == ')'));

            Values[] matched = new Values[ws.Length];
            for (int i = 0; i < matched.Length; ++i) matched[i] = Values.standby;

            for (int i = 0; i < ws.Length; ++i)
            {
                if (ws[i] == '(')
                {
                    matched[i] = Values.engaged_open;
                }
                
                if (ws[i] == ')')
                {
                    matched[i] = Values.matched_close;

                    if (matched.Count(x => x == Values.engaged_open) < matched.Count(x => x == Values.matched_close))
                    {
                        broken = true;
                        break;
                    }
                }

                if (ws[i] == '*')
                {
                    if (matched.Count(x => x == Values.engaged_open) > matched.Count(x => x == Values.matched_close))
                    {
                        matched[i] = Values.matched_close;
                    }
                    else
                    {
                        matched[i] = Values.engaged_open;
                    }
                }
            }

            if (!broken)
            {
                if (matched.Count(x => x == Values.engaged_open) != matched.Count(x => x == Values.matched_close))
                {
                    balanced = false;
                }
                else
                {
                    balanced = true;
                }
            }

            Console.WriteLine($"\n{(balanced ? "Balanced." : "Unbalanced.")}");
        }

        public enum Values { engaged_open, matched_close, standby};
    }
}
