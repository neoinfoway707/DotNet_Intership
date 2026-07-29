using System;

namespace C_sharp.Daily_Task.Day_8_Exercise
{
    public class _48_Rotate_Image
    {
        public class Solution
        {
            public static void Main(string[] args)
            {
                var matrix = new int[][]
                {
                    new int[]{1,2,3},
                    new int[]{4,5,6},
                    new int[]{7,8,9 }
                };

                Rotate(matrix);

                foreach (var row in matrix)
                {
                    Console.WriteLine(string.Join(" ", row));
                }
            }
            public static void Rotate(int[][] matrix)
            {
                var n = matrix.Length;
                for (int layer = 0; layer < n / 2; layer++)
                {
                    int left = layer;
                    int right = n - 1 - layer;
                    for (int i = left; i < right; i++)
                    {
                        int offset = i - left;

                        int top = matrix[left][i];
                        matrix[left][i] = matrix[right - offset][left];
                        matrix[right - offset][left] = matrix[right][right - offset];
                        matrix[right][right - offset] = matrix[i][right];
                        matrix[i][right] = top;
                    }
                }
            }
        }
    }
}