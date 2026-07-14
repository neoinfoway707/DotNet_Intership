using System;

namespace C_sharp.Daily_Task.Day_8_Exercise
{
    public class _37_Sudoku_Solver
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
                SolveSudoku(board);
                for (int r = 0; r < 9; r++)
                {
                    if (r % 3 == 0)
                        Console.WriteLine("-------------------------");
                    for (int c = 0; c < 9; c++)
                    {
                        if (c % 3 == 0)
                            Console.Write("| ");
                        Console.Write(board[r][c] + " ");
                    }
                    Console.WriteLine("|");
                }
                Console.WriteLine("-------------------------");

            }
            public static void SolveSudoku(char[][] board)
            {
                Solve(board);
            }
            private static bool Solve(char[][] board)
            {
                for (int r = 0; r < 9; r++)
                {
                    for (int c = 0; c < 9; c++)
                    {
                        if (board[r][c] == '.')
                        {
                            for (char digit = '1'; digit <= '9'; digit++)
                            {
                                if (IsValid(board, r, c, digit))
                                {
                                    board[r][c] = digit;

                                    if (Solve(board))
                                        return true;

                                    board[r][c] = '.';
                                }
                            }
                            return false;
                        }
                    }
                }
                return true;
            }
            private static bool IsValid(char[][] board, int row, int col, char digit)
            {
                for (int i = 0; i < 9; i++)
                {
                    if (board[row][i] == digit) return false;
                    if (board[i][col] == digit) return false;
                    int boxRow = 3 * (row / 3) + i / 3;
                    int boxCol = 3 * (col / 3) + i % 3;
                    if (board[boxRow][boxCol] == digit) return false;
                }
                return true;
            }
        }
    }
}