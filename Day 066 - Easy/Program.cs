using System;

namespace _100daysCoding
{
    class Program_Day66
    {
        public class DoublyLinkedList
        {
            Node head;
            public class Node
            {
                public int value;
                public Node prev, next;
                public Node(int val)
                {
                    value = val;
                }
            }

            public void appendNode(int newVal)
            {
                Node appender = new Node(newVal);
                if (head == null)
                {
                    appender.prev = null;
                    head = appender;
                    return;
                }

                Node last = head;
                while (last.next != null) last = last.next;
                last.next = appender;
                appender.prev = last;
            }

            public Node getLast()
            {
                Node tempNode = head;
                while (tempNode.next != null) tempNode = tempNode.next;
                return tempNode;
            }

            public bool isDLLPalindrome()
            {
                Node first = head, last = getLast();
                while (first != last)
                {
                    if (last == first.prev) return true;
                    if (first.value != last.value) return false;

                    if (first.next != null) first = first.next;
                    if (last.prev != null) last = last.prev;
                }
                return true;
            }
        }
        

        static void Main(string[] args)
        {
            // Lists here will be hard-coded for the time being.
            // For example, given A = 3 -> 7 -> 3 should return true (i.e. palindrome list), while 3 -> 7 should return false.

            DoublyLinkedList list = new DoublyLinkedList();
            list.appendNode(3);
            list.appendNode(7);
            list.appendNode(3);

            Console.WriteLine($"List 1 is a palindrome: {list.isDLLPalindrome()}.");

            DoublyLinkedList list2 = new DoublyLinkedList();
            list2.appendNode(3);
            list2.appendNode(7);

            Console.WriteLine($"List 2 is a palindrome: {list2.isDLLPalindrome()}.");
        }
    }
}
