using System;
using System.Collections.Generic;
using System.Linq;

namespace _100daysCoding
{
    class Program_Day97
    {
        static void Main(string[] args)
        {
            char[,] board = { { 'A', 'L', 'B', 'P'},
                              { 'C', 'O', 'E', 'Y'},
                              { 'F', 'C', 'H', 'P'},
                              { 'B', 'A', 'D', 'A'}};

            List<string> correctWords = new List<string>{ "AFOCAL", "CHAPEL", "CLOCHE", "DHOLE", "LOCHE", "CHOLA", "CHELA",
                                                          "HOLEY", "FOCAL", "FOLEY", "COLEY", "COLBY", "COHAB", "COBLE", "DACHA",
                                                          "BACHA", "BACCO", "BACCA", "BLECH", "PHOCA", "ALOHA", "ALEPH", "CHAPE",
                                                          "BOCCA", "BOCCE", "BOCHE", "LECH", "PECH", "OCHE", "FOAL", "YECH", "OBEY",
                                                          "YEBO", "LOCA", "LOBE", "LOCH", "HYPE", "HELO", "PELA", "HOLE", "COCA"};

            List<string> expanded = new List<string>(correctWords);
            expanded.AddRange(new string[] { "DUMMY", "TESTING", "WORDS", "NAZI" });

            List<string> boggleSolver = Boggle.solveBoggle(board, expanded);

            // Console.WriteLine($"SW: {boggleSolver.Count} CW: {correctWords.Count}");
            Console.WriteLine("Found words: \n");
            foreach (string i in boggleSolver)
                Console.WriteLine(i);
        }

        public class Boggle
        {
            private class wWrap
            {
                public Dictionary<char, wWrap> miniDict;
                private int size;

                public wWrap()
                {
                    size = 0;
                    miniDict = new Dictionary<char, wWrap>();
                }

                public void addWord(string word)
                {
                    if (word.Length == 0) { miniDict['&'] = null; return; }
                    char letter = word[0];

                    wWrap val = new wWrap();
                    if (miniDict.ContainsKey(letter)) val = miniDict[letter];
                    else miniDict[letter] = val;

                    size++;
                    val.addWord(word[1..]);
                }
            }

            private class Coord
            {
                public int x, y;
                public Coord(int x, int y)
                {
                    this.x = x;
                    this.y = y;
                }

                public static bool operator ==(Coord obj1, Coord obj2)
                {
                    return obj1.x.Equals(obj2.x) && obj1.y.Equals(obj2.y);
                }

                public static bool operator !=(Coord obj1, Coord obj2)
                {
                    return !(obj1 == obj2);
                }

                public HashSet<Coord> getHS()
                {
                    return new HashSet<Coord> { this };
                }

                public static HashSet<Coord> getHS(int x, int y)
                {
                    return new HashSet<Coord> { new Coord(x, y)};
                }

                public static HashSet<Coord> getADJ(int x, int y)
                {
                    HashSet<Coord> adj = new HashSet<Coord>();
                    int rx = Math.Max(0, x - 1), ry = Math.Max(0, y - 1);
                    int ix = Math.Min(3, x + 1), iy = Math.Min(3, y + 1);

                    adj.Add(new Coord(x, ry));
                    adj.Add(new Coord(x, iy));
                    adj.Add(new Coord(rx, y));
                    adj.Add(new Coord(rx, ry));
                    adj.Add(new Coord(rx, iy));
                    adj.Add(new Coord(ix, y));
                    adj.Add(new Coord(ix, ry));
                    adj.Add(new Coord(ix, iy));

                    return adj;
                }
            }

            // miniDict['&'] unique char
            private static void findWords(Coord a, wWrap mini, HashSet<Coord> seen, char[,] board, HashSet<string> sol, string current)
            {
                char letter = board[a.x, a.y];
                if (mini.miniDict.ContainsKey(letter) == false) return;

                current += letter;
                wWrap next = mini.miniDict[letter];
                if (next.miniDict.ContainsKey('&')) sol.Add(current);

                var adjCoords = Coord.getADJ(a.x, a.y);
                foreach (var coord in adjCoords)
                {
                    if (seen.Contains(coord))
                        continue;

                    var copy = seen;
                    copy.Add(coord);
                    findWords(coord, next, copy, board, sol, current);
                }
            }

            public static List<string> solveBoggle(char[,] board, List<string> dict)
            {
                wWrap miniDict = new wWrap();

                foreach (string word in dict)
                    miniDict.addWord(word);

                HashSet<string> solutions = new HashSet<string>();

                for (int i = 0; i < 4; ++i)
                    for (int ii = 0; ii < 4; ++ii)
                        findWords(new Coord(i, ii), miniDict, Coord.getHS(i, ii), board, solutions, "");

                return solutions.ToList();
            }
        }
    }
}
