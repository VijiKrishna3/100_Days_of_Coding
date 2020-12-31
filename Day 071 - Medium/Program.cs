using System;

namespace _100daysCoding
{
    class Program_Day71
    {
        static void Main(string[] args)
        {
            BitArray bArr = new BitArray(7);
            // The array will be looked in reverse
            // i.e. the index 0 is the LSD -> index 9 will be the MSD.
            bArr.set(0, 1);
            bArr.set(1, 0);
            bArr.set(2, 1);
            bArr.set(3, 0);
            bArr.set(4, 0);
            bArr.set(5, 0);
            bArr.set(6, 1);

            Console.WriteLine($"Value at index 6: {bArr.get(6)}");
            Console.WriteLine($"The BitArray represents number: {bArr.getArrValue()}");
        }

        public class BitArray
        {
            private bool[] arr;
            public BitArray(int size)
            {
                arr = new bool[size];
            }

            public void set(int idx, int val)
            {
                arr[idx] = Convert.ToBoolean(val);
            }

            public int get(int idx)
            {
                return (arr[idx]) ? 1 : 0;
            }

            public int getArrValue()
            {
                string bits = "";
                for (int i = arr.Length - 1; i >= 0; --i)
                    bits += (arr[i]) ? "1" : "0";

                return Convert.ToInt32(bits, 2);
            }
        }
    }
}