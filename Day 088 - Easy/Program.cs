using System;
using System.Linq;

namespace _100daysCoding
{
    class Program_Day88
    {
        static void Main(string[] args)
        {
            Console.Write("Input column number: ");
            int col = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"Integer value of column: {getCol(col)}");
        }

        const string alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        static string getCol(int c)
        {
            string col = "";
            while (c > 0)
            {
                if (c % 26 == 0)
                {
                    col += "Z";
                    c /= 26; c--;
                }
                else
                {
                    col += alpha[c % 26 - 1];
                    c /= 26;
                }
            }

            return new string(col.Reverse().ToArray());            
        }
    }
}
