using System;
using System.Collections.Generic;

namespace EightQueens
{
    class Program
    {
        const int N = 5;
        static readonly List<bool[,]> Result = new List<bool[,]>();

        static void Main(string[] args)
        {
            SetQueens(new bool[N, N]);
            Console.WriteLine($"{N}皇后共有{Result.Count}种解法");
            Console.WriteLine();
            for (int c = 0; c < Result.Count; c++)
            {
                Console.WriteLine($"第{c + 1}种：");
                for (int i = 0; i < Result[c].GetLength(0); i++)
                {
                    for (int j = 0; j < Result[c].GetLength(1); j++)
                    {
                        Console.Write(Result[c][i, j] ? "★" : "○");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
            Console.ReadKey(true);
        }

        static void SetQueens(bool[,] chessboard, int row = 0)
        {
            if (row == chessboard.GetLength(0))
            {
                Result.Add((bool[,])chessboard.Clone());
            }
            else
            {
                for (int col = 0; col < chessboard.GetLength(1); col++)
                {
                    chessboard[row, col] = true;
                    if (CheckValid(chessboard, row, col))
                    {
                        SetQueens(chessboard, row + 1);
                    }
                    chessboard[row, col] = false;
                }
            }
        }

        static bool CheckValid(bool[,] chessboard, int row, int col)
        {
            for (int i = 0, j; i < chessboard.GetLength(0); i++)
            {
                if (i != row && chessboard[i, col])
                {
                    return false;
                }
                j = i + col - row;
                if (j >= 0 && j < chessboard.GetLength(1) && j != col && chessboard[i, j])
                {
                    return false;
                }
                j = col + row - i;
                if (j >= 0 && j < chessboard.GetLength(1) && j != col && chessboard[i, j])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
