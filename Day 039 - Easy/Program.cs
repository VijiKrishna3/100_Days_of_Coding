using System;
using System.Collections.Generic;

namespace _100daysCoding
{
    class Program_Day39
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

            Console.WriteLine("The minimum path is " + minPath(tree));
        }

        static int minPath(Node root)
        {
            if (root == null)
                return 0;

            int sum = root.data;
            int leftSide = Int32.MaxValue;
            int rightSide = Int32.MaxValue;

            if (root.left == null && root.right == null)
                return sum;

            if (root.left != null)
                leftSide = minPath(root.left);

            if (root.right != null)
                rightSide = minPath(root.right);

            sum += Math.Min(leftSide, rightSide);

            return sum;
        }
    }
}
