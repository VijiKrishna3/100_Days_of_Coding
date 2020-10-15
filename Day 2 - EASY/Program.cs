using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _100daysCoding
{
    public class Program_Day2
    {
        public class Node
        {
            public int data;
            public Node left, right;

            public Node(int item)
            {
                data = item;
                left = right = null;
            }
        }

        public class Count
        {
            public int count = 0;
        }

        public class BinaryTree
        {
            public Node root;
            public Count ct = new Count();

            // This function increments count by number of single   
            // valued subtrees under root. It returns true if subtree   
            // under root is Singly, else false.  
            public virtual bool countSingleRec(Node node, Count c)
            {
                // Return false to indicate NULL  
                if (node == null)
                {
                    return true;
                }

                // Recursively count in left and right subtrees also  
                bool left = countSingleRec(node.left, c);
                bool right = countSingleRec(node.right, c);

                // If any of the subtrees is not singly, then this  
                // cannot be singly.  
                if (left == false || right == false)
                {
                    return false;
                }

                // If left subtree is singly and non-empty, but data  
                // doesn't match  
                if (node.left != null && node.data != node.left.data)
                {
                    return false;
                }

                // Same for right subtree  
                if (node.right != null && node.data != node.right.data)
                {
                    return false;
                }

                // If none of the above conditions is true, then  
                // tree rooted under root is single valued, increment  
                // count and return true.  
                c.count++;
                return true;
            }

            // This function mainly calls countSingleRec()  
            // after initializing count as 0  
            public virtual int countSingle()
            {
                return countSingle(root);
            }

            public virtual int countSingle(Node node)
            {
                // Recursive function to count  
                countSingleRec(node, ct);
                return ct.count;
            }

            public static void Main(string[] args)
            {
                /* Testing out tree:
                     0  
                   /   \  
                 1      0  
                       / \  
                      1   0
                     / \     
                    1   1                          */
                BinaryTree tree = new BinaryTree();

                tree.root = new Node(0);
                tree.root.left = new Node(1);
                tree.root.right = new Node(0);
                tree.root.right.left = new Node(1);
                tree.root.right.right = new Node(0);
                tree.root.right.left.right = new Node(1);
                tree.root.right.left.left = new Node(1);

                Console.WriteLine("The number of unival trees is : " + tree.countSingle());
                Console.ReadLine();
            }
        }
    }
}
