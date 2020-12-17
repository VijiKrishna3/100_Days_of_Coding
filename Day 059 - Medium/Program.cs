using System;
using System.Collections.Generic;
using System.Text;

namespace _100daysCoding
{
    class Program_Day59
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input all IP address numbers: ");
            string numbersIP = Console.ReadLine();

            List<string> result = solver(numbersIP);
            foreach (var str in result)
                Console.WriteLine(str);
        }

        static List<string> solver(string nums)
        {
            List<string> solved = new List<string>();
            StringBuilder ip = new StringBuilder();

            solveRecursive(solved, ip, 0, 0, nums);

            return solved;
        }

        static void solveRecursive(List<string> result, StringBuilder ipBuilder, int idx, int start, string ipString)
        {
            if (idx == 4)
            {
                if (start == ipString.Length)
                {
                    --ipBuilder.Length;
                    result.Add(ipBuilder.ToString());
                }
                return;
            }

            int num = 0;
            for (int i = start; i < Math.Min(ipString.Length, start + 3); i++)
            {
                if (i > start && num == 0) { return; }

                num *= 10;
                num += (ipString[i] - '0');

                if (num > 255) { return; }

                int len = ipBuilder.Length;
                ipBuilder.Append(num).Append(".");
                solveRecursive(result, ipBuilder, idx + 1, i + 1, ipString);
                ipBuilder.Length = len;
            }
        }
    }
}
