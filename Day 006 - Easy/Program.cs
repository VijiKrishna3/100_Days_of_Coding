using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace _100daysCoding
{
    class Program_Day6
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the number of intervals you want to enter: ");
            int numberOfIntervals = Convert.ToInt32(Console.ReadLine());

            // Console Inputting the arrays
            Interval[] intervals = new Interval[numberOfIntervals];
            for(int i = 0; i < numberOfIntervals; ++i)
            {
                intervals[i] = new Interval();

                Console.Write("\nInput the start point of the {0}. interval: ", i + 1);
                intervals[i].start_point = Convert.ToInt32(Console.ReadLine());

                Console.Write("Input the end point of the {0}. interval: ", i + 1);
                intervals[i].end_point = Convert.ToInt32(Console.ReadLine());

                if (intervals[i].start_point > intervals[i].end_point)
                {
                    (intervals[i].start_point, intervals[i].end_point) = (intervals[i].end_point, intervals[i].start_point);
                }
            }

            // Sorting the intervals based on the starting points
            for (int i = 0; i < numberOfIntervals -1; ++i)
            {
                if (intervals[i].start_point > intervals[i + 1].start_point)
                {
                    (intervals[i].start_point, intervals[i].end_point) = (intervals[i + 1].start_point, intervals[i + 1].end_point);
                }
            }

            // Deciding how much you need to remove
            int removesToWork = 0;
            int outer_i = 0;

            for (int i = 1; i < numberOfIntervals; ++i)
            {
                if (intervals[outer_i].end_point > intervals[i].start_point)
                    ++removesToWork;
                else
                    outer_i = i;
            }

            Console.WriteLine($"\nRemoves needed: {removesToWork}");
            Console.ReadLine();
        }
    }

    class Interval
    {
        public int start_point { get; set; }
        public int end_point { get; set; }

        public Interval()
        {
            start_point = 0;
            end_point = 0;
        }

        public Interval(int a, int b)
        {
            this.start_point = a;
            this.end_point = b;
        }

        public Interval(Interval interval)
        {
            this.start_point = interval.start_point;
            this.end_point = interval.end_point;
        }
    }
}
