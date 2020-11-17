using System;
using System.Collections.Generic;

namespace _100daysCoding
{
    class Program_Day29
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the number of bits: ");
            int n = Convert.ToInt32(Console.ReadLine());

            var res = sortList(gray_code(n), n);
            foreach (var x in res)
                Console.WriteLine(x);
        }

        static List<int> gray_code(int n)
        {
            List<int> result = new List<int>();

            if (n == 0)
            {
                return result;
            }
            else if (n == 1)
            {
                result.Add(0);
                result.Add(1);
                return result;
            }

            var previous = gray_code(n - 1);
            result.AddRange(previous);

            for (int i = previous.Count - 1; i > -1; --i)
            {
                result.Add((1 << (n - 1)) | previous[i]);
            }

            return result;
        }

        static List<string> sortList(List<int> k, int n)
        {
            List<string> sorted = new List<string>();

            foreach(var x in k)
            {
                if ((Convert.ToString(x, 2).Length == n))
                    sorted.Add(Convert.ToString(x, 2));
                else
                {
                    int kx = Convert.ToString(x, 2).Length;
                    string s = "";
                    for (int y = 0; y < (n - kx); ++y)
                        s += "0";

                    s += Convert.ToString(x, 2);
                    sorted.Add(s);
                }
            }

            return sorted;
        }
    }
}
