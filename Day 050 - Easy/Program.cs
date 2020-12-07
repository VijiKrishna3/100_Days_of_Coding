using System;
using System.Linq;

namespace _100daysCoding
{
    class Program_Day50
    {
        static void Main(string[] args)
        {
            char[,] matrix = {{ 'F', 'A', 'C', 'I' },
                              { 'O', 'B', 'Q', 'P' },
                              { 'A', 'N', 'O', 'B' },
                              { 'M', 'A', 'S', 'S' }};

            Console.WriteLine("Input a word: ");
            string w = Console.ReadLine();
            bool found = false;

            // Square matrix
            int sizeOfMatrix = (int)Math.Sqrt(matrix.Length);

            // Check every row and column
            for (int i = 0; i < sizeOfMatrix; ++i)
            {
                string wholeRow = new string(Enumerable.Range(0, sizeOfMatrix).Select(x => matrix[i, x]).ToArray());
                string wholeCol = new string(Enumerable.Range(0, sizeOfMatrix).Select(x => matrix[x, i]).ToArray());

                if (wholeRow.Contains(w) || wholeCol.Contains(w))
                {
                    found = true;
                    break;
                }
            }

            Console.WriteLine($"\nElement can be found: {found}");
        }
    }
}
