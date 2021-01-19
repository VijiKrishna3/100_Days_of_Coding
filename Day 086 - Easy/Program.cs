using System;
using System.Linq;

namespace _100daysCoding
{
    class Program_Day86
    {
        static void Main(string[] args)
        {
            /* The elements are hard-coded for now */
            string[] arrs = { "a", "b", "c", "d" };
            int[] arri = { 11, 32, 3, 42 };

            int[] seq = { 2, 3, 0, 1 };

            Console.WriteLine($"The permuted sequence is: ");
            arrPermute(seq, arrs);
            arrPermute(seq, arri);

            foreach (var elem in arrs)
                Console.Write($"{elem} ");

            Console.WriteLine();

            foreach (var elem in arri)
                Console.Write($"{elem} ");
        }

        static void arrPermute<T>(int[] sq, T[] arr)
        {
            int[] seq = sq.ToArray();

            for (int i = 0; i < arr.Length; ++i)
            {
                int nidx = i;
                while (seq[nidx] >= 0)
                {
                    (arr[i], arr[nidx]) = (arr[nidx], arr[i]);
                    seq[nidx] -= arr.Length;
                    nidx = seq[nidx] + arr.Length;
                }
            }
        }
    }
}
/*
 * Given an array and a permutation, apply the permutation to the array. For example, given the array ["a", "b", "c"] and the permutation [2, 1, 0], return ["c", "b", "a"].
 * */