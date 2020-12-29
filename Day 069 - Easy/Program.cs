using System;
using System.Collections.Generic;

namespace _100daysCoding
{
    class Program_Day69
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input format: 0 3 2 6 will be automatically paired as [0,3], [2,6]");
            Console.Write("Input all intervals: ");
            var inputs = Console.ReadLine().Split(' ');

            List<IntervalPair> intervalPairs = new List<IntervalPair>();

            for (int i = 0; i < inputs.Length; i += 2)
                intervalPairs.Add(new IntervalPair(Convert.ToInt32(inputs[i]), Convert.ToInt32(inputs[i + 1])));
            intervalPairs.Sort((a, b) => a.start - b.start);

            int roomsNeeded = 1;
            for (int i = 1; i < intervalPairs.Count; ++i)
                if (intervalPairs[i - 1].end > intervalPairs[i].start)
                    ++roomsNeeded;

            Console.WriteLine($"\nTotal number of rooms that will be needed: {roomsNeeded}.");
        }

        class IntervalPair
        {
            public int start;
            public int end;

            public IntervalPair(int startingPoint, int endingPoint)
            {
                start = startingPoint;
                end = endingPoint;
            }
        }
    }
}
