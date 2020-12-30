using System;
using System.Collections.Generic;

namespace _100daysCoding
{
    class Program_Day70
    {
        static void Main(string[] args)
        {
            int nID = 5; // max size of the log structure
            orderStructure os = new orderStructure(nID);

            os.record(5);
            os.record(4);
            os.record(6);
            os.record(9);
            os.record(12);
            os.record(90);
            os.record(120);

            Console.WriteLine($"getLast(1) = {os.getLast(1)}");
            Console.WriteLine($"getLast(3) = {os.getLast(3)}");
            Console.WriteLine($"getLast(5) = {os.getLast(5)}");
        }

        public class orderStructure
        {
            private int size;
            private List<int> orderID_list;
            public orderStructure(int n)
            {
                size = n;
                orderID_list = new List<int>();
            }

            public void record(int orderID)
            {
                orderID_list.Add(orderID);
                if (orderID_list.Count > size) orderID_list.RemoveRange(0, orderID_list.Count/size);
            }

            public int getLast(int i)
            {
                return orderID_list[orderID_list.Count - i];
            }
        }
    }
}
