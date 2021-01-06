using System;

namespace _100daysCoding
{
    class Program_Day75
    {
        public class Node
        {
            public int data;
            public Node left, right;

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
                4   7                          */

            Node tree = new Node(6);
            tree.left = new Node(2);
            tree.right = new Node(3);
            tree.left.left = new Node(4);
            tree.right.left = new Node(5);
            tree.right.right = new Node(6);
            tree.right.left.right = new Node(7);
            tree.right.left.left = new Node(4);

            // should be 27 -> 4 + 2 + 6 + 3 + 5 + 7
            Console.WriteLine($"The maximum sum of the path between two nodes is {maxSumTwoNodes(tree)}.");
        }

        static int maxSumTwoNodes(Node node)
        {
            int[] res = new int[1];
            res[0] = int.MinValue;
            wrapperFunc(node, res);
            return res[0];
        }

        static int wrapperFunc(Node node, int[] res)
        {
            if (node == null) return 0;

            int ls = wrapperFunc(node.left, res);
            int rs = wrapperFunc(node.right, res);

            int thos = Math.Max(node.data, Math.Max(node.data + ls, node.data + rs));
            res[0] = Math.Max(res[0], Math.Max(thos, ls + node.data + rs));

            return thos;
        }
    }
}
