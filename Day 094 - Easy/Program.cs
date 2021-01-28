using System;

namespace _100daysCoding
{
    class Program_Day94
    {
        static void Main(string[] args)
        {
            int n;
            Console.Write("Enter a number: ");
            int.TryParse(Console.ReadLine(), out n);

            Console.WriteLine($"There are at most {nOnes(n)} 1s in a row .");
        }

        static int nOnes(int n)
        {
            string x = Convert.ToString(n, 2);
            int maxCount = 0, currentCount = 0;
            foreach (char q in x)
                if (q == '1') ++currentCount;
                else { maxCount = (maxCount > currentCount) ? maxCount : currentCount; currentCount = 0; }

            return maxCount;
        }
    }
}
