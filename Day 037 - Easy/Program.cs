using System;
using System.Collections.Generic;
using Loyc;
using Loyc.Collections;

namespace _100daysCoding
{
    class Program_Day37
    {
        public static SparseAList<int> facebookList;

        static void Main(string[] args)
        {
            Console.WriteLine("Input elements of a list in a row: ");
            var s = Console.ReadLine().Split(' ');
            var arr = s.Select(f => Convert.ToInt32(f)).ToArray();
            
            // var arr = new int[] { 0, 0, 0, 0, 0, 2, 4, 7, 10 };

            facebookList = init(arr, arr.Length);

            // Gets 2 from test array
            Console.WriteLine($"{get(5)}");

            // Sets 2 to 100
            set(5, 100);
            
            // Gets 100 from test array
            Console.WriteLine($"{get(5)}");


        }

        public static SparseAList<int> init (int[] arr, int size)
        {
            var result = new SparseAList<int>();
            result.AddRange(arr);
            return result;
        }

        public static void set (int index, int value)
        {
            facebookList.TrySet(index, value);
        }

        public static int get (int index)
        {
            List<int> appender = new List<int>();

            var res = getMM(index);
            if (res.HasValue)
            {
                appender.Add(res.Value);    
            }

            return appender[0];
        }

        public static Loyc.Maybe<int> getMM (int index)
        {
            return facebookList.TryGet(index);
        }

    }
}
