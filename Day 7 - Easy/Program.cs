using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _100daysCoding
{
    class Program_Day7
    {
        static void Main(string[] args)
        {
            Console.Write("Enter number of points: ");
            int numberOfPoints = Convert.ToInt32(Console.ReadLine());

            Point[] points = new Point[numberOfPoints];

            for (int i = 0; i < numberOfPoints; ++i)
            {
                points[i] = new Point();

                Console.Write("\nInput the p value of {0}. point: ", i + 1);
                points[i].p_val = Convert.ToInt32(Console.ReadLine());

                Console.Write("Input the q value of {0}. point: ", i + 1);
                points[i].q_val = Convert.ToInt32(Console.ReadLine());
            }

            int intersections = IntersectCheck(numberOfPoints, points);

            Console.WriteLine($"\nNumber of intersections: {intersections}.");
            Console.ReadLine();
        }

        public static int IntersectCheck(int numberOfPoints, Point[] arr)
        {
            int intersect = 0;

            /* How the checking works:
             * 1. Statement checks if both numbers are positive
             * 2. Statement checks if first number is positive, and second is negative
             * 3. Statement checks if first number is negative, and second is positive
             * 4. Statement deduces that both numbers are simply negative
             * 
             * It calculates the difference between the first and second pair of dots.
             * And compares them at the end. 
             * 
             * If the differences are equal, the lines are parallel,
             * i.e. if they're not, they intersect.
             */

            for (int i = 0; i < numberOfPoints; ++i)
            {
                int p1 = arr[i].p_val;
                int q1 = arr[i].q_val;
                for (int j = i + 1; j < numberOfPoints; ++j)
                {
                    int firstDifference, secondDifference;
                    int p2 = arr[j].p_val;
                    int q2 = arr[j].q_val;

                    if (p1 >= 0 && q1 >= 0)
                    {
                        firstDifference = q1 - p1;
                    }
                    else if (p1 >= 0 && q1 <= 0)
                    {
                        firstDifference = q1 - p1;
                    }
                    else if (p1 <= 0 && q1 >= 0)
                    {

                        firstDifference = p1 - q1;
                    }
                    else
                    {
                        firstDifference = -p1 + q2;
                    }

                    if (p2 >= 0 && q2 >= 0)
                    {
                        secondDifference = q2 - p2;
                    }
                    else if (p2 >= 0 && q2 <= 0)
                    {
                        secondDifference = q2 - p2;
                    }
                    else if (p2 <= 0 && q2 >= 0)
                    {
                        secondDifference = p2 - q2;
                    }
                    else
                    {
                        secondDifference = -p2 + q2;
                    }

                    if (firstDifference != secondDifference)
                    {
                        ++intersect;
                    }
                }
            }

            return intersect;
        }
    }

    class Point
    {
        public int p_val { get; set; }
        public int q_val { get; set; }

        public Point()
        {
            p_val = 0;
            q_val = 0;
        }
    }
}
