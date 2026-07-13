using System;
using System.Collections.Generic;

namespace C_sharp.Daily_Task.Day_8_Exercise
{
    public class _36_Valid_Sudoku
    {
        public class Solution
        {
            public static void Main(string[] args)
            {
                var board = new char[][]
                {
                     new char[] { '5', '3', '.', '.', '7', '.', '.', '.', '.' },
                     new char[] { '6', '.', '.', '1', '9', '5', '.', '.', '.' },
                     new char[] { '.', '9', '8', '.', '.', '.', '.', '6', '.' },
                     new char[] { '8', '.', '.', '.', '6', '.', '.', '.', '3' },
                     new char[] { '4', '.', '.', '8', '.', '3', '.', '.', '1' },
                     new char[] { '7', '.', '.', '.', '2', '.', '.', '.', '6' },
                     new char[] { '.', '6', '.', '.', '.', '.', '2', '8', '.' },
                     new char[] { '.', '.', '.', '4', '1', '9', '.', '.', '5' },
                     new char[] { '.', '.', '.', '.', '8', '.', '.', '7', '9' }
                };
                var result = IsValidSudoku(board);
                Console.WriteLine(result);
            }
            public static bool IsValidSudoku(char[][] board)
            {
                HashSet<char>[] rows = new HashSet<char>[9];
                HashSet<char>[] cols = new HashSet<char>[9];
                HashSet<char>[] boxes = new HashSet<char>[9];
                for (int i = 0; i < 9; i++)
                {
                    rows[i] = new HashSet<char>();
                    cols[i] = new HashSet<char>();
                    boxes[i] = new HashSet<char>();
                }
                for (int r = 0; r < 9; r++)
                {
                    for (int c = 0; c < 9; c++)
                    {
                        char val = board[r][c];
                        if (val == '.')
                            continue;
                        int boxId = (r / 3) * 3 + (c / 3);

                        if (!rows[r].Add(val))
                            return false;
                        if (!cols[c].Add(val))
                            return false;
                        if (!boxes[boxId].Add(val))
                            return false;
                    }
                }
                return true;
            }
        }
    }
}