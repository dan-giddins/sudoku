using System;
using System.Collections.Generic;
using System.Text;

namespace Sudoku
{
    class SudokuSolver
    {
        private int[][] _board;
        private bool _exit;

        public int[][] Solve(int[][] board)
        {
            _board = board;
            _exit = false;
            while (!_exit)
            {
                CheckBySquare();
                CheckByRow();
                CheckByColumn();
            }
            return _board;
        }

        private void CheckBySquare()
        {
            for (var n = 1; n < 10; n++)
            {
                for (var j = 0; j < 9; j = j + 3)
                {
                    for (var i = 0; i < 9; i = i + 3)
                    {
                        if (!Find(n, i, j))
                        {
                            var l = FindPlace(n, i, j);
                            if (l is null)
                            {
                                WriteNumber(n, l);
                            }
                        }
                    }
                }
            }
        }

        private Location FindPlace(int n, int i, int j)
        {
            Location location = null;
            for (var l = j; l < j + 3; l++)
            {
                for (var k = i; k < i + 3; k++)
                {
                    if (_board[l][k] == 0 && !FindRowColumn(n, k, l))
                    {
                        if (!(location is null))
                        {
                            return null;
                        }
                        location = new Location(k, l);
                    }
                }
            }
            return location;
        }

        private bool FindRowColumn(int n, int k, int l)
        {
            for (var p = 0; p < 9; p++)
            {

            }
        if b[p][k] == n:
			return True

    for p in range(9):

        if b[l][p] == n:
			return True

    return False
        }

        private bool Find(int n, int i, int j)
        {
            i = TopLeft(i);
            j = TopLeft(j);
            for (var l = j; l < j + 3; l++)
            {
                for (var k = i; k < i + 3; k++)
                {
                    if (_board[l][k] == n)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private int TopLeft(int x)
        {
            return x - (x % 3);
        }
    }
}
