using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace _100daysCoding
{
    class Program_Day1
    {
        static void Main(string[] args)
        {
            Console.Write("How many numbers will there be: ");
            int arraySize = Convert.ToInt32(Console.ReadLine());

            int[] array = new int[arraySize];

            for (int i = 0; i < arraySize; ++i)
            {
                array[i] = Convert.ToInt32(Console.ReadLine());
            }

            Console.Write("\nDefine 'k' as an integer: ");
            int k = Convert.ToInt32(Console.ReadLine());

            executeCode(k, array);
        }

        // Testing method for Stopwatch
        static void executeCode(int k, int[] array)
        {
            Stopwatch stopwatch = new Stopwatch();
            
            stopwatch.Start();
            CheckMatch(k, array);
            stopwatch.Stop();

            Console.WriteLine("Time elapsed V1: {0}", stopwatch.Elapsed);
            stopwatch.Reset();

            stopwatch.Start();
            CheckMatchV2(k, array);
            stopwatch.Stop();

            Console.WriteLine("Time elapsed V2: {0}", stopwatch.Elapsed);
            stopwatch.Reset();

            stopwatch.Start();
            CheckMatchV3(k, array);
            stopwatch.Stop();

            Console.WriteLine("Time elapsed V3: {0}", stopwatch.Elapsed);


            Console.WriteLine($"\nResult: {CheckMatch(k, array)}");
        }

        // This is the first version of the algorithm in use
        static bool CheckMatch(int k, int[] array)
        {
            for (int i = 0; i < array.Length; ++i)
                for (int j = i; j < array.Length; ++j)
                    if (array[i] + array[j] == k)
                        return true;

            return false;
        }

        // This is the 2nd version
        static bool CheckMatchV2(int k, int[] array)
        {
            Array.Sort(array);
            for (int i = 0; i < array.Length; ++i)
                for (int j = i; j < array.Length; ++j)
                    if (array[i] + array[j] == k)
                        return true;

            return false;
        }

        // This is the 3rd version
        static bool CheckMatchV3(int k, int[] array)
        {
            Array.Sort(array);

            int fstLoop = array.Length / 2;
            int sndLoop = fstLoop - (array.Length % 2);

            for (int i = 0; i < fstLoop; ++i)
                for (int j = array.Length - 1; j > sndLoop; --j)
                    if (array[i] + array[j] == k)
                        return true;

            return false;
        }
    }
}

// ✨✨✨
// CTRL K C - comment block
// CTRL K U - uncomment block