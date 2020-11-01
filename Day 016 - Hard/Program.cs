using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _100daysCoding
{
    class Program_Day16
    {
        static void Main(string[] args)
        {
			Console.Write("Input string W: ");
			string w = Console.ReadLine();

			Console.Write("Input string S: ");
			string s = Console.ReadLine();

			Console.Write("\n");

			List<int> indexes = findAnagramIndexes(s, w);
			foreach (int ind in indexes)
				Console.Write(ind + " ");

			Console.ReadLine();
		}

		public static bool checkAnagram(int[] sAlphabetsCount, int[] wAlphabetsCount )
		{
			bool isAnagram = true;

			for (int i = 0; i < 26; i++)
			{
				if (sAlphabetsCount[i] != wAlphabetsCount[i])
					isAnagram = false;
			}

			return isAnagram;
		}

		public static List<int> findAnagramIndexes(String s, String w)
		{

			List<int> anagramIndexes = new List<int>();

			int[] sAlphabetsCount = new int[26];
			int[] wAlphabetsCount = new int[26];
			int window = w.Length;

			if (s.Length < window)
				return null;

			for (int i = 0; i < window; ++i)
			{
				++(sAlphabetsCount[s[i] - 'a']);
				++(wAlphabetsCount[w[i] - 'a']);
			}

			bool isAnagram = true;

			for (int i = window; i < s.Length; ++i)
			{
				isAnagram = checkAnagram(sAlphabetsCount, wAlphabetsCount);

				if (isAnagram)
					anagramIndexes.Add(i - window);

				--(sAlphabetsCount[s[(i - window)] - 'a']);
				++(sAlphabetsCount[s[i] - 'a']);
			}

			isAnagram = checkAnagram(sAlphabetsCount, wAlphabetsCount);

			if (isAnagram)
				anagramIndexes.Add(s.Length - window);

			return anagramIndexes;
		}
	}
}
