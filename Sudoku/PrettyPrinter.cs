using System;

namespace Sudoku
{
    internal static class PrettyPrinter
    {
        public static void PrettyPrint(int[,] board)
        {
            string s = "";
            for (int j = 0; j < board.GetLength(0); j++)
            {
                if (j % 3 == 0)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        s += "+-------";
                    }
                    s += "+\n";
                }
                for (int i = 0; i < board.GetLength(1); i++)
                {
                    if (i % 3 == 0)
                    {
                        s += "| ";
                    }
                    s += $"{board[j, i]} ";
                }
                s += "|\n";
            }
            for (int i = 0; i < 3; i++)
            {
                s += "+-------";
            }
            s += "+\n";
            Console.WriteLine(s);
        }
    }
}