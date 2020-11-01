using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _100daysCoding
{
    class Program_Day8
    {
        static void Main(string[] args)
        {
            // Initializing the some thoughtup 3point example

            // Intialize the graph object with the number of points as a parameter, and add all its connections
            Graph graph = new Graph(3);
            graph.AddPoint('A', 'B', false);
            graph.AddPoint('B', 'A', false);
            graph.AddPoint('B', 'C', false);

            Console.Write("Displaying the initialized graph:");
            graph.DisplayGraph(3, false);

            graph.ReverseGraph(3);

            Console.Write("\n\nDisplaying the reversed graph:");
            graph.DisplayGraph(3, true);

            Console.ReadLine();
        }
    }

    public class Graph
    {
        public List<char>[] graph;
        public List<char>[] reverse;

        public Graph(int numberOfPoints)
        {
            this.graph = new List<char>[numberOfPoints];
            this.reverse = new List<char>[numberOfPoints];
            
            for (int i = 0; i < numberOfPoints; ++i)
            {
                graph[i] = new List<char>();
                reverse[i] = new List<char>();
            }
        }

        public void AddPoint(char startPoint, char endPoint, bool reversed)
        {
            if (reversed)
            {
                reverse[(int)startPoint - 65].Add(endPoint);
            }
            else
            {
                graph[(int)startPoint - 65].Add(endPoint);
            }
        }

        public void DisplayGraph(int numberOfPoints, bool reversed)
        {
            if (reversed)
            {
                for (int i = numberOfPoints - 1; i > -1; --i)
                {
                    Console.Write($"\n{(char)(i + 65)} --> ");

                    for (int j = 0; j < reverse[i].Count; ++j)
                    {
                        Console.Write($"{reverse[i][j]}, ");
                    }
                }
            }
            else
            {
                for (int i = 0; i < numberOfPoints; ++i)
                {
                    Console.Write($"\n{(char)(i + 65)} --> ");

                    for (int j = 0; j < graph[i].Count; ++j)
                    {
                        Console.Write($"{graph[i][j]}, ");
                    }
                }
            }
        }

        public void ReverseGraph(int numberOfPoints)
        {
            for (int i = 0; i < numberOfPoints; ++i)
            {
                for (int j = 0; j < graph[i].Count; ++j)
                {
                    AddPoint(graph[i][j], (char)(i + 65), true);
                }
            }
        }
    }
}
