using System;

namespace _100daysCoding
{
    class Program_Day62
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input a string: ");
            var ins = Console.ReadLine();

            char currentChar = ins[0];
            int currentCount = 0;
            string reportAnalysis = "";

            for (int i = 0; i < ins.Length; ++i)
            {
                if (ins[i] == currentChar) ++currentCount;
                else
                {
                    reportAnalysis += Convert.ToString(currentCount) + currentChar;
                    currentCount = 1;
                    currentChar = ins[i];
                }
            }

            reportAnalysis += Convert.ToString(currentCount) + currentChar;

            Console.WriteLine($"{reportAnalysis}");
        }
    }
}
