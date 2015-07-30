using System;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Q03RideTheHorse
{
    class RideTheHorse
    {
        private static int rows;
        private static int cols;
        private static int startRow;
        private static int startCol;
        private static int[,] board;
        private class Cell
        {
            public int Row { get; set; }
            public int Col { get; set; }

            public int Step { get; set; }

            public Cell(int row, int col, int step)
            {
                this.Row = row;
                this.Col = col;
                this.Step = step;
            }
        }
        private static Cell PrepareMatrix()
        {
            rows = int.Parse(Console.ReadLine());
            cols = int.Parse(Console.ReadLine());
            board = new int[rows,cols];
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    board[r, c] = 0;
                }
            }
            startRow = int.Parse(Console.ReadLine());
            startCol = int.Parse(Console.ReadLine());
            return new Cell(startRow, startCol, 1);
        }

        private static void Ride(Cell c)
        {
            Queue<Cell> cells = new Queue<Cell>();
            cells.Enqueue(c);
            while (cells.Count > 0)
            {
                Cell currentCell = cells.Dequeue();
                board[currentCell.Row, currentCell.Col] = currentCell.Step;
                List<Cell> cellsToCheck = new List<Cell>();
                Cell c1 = new Cell(currentCell.Row - 2, currentCell.Col + 1, currentCell.Step + 1);
                cellsToCheck.Add(c1);
                Cell c2 = new Cell(currentCell.Row - 1, currentCell.Col + 2, currentCell.Step + 1);
                cellsToCheck.Add(c2);
                Cell c3 = new Cell(currentCell.Row + 1, currentCell.Col + 2, currentCell.Step + 1);
                cellsToCheck.Add(c3);
                Cell c4 = new Cell(currentCell.Row + 2, currentCell.Col + 1, currentCell.Step + 1);
                cellsToCheck.Add(c4);
                Cell c5 = new Cell(currentCell.Row + 2, currentCell.Col - 1, currentCell.Step + 1);
                cellsToCheck.Add(c5);
                Cell c6 = new Cell(currentCell.Row + 1, currentCell.Col - 2, currentCell.Step + 1);
                cellsToCheck.Add(c6);
                Cell c7 = new Cell(currentCell.Row - 1, currentCell.Col - 2, currentCell.Step + 1);
                cellsToCheck.Add(c7);
                Cell c8 = new Cell(currentCell.Row - 2, currentCell.Col - 1, currentCell.Step + 1);
                cellsToCheck.Add(c8);
                foreach (var cell in cellsToCheck)
                {
                    if (CheckInBounds(cell))
                    {
                        cells.Enqueue(cell);
                    }
                }
            }
        }

        private static bool CheckInBounds(Cell c)
        {
            if (c.Row >= 0 && c.Row < rows &&
                c.Col >= 0 && c.Col < cols &&
                board[c.Row, c.Col] == 0)
            {
                return true;
            }
            return false;
        }

        private static void PrintAnswer()
        {
            Console.WriteLine();
            int colToPrint = cols/2;
            for (int r = 0; r < rows; r++)
            {
                Console.WriteLine(board[r,colToPrint]);
            }
        }
        static void Main()
        {
            Cell start = PrepareMatrix();
            Ride(start);
            PrintAnswer();
        }

        
    }
}
