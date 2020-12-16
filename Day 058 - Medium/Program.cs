using System;

namespace _100daysCoding
{
    class Program_Day58
    {
        static void Main(string[] args)
        {
            Console.Write("Enter k number of linked lists: ");
            int k = Convert.ToInt32(Console.ReadLine());
            Node[] arr = new Node[k];

            for (int i = 0; i < k; ++i)
            {
                Console.Write($"\nHow many elements will there be in list {i + 1}: ");
                int x = Convert.ToInt32(Console.ReadLine());

                Console.Write($"Input all elements of list {i + 1}: ");
                var ins = Console.ReadLine().Split(' ');
                arr[i] = new Node(Convert.ToInt32(ins[0]));

                var tempVarNode = arr[i];
                for (int a = 1; a < ins.Length; ++a)
                {
                    tempVarNode.next = new Node(Convert.ToInt32(ins[a]));
                    tempVarNode = tempVarNode.next;
                }
            }

            Node flattenedList = flattenKList(arr, k - 1);
            Console.WriteLine("\nFlattened list: ");

            while (flattenedList != null)
            {
                Console.Write($"{flattenedList.val} ");
                flattenedList = flattenedList.next;
            }
                

        }

        static Node flattenKList(Node[] arr, int k)
        {
            while (k != 0)
            {
                int x = 0, y = k;
                while (x < y)
                {
                    arr[x] = mergeTwo(arr[x], arr[y]);
                    x++;
                    y--;

                    if (x >= y)
                        k = y;
                }
            }

            return arr[0];
        }

        static Node mergeTwo(Node node1, Node node2)
        {
            Node result;

            if (node1 == null) return node2;
            if (node2 == null) return node1;

            if (node1.val <= node2.val)
            {
                result = node1;
                result.next = mergeTwo(node1.next, node2);
            }
            else
            {
                result = node2;
                result.next = mergeTwo(node1, node2.next);
            }

            return result;
        }

        public class Node
        {
            public int val;
            public Node next;
            public Node (int value)
            {
                this.val = value;
            }
        }
    }
}
