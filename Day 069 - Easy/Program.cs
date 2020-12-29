using System;
using System.Collections.Generic;
using System.Linq;

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

            List<int> startPoints = (from entry in intervalPairs orderby entry.start ascending select entry.start).ToList();
            List<int> endPoints = (from entry in intervalPairs orderby entry.end ascending select entry.end).ToList();

            int start = 0, end = 0;
            int maxRooms = 0, currentRooms = 0;

            while (start < intervalPairs.Count && end < intervalPairs.Count)
            {
                if (start >= intervalPairs.Count) break;
                if (startPoints[start] < endPoints[end])
                {
                    ++currentRooms;
                    ++start;
                }
                else
                {
                    --currentRooms;
                    ++end;
                }

                maxRooms = (currentRooms < maxRooms) ? maxRooms : currentRooms;
            }

            Console.WriteLine($"\nTotal number of rooms that will be needed: {maxRooms}.");
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
