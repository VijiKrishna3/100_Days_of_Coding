using System;

namespace _100daysCoding
{
    class Program_Day53
    {
        static void Main(string[] args)
        {
            int[,] matrix = {{1, 2, 3, 4, 5 },
                             {6, 7, 8, 9, 10},
                             {11, 12, 13, 14, 15},
                             {16, 17, 18, 19, 20}};

            transverseSpiral(matrix, 0, matrix.GetLength(0),
                                     0, matrix.GetLength(1));
        }

        static void transverseSpiral(int[,] m, int r, int r2, int c, int c2)
        {
            if (r == r2 || c == c2)
                return;

            for (int x = r; x < c2; ++x)
                Console.Write($"{m[r,x]} ");

            for (int x = r + 1; x < r2; ++x)
                Console.Write($"{m[x, c2 - 1]} ");

            if (r2 - 1 != r)
                for (int x = c2 - 2; x >= c; --x)
                    Console.Write($"{m[r2 - 1,x]} ");

            if (c2 - 1 != c)
                for (int x = r2 - 2; x > r; --x)
                    Console.Write($"{m[x, c]} ");

            transverseSpiral(m, r + 1, r2 - 1, c + 1, c2 - 1);
        }
    }
}
