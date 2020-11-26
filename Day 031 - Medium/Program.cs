using System;
using System.Collections.Generic;

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
                sequence_next = sequence_random = null;
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

            Node cloned = cloneNodeSequence(nodes[0]);
            nodePrintLinks(cloned);
        }

        static void nodePrintLinks(Node main)
        {
            Console.WriteLine("\nNode value : Random pointer node value");

            var temporaryNode = main;
            while (temporaryNode != null)
            {
                Console.WriteLine($"{temporaryNode.data} ({temporaryNode.sequence_random.data})");
                temporaryNode = temporaryNode.sequence_next;
            }
        }

        static Node cloneNodeSequence(Node head)
        {
            Node originalNode = head, clonedNode = null;

            Dictionary<Node, Node> nodeMap = new Dictionary<Node, Node>();

            while (originalNode != null)
            {
                clonedNode = new Node(originalNode.data);
                nodeMap[originalNode] = clonedNode;
                originalNode = originalNode.sequence_next;
            }

            originalNode = head;

            while (originalNode != null)
            {
                clonedNode = nodeMap[originalNode];
                try { clonedNode.sequence_next = nodeMap[originalNode.sequence_next]; } catch { }
                clonedNode.sequence_random = nodeMap[originalNode.sequence_random];
                originalNode = originalNode.sequence_next;
            }

            clonedNode = nodeMap[head];
            return clonedNode;
        }
    }
}
