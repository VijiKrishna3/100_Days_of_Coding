using System;
using System.Collections.Generic;

namespace _100daysCoding
{
    class Program_Day45
    {
        public class Node
        {
            public int data;
            public Node left, right;

            public Node() { }

            public Node(int dat)
            {
                data = dat;
                left = right = null;
            }
        }

        static void Main(string[] args)
        {
            /* Testing out tree:
                 6  
               /   \  
             2      3  
            /      / \  
           4      5   6
                 / \     
                7   7                          */

            Node tree = new Node(6);
            tree.left = new Node(2);
            tree.right = new Node(3);
            tree.left.left = new Node(4);
            tree.right.left = new Node(5);
            tree.right.right = new Node(6);
            tree.right.left.right = new Node(7);
            tree.right.left.left = new Node(7);

            // Print should be - 6 2 3 4 5 6 7 7
            printTree(tree);
        }

        static void printTree(Node root)
        {
            if (root == null)
                return;

            Queue<Node> q = new Queue<Node>();
            q.Enqueue(root);

            
            while (true)
            {
                int nodeCount = q.Count;

                if (nodeCount == 0)
                    break;

                while (nodeCount != 0)
                {
                    Node node = q.Peek();
                    Console.Write($"{node.data} ");
                    q.Dequeue();

                    if (node.left != null)
                        q.Enqueue(node.left);
                    if (node.right != null)
                        q.Enqueue(node.right);

                    --nodeCount;
                }
            }
        }
    }
}
