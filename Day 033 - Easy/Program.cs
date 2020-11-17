using System;
using System.Collections.Generic;

namespace _100daysCoding
{
    class Program_Day33
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

            Console.Write("Input k: ");
            int k = Convert.ToInt32(Console.ReadLine());
            bool broken = false;

            convertNodeToList(tree);

            foreach(var item in nodeList)
            {
                if (nodeList.Contains(k - item))
                {
                    Console.WriteLine($"Nodes: {item} {k - item}");
                    broken = true;
                    break;
                }
            }

            if (!broken)
                Console.WriteLine($"No such nodes.");

        }

        public static List<int> nodeList = new List<int>();

        static void convertNodeToList(Node root)
        {
            if (root == null)
                return;

            if (root.left != null)
                convertNodeToList(root.left);

            if (root.right != null)
                convertNodeToList(root.right);

            nodeList.Add(root.data);
        }
    }
}
