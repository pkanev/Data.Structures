namespace EightQueens
{
    using System;
    using System.Collections.Generic;

    public class EightQueens
    {
        private const int Size = 8;
        static bool[,] chessBoard = new bool[Size, Size];
        private static int solutionsFound = 0;

        static HashSet<int> attackedRows = new HashSet<int>();
        static HashSet<int> attackedColumns = new HashSet<int>();
        static HashSet<int> attackedLeftDiagonals = new HashSet<int>();
        static HashSet<int> attackedRightDiagonals = new HashSet<int>();

        public static void PutQueens(int row)
        {
            if (row == Size)
            {
                PrintSolution();
            }
            else
            {
                for (int col = 0; col < Size; col++)
                {
                    if (CanPlaceQueen(row, col))
                    {
                        MarkAllAttackedPositions(row, col);
                        PutQueens(row+1);
                        UnmarkAllAttackedPositions(row, col);
                    }
                }
            }
        }

        private static void UnmarkAllAttackedPositions(int row, int col)
        {
            attackedRows.Remove(row);
            attackedColumns.Remove(col);
            attackedLeftDiagonals.Remove(col - row);
            attackedRightDiagonals.Remove(row + col);
            chessBoard[row, col] = false;
        }

        private static void MarkAllAttackedPositions(int row, int col)
        {
            attackedRows.Add(row);
            attackedColumns.Add(col);
            attackedLeftDiagonals.Add(col - row);
            attackedRightDiagonals.Add(row + col);
            chessBoard[row, col] = true;
        }

        private static bool CanPlaceQueen(int row, int col)
        {
            var positionOccupied =
                attackedRows.Contains(row) ||
                attackedColumns.Contains(col) ||
                attackedLeftDiagonals.Contains(col - row) ||
                attackedRightDiagonals.Contains(row + col);
            return !positionOccupied;
        }

        private static void PrintSolution()
        {
            Console.WriteLine(" ---------------------------------");
            for (int row = 0; row < Size; row++)
            {
                Console.Write(" ");
                for (int col = 0; col < Size; col++)
                {
                    if (chessBoard[row, col])
                    {
                        Console.Write("| * ");
                    }
                    else
                    {
                        Console.Write("|   ");
                    }
                }
                Console.WriteLine("|");
                Console.WriteLine(" ---------------------------------");
            }
            solutionsFound ++;
            Console.WriteLine("Solution number: {0}", solutionsFound);
        }
    }
}