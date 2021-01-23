using System;

namespace _100daysCoding
{
    class Program_Day90
    {
        class LinkedList
        {
            public Node head = null;
            public class Node
            {
                public int data;
                public Node next = null;
                public Node(int val) { data = val; }
            }

            public void push(int data)
            {
                Node node = new Node(data);
                node.next = head;
                head = node;
                
            }

            public void printList()
            {
                Node bck = head;
                while (bck != null)
                {
                    Console.Write($"{bck.data}");
                    if (bck.next != null) Console.Write(" -> ");
                    bck = bck.next;
                }
                Console.WriteLine();
            }
               
            public Node sortFast(Node h)
            {
                if (h == null || h.next == null) return h;
                Node middleNode = getMiddleNode(h);
                Node afterMiddle = middleNode.next;

                middleNode.next = null;
                Node lNode = sortFast(h), rNode = sortFast(afterMiddle);
                
                return sortMerge(lNode, rNode);
            }

            private Node getMiddleNode(Node head)
            {
                if (head == null) return head;
                Node fptr = head.next, sptr = head;

                while (fptr != null)
                {
                    fptr = fptr.next;
                    if (fptr != null)
                    {
                        fptr = fptr.next;
                        sptr = sptr.next;
                    }
                }

                return sptr;
            }

            private Node sortMerge(Node a, Node b)
            {
                Node result = null;
                if (a == null) return b;
                if (b == null) return a;

                if (a.data <= b.data)
                {
                    result = a;
                    result.next = sortMerge(a.next, b);
                }
                else
                {
                    result = b;
                    result.next = sortMerge(a, b.next);
                }
                return result;
            }
        }

        static void Main(string[] args)
        {
            LinkedList list = new LinkedList();
            list.push(4);
            list.push(1);
            list.push(-3);
            list.push(99);

            Console.WriteLine("List right now is: ");
            list.printList();

            list.head = list.sortFast(list.head);

            Console.WriteLine("\nSorted list looks like: ");
            list.printList();
        }
    }
}
