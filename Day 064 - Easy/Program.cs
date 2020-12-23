using System;
using System.Collections.Generic;

namespace _100daysCoding
{
    class Program_Day64
    {
        public class Node
        {
            public int value;
            public Node next = null;

            public Node (int val)
            {
                value = val;
            }
        }
        static void Main(string[] args)
        {
            // Lists here will be hard-coded for the time being.
            // For example, given A = 3 -> 7 -> 8 -> 10 and B = 99 -> 1 -> 8 -> 10, return the node with value 8.

            Node list1 = new Node(3);
            list1.next = new Node(7);
            list1.next.next = new Node(8);
            list1.next.next.next = new Node(10);

            Node list2 = new Node(99);
            list2.next = new Node(1);
            list2.next.next = new Node(8);
            list2.next.next.next = new Node(10);

            var result = findIntercept(list1, list2);
            if (result != null)
                Console.WriteLine($"Lists intercept at {result.value}.");
            else
                Console.WriteLine($"Lists do not intercept.");
        }

        static Node findIntercept(Node list1, Node list2)
        {

            Node it1 = list1;
            Node it2 = list2;

            if (it1 == null || it2 == null) return null;

            while (it1.value != it2.value)
            {
                it1 = it1.next;
                it2 = it2.next;

                if (it1 == it2) return it1;

                if (it1 == null) it1 = list2;
                if (it2 == null) it2 = list1;
            }

            return it1;
        }
    }
}
