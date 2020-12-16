using QuikGraph;
using System;
using System.Collections.Generic;

namespace _100daysCoding
{
    class Node
    {
        string val;
        public List<List<Node>> children = new List<List<Node>>();

        public Node(string value)
        { 
            this.val = value;
            for (int i = 0; i < 4; ++i) this.children.Add(new List<Node>()); // every direction
        }
    }
    class Program_Day48
    {
        static void Main(string[] args)
        {
            var rules1 = new string[] { "A N B", "C SE B", "C N B" };
            var rules2 = new string[] { "A N B", "A NW B"};
            var rules3 = new string[] { "A N B", "C N B" };

            Console.WriteLine($"rules1 : {isCompatible(rules1)}");
            Console.WriteLine($"rules2 : {isCompatible(rules2)}");
            Console.WriteLine($"rules3 : {isCompatible(rules3)}");
        }

        static int getDirectionNum(char dir)
        {
            switch(dir)
            {
                case 'N': return 0;
                case 'E': return 1;
                case 'S': return 2;
                case 'W': return 3;
                default: return -1;
            }
        }

        static bool isCompatible(string[] ruleset)
        {
            Dictionary<string, Node> mapped = new Dictionary<string, Node>();
            foreach (var rule in ruleset)
            {
                var x = rule.Split(' ');

                if (!mapped.ContainsKey(x[2])) mapped.Add(x[2], new Node(x[2]));
                if (!mapped.ContainsKey(x[0])) mapped.Add(x[0], new Node(x[0]));

                for (int i = 0; i < x[1].Length; ++i)
                {
                    if (mapped[x[0]].children[(getDirectionNum(x[1][i]) + 2) % 4].Contains(mapped[x[2]]) == true) return false;

                    mapped[x[0]].children[getDirectionNum(x[1][i])].Add(mapped[x[2]]);
                    mapped[x[2]].children[(getDirectionNum(x[1][i]) + 2) % 4].Add(mapped[x[0]]);

                    for (int dir = 0; dir < 4; ++dir)
                    {
                        if (dir == getDirectionNum(x[1][i])) continue;

                        foreach (var node in mapped[x[0]].children[getDirectionNum(x[1][i])])
                        {
                            if (node == mapped[x[2]]) continue;

                            node.children[getDirectionNum(x[1][i])].Add(mapped[x[2]]);
                            mapped[x[2]].children[(getDirectionNum(x[1][i]) + 2) % 4].Add(node);
                        }
                    }
                }
            }

            return true;
        }
    }
}