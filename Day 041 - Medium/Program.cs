using System;
using System.Collections.Generic;

namespace Day_41___Medium
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.Write("Input number of points: ");
            // int n = Convert.ToInt32(Console.ReadLine());
            int n = 5;

            LinkedList<int>[] adjacencyList = new LinkedList<int>[n];

            for (int i = 0; i < n; ++i) adjacencyList[i] = new LinkedList<int>();

            /*List should look like this
             * (MINIMALLY CONNECTED)
             * 
             * 0  ----- 1 ------ 3
             * |        
             * |        
             * 2 ------ 4                */

            addPoint(adjacencyList, 0, 1);
            addPoint(adjacencyList, 0, 2);
            addPoint(adjacencyList, 1, 3);
            addPoint(adjacencyList, 2, 4);

            // If you want to make the graph not minimally connected - add a bridge from 1 to 4
            addPoint(adjacencyList, 1, 4);


            int numberOfEdges = 0;
            foreach (var c in adjacencyList)
            {
                numberOfEdges += c.Count;
            }

            numberOfEdges = numberOfEdges / 2;

            if (numberOfEdges == n - 1)
                Console.WriteLine("Graph is minimally connected.");
            else
                Console.WriteLine("Graph isn't minimally connected.");
        }

        static void addPoint(LinkedList<int>[] a, int sP, int eP)
        {
            a[sP].AddLast(eP);
            a[eP].AddLast(sP);
        }
    }
}
