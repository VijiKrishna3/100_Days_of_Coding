using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _100daysCoding
{
    class Program_Day6
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number of intervals you want to enter: ");
            int numberOfIntervals = Convert.ToInt32(Console.ReadLine());

            Interval[] intervals = new Interval[numberOfIntervals];
            for(int i = 0; i < numberOfIntervals; ++i)
            {
                intervals[i] = new Interval();

                Console.WriteLine("Input the start point of the {0}. interval: ", i + 1);
                intervals[i].start_point = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Input the end point of the {0}. interval: ", i + 1);
                intervals[i].end_point = Convert.ToInt32(Console.ReadLine());

                if (intervals[i].start_point > intervals[i].end_point)
                {
                    (intervals[i].start_point, intervals[i].end_point) = (intervals[i].end_point, intervals[i].start_point);
                }
            }

            bool toExit;


        }

        static Interval Overlapping(Interval[] arr)
        {
            for (int j = 0; j < arr.Length; ++j)
            {
                for (int k = j + 1; k < arr.Length; ++k)
                {
                    // Second array completely envelops the first array
                    if (arr[j].start_point > arr[k].start_point && arr[j].end_point < arr[k].end_point)
                    {
                        return new Interval(arr[k]);
                    }


                }
            }

            return new Interval();
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
