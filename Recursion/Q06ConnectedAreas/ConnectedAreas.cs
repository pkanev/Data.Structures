namespace Q06ConnectedAreas
{
    using System;
    using System.Collections.Generic;

    class ConnectedAreas
    {
        private static int numRows;
        private static int numCols;
        private static int size = 0;
        private static SortedSet<Area> areas = new SortedSet<Area>();

        private static void CalculateAreas(char[,] maze)
        {
            numRows = maze.GetLength(0);
            numCols = maze.GetLength(1);

            for (int row = 0; row < numRows; row++)
            {
                for (int col = 0; col < numCols; col++)
                {
                    if (maze[row, col] == ' ')
                    {
                        FindPath(row, col, maze);
                        areas.Add(new Area(row, col, size));
                        size = 0;
                    }
                }
            }

            PrintSolution();
            CleanUp();
        }

        private static void CleanUp()
        {
            size = 0;
            areas = new SortedSet<Area>();
        }

        private static void PrintSolution()
        {
            Console.WriteLine("Total areas found: {0}", areas.Count);
            var index = 1;
            foreach (var area in areas.Reverse())
            {
                Console.WriteLine("Area #{0} at ({1}, {2}), size: {3}", index, area.TopRow, area.LeftCol, area.Size);
                index++;
            }
        }

        static private void FindPath(int row, int col, char[,] maze)
        {
            if (row < 0 || row >= numRows
                || col < 0 || col >= numCols)
            {
                // out of maze
                return;
            }

            if (maze[row, col] != ' ')
            {
                // visited or wall
                return;
            }

            maze[row, col] = 'V';
            size ++;

            FindPath(row - 1, col, maze); // up
            FindPath(row, col + 1, maze); // right
            FindPath(row + 1, col, maze); // down
            FindPath(row, col - 1, maze); // left

        }

        static void Main()
        {
            Console.WriteLine("Solving maze #1: ");
            char[,] maze = new[,]
            {
                {' ', ' ', ' ', '*', ' ', ' ', ' ', '*', ' ',},
                {' ', ' ', ' ', '*', ' ', ' ', ' ', '*', ' ',},
                {' ', ' ', ' ', '*', ' ', ' ', ' ', '*', ' ',},
                {' ', ' ', ' ', ' ', '*', ' ', '*', ' ', ' ',},
            };
            CalculateAreas(maze);

            Console.WriteLine();
            Console.WriteLine("Solving maze #2: ");
            maze = new[,]
            {
                {'*', ' ', ' ', '*', ' ', ' ', ' ', '*', ' ', ' ',},
                {'*', ' ', ' ', '*', ' ', ' ', ' ', '*', ' ', ' ',},
                {'*', ' ', ' ', '*', '*', '*', '*', '*', ' ', ' ',},
                {'*', ' ', ' ', '*', ' ', ' ', ' ', '*', ' ', ' ',},
                {'*', ' ', ' ', '*', ' ', ' ', ' ', '*', ' ', ' ',},
            };
            CalculateAreas(maze);
        }

        private class Area : IComparable<Area>
        {
            public Area(int topRow, int leftCol, int size)
            {
                this.TopRow = topRow;
                this.LeftCol = leftCol;
                this.Size = size;
            }

            public int TopRow { get; set; }
            public int LeftCol { get; set; }
            public int Size { get; set; }

            public int CompareTo(Area other)
            {
                int result = this.Size.CompareTo(other.Size);
                if (result == 0)
                {
                    result = other.TopRow.CompareTo(this.TopRow);
                }
                if (result == 0)
                {
                    result = other.LeftCol.CompareTo(this.LeftCol);
                }
                return result;
            }
        }
    }
}
