using System;
using System.Collections.Generic;

namespace _100daysCoding
{
    class Program_Day96
    {
        static void Main(string[] args)
        {
            Console.Write("Insert string s: ");
            string s = Console.ReadLine();

            Console.WriteLine("Insert words in a single line (i.e. 'dog cat pet' = [dog, cat, pet]: ");
            string[] wrs = Console.ReadLine().Split(' ');

            List<int> ret = returnIndexes(s, wrs);

            Console.WriteLine("Index list looks like: ");
            foreach (int x in ret)
                Console.Write($"{x} ");
        }

        static List<int> returnIndexes(string s, string[] ws)
        {
            List<int> idx = new List<int>();
            if (s.Length == 0 || ws.Length == 0) return idx;

            int wordSize = ws[0].Length;
            int words = ws.Length;

            if (s.Length < wordSize * words) return idx;

            Dictionary<string, int> uniqueWords = initWords(ws);

            for (int i = 0; i < wordSize; ++i)
                findResult(s, i, uniqueWords, wordSize, words, idx);

            return idx;
        }

        static void findResult(string s, int pos, Dictionary<string, int> uniq, int wordLen, int words, List<int> idx)
        {
            int i = pos, j = pos, count = 0;
            string substr;
            bool included;

            while (j <= s.Length - wordLen)
            {
                included = false;
                substr = s.Substring(j, wordLen);

                if (count < words && uniq.ContainsKey(substr) && uniq[substr] > 0)
                {
                    included = true;
                    uniq[substr]--;
                    count++;
                    j += wordLen;
                
                    if (count == words) { idx.Add(i); included = false; }
                }

                if (!included)
                {
                    if (i < j)
                    {
                        substr = s.Substring(i, wordLen);
                        if (uniq.ContainsKey(substr))
                        {
                            uniq[substr]++;
                            count--;
                        }
                        i += wordLen;
                    }
                    else
                    {
                        i += wordLen;
                        j += wordLen;
                    }
                }
            }

            while (i <= s.Length - wordLen)
            {
                substr = s.Substring(i, wordLen);
                if (uniq.ContainsKey(substr)) uniq[substr]++;
                i += wordLen;
            }
        }

        static Dictionary<string, int> initWords(string[] ws)
        {
            Dictionary<string, int> uniq = new Dictionary<string, int>();
            
            foreach (string s in ws)
            {
                if (!uniq.ContainsKey(s)) uniq[s] = 0;
                uniq[s]++;
            }

            return uniq;
        }
    }
}
