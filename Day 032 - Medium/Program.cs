using System;
using System.Collections.Generic;

namespace _100daysCoding
{
    class Program_Day32
    {
        public class Node
        {
            public int data;
            public Node left, right;

            public Node() { }

            public Node(int data)
            {
                this.data = data;
                left = right = null;
            }
        }

        static void Main(string[] args)
        {
            /* Testing out tree:
                 6  
               /   \  
             5      7  
            /      / \  
           4      6   8
                 / \     
                5   7                          */

            Node tree = new Node(6);
            tree.left = new Node(5);
            tree.right = new Node(7);
            tree.left.left = new Node(4);
            tree.right.left = new Node(6);
            tree.right.right = new Node(8);
            tree.right.left.right = new Node(7);
            tree.right.left.left = new Node(5);

            if (binaryTreeValid(tree))
            {
                Console.WriteLine("Tree is a valid binary tree.");
            }
            else
            {
                Console.WriteLine("The tree isn't a valid binary tree.");
            }
        }

        static bool binaryTreeValid(Node root)
        {
            bool leftSide = true;
            bool rightSide = true;

            if (root == null)
                return true;

            if (root.left != null)
            {
                leftSide = (leftSide && (root.left.data <= root.data));
                if (leftSide)
                    leftSide = (leftSide && binaryTreeValid(root.left));
            }


            if (root.right != null)
            {
                rightSide = (rightSide && (root.right.data >= root.data));
                if (rightSide)
                    rightSide = (rightSide && binaryTreeValid(root.right));
            }

            if (leftSide && rightSide)
                return true;
            else
                return false;
        }
    }
}
