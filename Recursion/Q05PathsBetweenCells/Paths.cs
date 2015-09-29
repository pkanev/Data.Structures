namespace Q05PathsBetweenCells
{
    using System;
    using System.Collections.Generic;

    class Paths
    {
        private static int numSolutions;
        private static int numRows;
        private static int numCols;
        private static List<char> path;

        private static void SolveMaze(char[,] maze)
        {
            numSolutions = 0;

            path = new List<char>();

            numRows = maze.GetLength(0);
            numCols = maze.GetLength(1);

            int[] coordinates = FindStart(maze);
            if (coordinates == null)
            {
                Console.WriteLine("There is no start point!");
                return;
            }
            int rowStart = coordinates[0];
            int colStart = coordinates[1];
            FindPath(rowStart, colStart, 'S', maze);
            Console.WriteLine("Total paths found: {0}", numSolutions);

        }

        private static int[] FindStart(char[,] maze)
        {
            for (int i = 0; i < numRows; i++)
            {
                for (int j = 0; j < numCols; j++)
                {
                    if (maze[i, j] == 'S')
                    {
                        maze[i, j] = ' ';
                        return new int[] { i, j };
                    }
                }
            }
            return null;
        }

        static private void FindPath(int row, int col, char dir, char[,] maze)
        {
            if (row < 0 || row >= numRows
                || col < 0 || col >= numCols)
            {
                // out of maze
                return;
            }

            if (maze[row, col] == 'e')
            {
                path.Add(dir);
                numSolutions ++;
                PrintPath();
                path.RemoveAt(path.Count - 1);
            }

            if (maze[row, col] != ' ')
            {
                // visited or wall
                return;
            }
            
            maze[row, col] = dir;
            if (dir != 'S')
            {
                path.Add(dir);
            }

            FindPath(row - 1, col, 'U', maze); // up
            FindPath(row, col + 1, 'R', maze); // right
            FindPath(row + 1, col, 'D', maze); // down
            FindPath(row, col - 1, 'L', maze); // left

            maze[row, col] = ' ';
            if (dir != 'S')
            {
                path.RemoveAt(path.Count - 1);
            }
        }

        private static void PrintPath()
        {
            Console.WriteLine(string.Join("", path));
        }


        static void Main()
        {
            Console.WriteLine("Solving maze #1: ");
            char[,] maze = new [,]
            {
                {'S', ' ', ' ', ' ',},
                {' ', '*', '*', ' ',},
                {' ', '*', '*', ' ',},
                {' ', '*', 'e', ' ',},
                {' ', ' ', ' ', ' ',},
            };
            SolveMaze(maze);

            Console.WriteLine();
            Console.WriteLine("Solving maze #2: ");
            maze = new[,]
            {
                {'S', ' ', ' ', ' ', ' ', ' ',},
                {' ', '*', '*', ' ', '*', ' ',},
                {' ', '*', '*', ' ', '*', ' ',},
                {' ', '*', 'e', ' ', ' ', ' ',},
                {' ', ' ', ' ', '*', ' ', ' ',},
            };
            SolveMaze(maze);
        }
    }
}
