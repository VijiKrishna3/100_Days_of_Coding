using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Priority_Queue;

namespace Day_14___Medium
{
    class Program
    {
        static void Main(string[] args)
        {
            NewStack newStack = new NewStack();

            // Testing 1, 2, 3
            newStack.Push(1);
            newStack.Push(2);
            newStack.Push(3);

            Console.WriteLine($"{newStack.Pop()} ---> {newStack.Top()}");
            Console.WriteLine($"{newStack.Pop()} ---> {newStack.Top()}");
            Console.WriteLine($"{newStack.Pop()} ---> {newStack.Top()}");
            Console.ReadLine();
        }
    }

    public class NewStack
    {
        SimplePriorityQueue<NewElem> pq;

        int level;
        public NewStack()
        {
            pq = new SimplePriorityQueue<NewElem>();
            level = 0;
        }

        public void Push(int data)
        {
            pq.Enqueue(new NewElem(pq.Count, data), level);
            ++level;
        }

        public int Pop()
        {
            if (level == 0) return 0;
            --level;
            return pq.First.data;
        }

        public int Top()
        {
            pq.Dequeue();
            if (pq.Count == 0) return 0;
            else return pq.First.data;
            
        }
    }

    public class NewElem
    {
        public int key, data;
        public NewElem(int key, int data)
        {
            this.key = key;
            this.data = data;
        }
    }
}
