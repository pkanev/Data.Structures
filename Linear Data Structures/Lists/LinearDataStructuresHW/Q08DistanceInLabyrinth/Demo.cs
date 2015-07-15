using System;
using System.Collections.Generic;

namespace Q08DistanceInLabyrinth
{
    class Demo
    {   
        public static void FindDistance(string[,] maze)
        {
            List<Cell> markedCells = new List<Cell>();
            Queue<Cell> cellQueue = new Queue<Cell>();
            string[,] outputMaze = new string[maze.GetLength(0), maze.GetLength(1)];
            Cell start = FindStart(maze);
            markedCells.Add(start);
            cellQueue.Enqueue(start);

            while (cellQueue.Count > 0)
            {
                Cell currentCell = cellQueue.Dequeue();

                List<Cell> nextLevelCells = new List<Cell>()
                {
                    new Cell (currentCell.RowCoord - 1, currentCell.ColCoord), //left
                    new Cell(currentCell.RowCoord + 1, currentCell.ColCoord), //right
                    new Cell(currentCell.RowCoord, currentCell.ColCoord - 1), //up
                    new Cell(currentCell.RowCoord, currentCell.ColCoord + 1), //down
                };
                foreach (Cell cell in nextLevelCells)
                {
                    if ((cell.RowCoord >= 0) && (cell.ColCoord >= 0) &&
                    (cell.RowCoord < maze.GetLength(0)) &&
                    (cell.ColCoord < maze.GetLength(1)) &&
                    (maze[cell.RowCoord, cell.ColCoord] == "0"))
                    {
                        cell.Step = currentCell.Step + 1;
                        markedCells.Add(cell);
                        cellQueue.Enqueue(cell);
                        maze[cell.RowCoord, cell.ColCoord] = "visited";
                    }
                }
            }

            PrintMaze(markedCells, maze, outputMaze);
        }
        
        private static Cell FindStart(string[,] maze)
        {
            Cell start = null;
            for (int row = 0; row < maze.GetLength(0); row++)
            {
                for (int col = 0; col < maze.GetLength(1); col++)
                {
                    if (maze[row, col] == "S")
                    {
                        start = new Cell(rowCoord: row, colCoord: col, step: 0);
                        return start;
                    }
                }
            }
            Console.WriteLine("There is no starting cell!");
            return start;
        }

        private static void PrintMaze(List<Cell> cells, string[,] orignialMaze, string[,] outputmaze)
        {
            foreach (var c in cells)
            {
                outputmaze[c.RowCoord, c.ColCoord] = string.Format("{0}", c.Step);
            }
            for (int row = 0; row < orignialMaze.GetLength(0); row++)
            {
                for (int col = 0; col < orignialMaze.GetLength(1); col++)
                {
                    if (orignialMaze[row, col] == "X")
                    {
                        outputmaze[row, col] = "X";
                    }
                }
            }
            Console.WriteLine(new String('-', outputmaze.GetLength(0) * 5 + 1));
            for (int row = 0; row < outputmaze.GetLength(0); row++)
            {
                Console.Write("|");
                for (int col = 0; col < outputmaze.GetLength(1); col++)
                {

                    if (outputmaze[row, col] == null)
                    {
                        outputmaze[row, col] = "U";
                    }
                    Console.Write("{0, 3} |", outputmaze[row, col]);
                }
                Console.WriteLine();
                Console.WriteLine(new String('-', outputmaze.GetLength(0) * 5 + 1));
            }
        }
        static void Main()
        {
            string[,] maze =
            {
                {"0", "0", "0", "X", "0", "X"},
                {"0", "X", "0", "X", "0", "X"},
                {"0", "S", "X", "0", "X", "0"},
                {"0", "X", "0", "0", "0", "0"},
                {"0", "0", "0", "X", "X", "0"},
                {"0", "0", "0", "X", "0", "X"}
            };
            FindDistance(maze);
            Console.WriteLine();
        }
    }
}
