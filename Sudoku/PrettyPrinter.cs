using System;

namespace Sudoku
{
    internal static class PrettyPrinter
    {
        public static void PrettyPrint(int[,] board)
        {
            for (int j = 0; j < board.GetLength(0); j++)
            {
                if (j % 3 == 0)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        Console.Write("+-------");
                    }
                    Console.WriteLine("+");
                }
                for (int i = 0; i < board.GetLength(1); i++)
                {
                    if (i % 3 == 0)
                    {
                        Console.Write("| ");
                    }
                    Console.Write($"{board[j, i]} ");
                }
                Console.WriteLine("|");
            }
            for (int i = 0; i < 3; i++)
            {
                Console.Write("+-------");
            }
            Console.WriteLine("+");
            Console.WriteLine();
        }
    }
}