using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _100daysCoding
{
    class Program_Day25
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input all elements in a sequence: ");
            var split = Console.ReadLine().Split(' ');
            var intArr = (from entry in split select Convert.ToInt32(entry)).ToArray();

            Solution1(intArr);
            Solution2(intArr);

            Console.ReadLine();
        }

        static void Solution1(int[] intArr)
        {
            var dictInt = intArr.GroupBy(x => x).ToDictionary(x => x.Key, o => o.Count());

            var duplicateResult = (from entry in dictInt where entry.Value == 2 select entry).ToList();
            try
            {
                Console.WriteLine($"Duplicate: {duplicateResult[0].Key}");
            }
            catch { }
        }

        static void Solution2(int[] intArr)
        {
            List<int> exist = new List<int>();
            for (int i = 0; i < intArr.Length; ++i)
            {
                if (exist.Contains(intArr[i]))
                {
                    Console.WriteLine($"Duplicate: {intArr[i]}");
                    break;
                }
                else
                {
                    exist.Add(intArr[i]);
                }
            }
        }
    }
}
