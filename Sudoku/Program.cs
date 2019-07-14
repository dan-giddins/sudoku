using System;
using System.Linq;

namespace Sudoku
{
    class Program
    {
        private const bool _debug = true;
        static void Main()
        {
            var SudokuSolver = new SudokuSolver();
            var board = GetBoard(Boards.HardMetro);
            PrettyPrinter.PrettyPrint(board);
            var solvedBoard = SudokuSolver.Solve(board, _debug);
            PrettyPrinter.PrettyPrint(solvedBoard);
            Console.WriteLine(IsSolved(solvedBoard));
            Console.ReadKey();
        }

        private static bool IsSolved(int[,] solvedBoard)
        {
            return !solvedBoard.Cast<int>().Any(x => x == 0);
        }

        private static int[,] GetBoard(Boards boardEnum)
        {
            var board = new int[9, 9];
            switch (boardEnum)
            {
                case Boards.EasyTimes:
                    board[0, 2] = 3;
                    board[0, 5] = 4;
                    board[0, 6] = 9;
                    board[1, 1] = 6;
                    board[2, 3] = 8;
                    board[2, 5] = 7;
                    board[2, 8] = 1;
                    board[3, 0] = 6;
                    board[3, 2] = 1;
                    board[3, 6] = 7;
                    board[3, 8] = 4;
                    board[4, 2] = 8;
                    board[4, 3] = 9;
                    board[5, 0] = 2;
                    board[5, 1] = 5;
                    board[5, 2] = 9;
                    board[5, 4] = 7;
                    board[5, 6] = 6;
                    board[6, 1] = 7;
                    board[6, 2] = 6;
                    board[6, 3] = 5;
                    board[6, 4] = 1;
                    board[6, 5] = 9;
                    board[6, 8] = 2;
                    board[7, 2] = 5;
                    board[7, 3] = 6;
                    board[7, 7] = 1;
                    board[8, 3] = 7;
                    board[8, 5] = 2;
                    break;
                case Boards.HardMetro:
                    board[0, 0] = 3;
                    board[0, 2] = 2;
                    board[0, 5] = 1;
                    board[1, 4] = 7;
                    board[1, 5] = 2;
                    board[1, 6] = 3;
                    board[2, 0] = 7;
                    board[2, 2] = 9;
                    board[2, 7] = 6;
                    board[3, 5] = 3;
                    board[3, 7] = 4;
                    board[3, 8] = 7;
                    board[4, 1] = 5;
                    board[4, 7] = 8;
                    board[5, 0] = 1;
                    board[5, 1] = 3;
                    board[5, 3] = 2;
                    board[6, 1] = 4;
                    board[6, 6] = 6;
                    board[6, 8] = 1;
                    board[7, 2] = 6;
                    board[7, 3] = 1;
                    board[7, 4] = 3;
                    board[8, 3] = 4;
                    board[8, 6] = 7;
                    board[8, 8] = 9;
                    break;
            }
            return board;
        }
    }
}
