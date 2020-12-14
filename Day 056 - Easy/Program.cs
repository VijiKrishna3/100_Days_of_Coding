using System;
using System.Collections.Generic;
using System.Linq;

namespace _100daysCoding
{
    class Program_Day56
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

            var tempStack = new Stack<IntervalPair>();
            tempStack.Push(intervalPairs[0]);

            for (int i = 1; i < intervalPairs.Count; ++i)
            {
                if (tempStack.Peek().end < intervalPairs[i].start)
                    tempStack.Push(intervalPairs[i]);
                else if (tempStack.Peek().end < intervalPairs[i].end)
                {
                    var x = new IntervalPair(tempStack.Peek().start, intervalPairs[i].end);
                    tempStack.Pop();
                    tempStack.Push(x);
                }
            }

            intervalPairs.Clear();
            intervalPairs.AddRange(tempStack);
            intervalPairs.Reverse();

            foreach (var interval in intervalPairs)
                Console.WriteLine($"[{interval.start}, {interval.end}]");
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
