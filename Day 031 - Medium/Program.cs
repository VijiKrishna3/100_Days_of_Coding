using System;

namespace _100daysCoding
{
    class Program_Day31
    {
        public class Node
        {
            public int data;
            public Node sequence_next;
            public Node sequence_random;

            public Node(int data)
            {
                this.data = data;
            }
        }

        static void Main(string[] args)
        {
            var nodes = new Node[5];
            Random rnd = new Random();
            
            for (int i = 1; i <= 5; ++i)
                nodes[i - 1] = new Node(i);

            for (int i = 0; i < 4; ++i)
                nodes[i].sequence_next = nodes[i + 1];
                
            for (int i = 0; i < 5; ++i)
                nodes[i].sequence_random = nodes[rnd.Next(0, 4)];


            nodePrintLinks(nodes[0]);
        }

        static void nodePrintLinks(Node main)
        {
            Console.WriteLine("Node value : Random pointer node value");

            var temporaryNode = main;
            while (temporaryNode != null)
            {
                Console.WriteLine($"{temporaryNode.data} ({temporaryNode.sequence_random.data})");
                temporaryNode = temporaryNode.sequence_next;
            }
        }
    }
}
