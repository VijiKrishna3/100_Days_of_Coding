using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _100daysCoding
{
    class Program_Day19
    {
        public class Node
        {
            public int data;
            public Node left, right;

            public Node()
            {
            }

            public Node(int item)
            {
                data = item;
                left = right = null;
            }
        }

        public static int[] minMaxLevelSum(Node root)
        {
            if (root == null)
                return new int[] { 0, 0 };

            int result = root.data;
            int result2 = root.data;

            Queue<Node> q = new Queue<Node>();
            q.Enqueue(root);
            while (!(q.Count == 0))
            {
                int count = q.Count();

                int sum = 0;
                while (count-- > 0)
                {
                    Node temp = q.Dequeue();

                    sum = sum + temp.data;

                    if (temp.left != null)
                        q.Enqueue(temp.left);
                    if (temp.right != null)
                        q.Enqueue(temp.right);

                }

                result = Math.Max(sum, result);
                result2 = Math.Min(sum, result2);
            }
            return new int[] { result, result2 };
        }

        public static void Main(string[] args)
        {
            /* Testing out tree:
                 6  
               /   \  
             2      3  
            /      / \  
           4      5   6
                 / \     
                7   7                          */
            Node tree = new Node();

            tree.data = 6;
            tree.left = new Node(2);
            tree.right = new Node(3);
            tree.left.left = new Node(4);
            tree.right.left = new Node(5);
            tree.right.right = new Node(6);
            tree.right.left.right = new Node(7);
            tree.right.left.left = new Node(7);

            var res = minMaxLevelSum(tree);

            Console.WriteLine("Maximum level sum is: " + res[0]);
            Console.WriteLine("Minimum level sum is: " + res[1]);
            Console.ReadLine();
        }
    }
}
