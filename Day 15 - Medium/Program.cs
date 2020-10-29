using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _100daysCoding
{
    class Program_Day15
    {
        static void Main(string[] args)
        {
            Console.Write("Input the number of strings: ");
            int n = Convert.ToInt32(Console.ReadLine());
            
            string[] arr = new string[n];
            for (int i = 0; i < n; ++i)
            {
                Console.Write($"str {i + 1}: ");
                arr[i] = Console.ReadLine();
            }

            Console.WriteLine("\nOutputs: "); 

            Trie trie = new Trie();

            string[] prefix_arr = trie.FindPrefix(arr);
            foreach (string str in prefix_arr)
                Console.WriteLine($"{str}");

            Console.ReadLine();
        }
    }
    public class TrieNode
    {
        public TrieNode[] child = new TrieNode[26];
        public int freq;
        public TrieNode()
        {
            freq = 1;
            for (int i = 0; i < 26; ++i)
                child[i] = null;
        }
    }

    public class Trie
    {
        static TrieNode root;
        public string[] FindPrefix(String[] words)
        {
            root = new TrieNode();

            root.freq = 0;
            for (int i = 0; i < words.Length; ++i)
                Insert(words[i]);

            string[] prefix = new string[words.Length];
            for (int i = 0; i < prefix.Length; ++i)
                prefix[i] = MakePrefix(words[i]);

            return prefix;
        }

        void Insert(String word)
        {
            int len = word.Length;
            TrieNode trieNodeCrawl = root;

            for (int i = 0; i < len; ++i)
            {
                char c = word[i];
                if (trieNodeCrawl.child[c - 'a'] == null)
                    trieNodeCrawl.child[c - 'a'] = new TrieNode();

                else
                    ++(trieNodeCrawl.child[c - 'a'].freq);

                trieNodeCrawl = trieNodeCrawl.child[c - 'a'];
            }
        }

        string MakePrefix(string word)
        {
            TrieNode temp = root;
            string prefix = "";

            for (int i = 0; i < word.Length; ++i)
            {
                char c = word[i];
                prefix += c;

                if (temp.child[c - 'a'].freq == 1)
                    return prefix;

                temp = temp.child[c - 'a'];
            }

            return prefix;
        }
    }
}