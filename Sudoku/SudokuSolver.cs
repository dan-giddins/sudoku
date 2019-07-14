using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Sudoku
{
    class SudokuSolver
    {
        private int[,] _board;
        private bool _exit;
        private bool _debug;

        public int[,] Solve(int[,] board, bool debug)
        {
            _board = board;
            _debug = debug;
            _exit = false;
            while (!_exit)
            {
                _exit = true;
                if (debug)
                {
                    Console.WriteLine("Checking squares...");
                }
                CheckBySquare();
                if (debug)
                {
                    Console.WriteLine("Checking rows...");
                }
                CheckByRow();
                if (debug)
                {
                    Console.WriteLine("Checking columns...");
                }
                CheckByColumn();
            }
            return _board;
        }

        private void CheckByColumn()
        {
            for (var i = 0; i < 9; i++)
            {
                var numbers = Enumerable.Range(1, 9).ToList();
                var locations = new List<Location>();
                for (var j = 0; j < 9; j++)
                {
                    if (_board[j, i] == 0)
                    {
                        locations.Add(new Location(i, j));
                    }
                    else
                    {
                        numbers.Remove(_board[j, i]);
                    }
                }
                foreach (var n in numbers)
                {
                    var l = FindLocationColumn(n, locations);
                    if (!(l is null))
                    {
                        WriteNumber(n, l);
                    }
                }
            }
        }

        private Location FindLocationColumn(int n, List<Location> locations)
        {
            Location location = null;
            foreach (var l in locations)
            {
                if (!CheckRow(n, l))
                {
                    if (location is null)
                    {
                        location = l;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            return location;
        }

        private bool CheckRow(int n, Location l)
        {
            if (Find(n, l.X, l.Y))
            {
                return true;
            }
            for (var i = 0; i < 9; i++)
            {
                if (_board[l.Y, i] == n)
                {
                    return true;
                }
            }
            return false;
        }

        private void CheckByRow()
        {
            for (var j = 0; j < 9; j++)
            {
                var numbers = Enumerable.Range(1, 9).ToList(); ;
                var locations = new List<Location>();
                for (var i = 0; i < 9; i++)
                {
                    if (_board[j, i] == 0)
                    {
                        locations.Add(new Location(i, j));
                    }
                    else
                    {
                        numbers.Remove(_board[j, i]);
                    }
                }
                foreach (var n in numbers)
                {
                    var l = FindLocationRow(n, locations);
                    if (!(l is null))
                    {
                        WriteNumber(n, l);
                    }
                }
            }
        }

        private Location FindLocationRow(int n, List<Location> locations)
        {
            Location location = null;
            foreach (var l in locations)
            {
                if (!CheckColumn(n, l))
                {
                    if (location is null)
                    {
                        location = l;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            return location;
        }

        private bool CheckColumn(int n, Location l)
        {
            if (Find(n, l.X, l.Y))
            {
                return true;
            }
            for (var j = 0; j < 9; j++)
            {
                if (_board[j, l.X] == n)
                {
                    return true;
                }
            }
            return false;
        }

        private void CheckBySquare()
        {
            for (var n = 1; n < 10; n++)
            {
                for (var j = 0; j < 9; j += 3)
                {
                    for (var i = 0; i < 9; i += 3)
                    {
                        if (!Find(n, i, j))
                        {
                            var l = FindPlace(n, i, j);
                            if (!(l is null))
                            {
                                WriteNumber(n, l);
                            }
                        }
                    }
                }
            }
        }

        private void WriteNumber(int n, Location l)
        {
            _exit = false;
            _board[l.Y, l.X] = n;
            if (_debug)
            {
                Console.WriteLine($"{n} @ [{l.Y}, {l.X}]");
                PrettyPrinter.PrettyPrint(_board);
                Thread.Sleep(1000);
            }
        }

        private Location FindPlace(int n, int i, int j)
        {
            Location location = null;
            for (var l = j; l < j + 3; l++)
            {
                for (var k = i; k < i + 3; k++)
                {
                    if (_board[l, k] == 0 && !FindRowColumn(n, k, l))
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
                if (_board[p, k] == n)
                {
                    return true;
                }
            }
            for (var p = 0; p < 9; p++)
            {
                if (_board[l, p] == n)
                {
                    return true;
                }
            }
            return false;
        }

        private bool Find(int n, int i, int j)
        {
            i = TopLeft(i);
            j = TopLeft(j);
            for (var l = j; l < j + 3; l++)
            {
                for (var k = i; k < i + 3; k++)
                {
                    if (_board[l, k] == n)
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
