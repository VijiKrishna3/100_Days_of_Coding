using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Combinatorics.Collections;

namespace _100daysCoding
{
    class Program_Day23
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input a string: ");
            string s = Console.ReadLine();
            var sC = (from entry in s select entry).ToList();

            bool boolSol = false;
            var p = new Permutations<char>(sC, GenerateOption.WithoutRepetition);
            string temp = "", ts = "";

            foreach (var v in p)
            {
                foreach (var k in v)
                {
                    temp += k;
                }

                ts = new string(temp.ToCharArray().Reverse().ToArray());

                if (temp == ts)
                {
                    boolSol = true;
                    break;
                }

                temp = "";
            }
                
            Console.WriteLine($">< {boolSol} ><");
            Console.ReadLine();
        }
    }
}
