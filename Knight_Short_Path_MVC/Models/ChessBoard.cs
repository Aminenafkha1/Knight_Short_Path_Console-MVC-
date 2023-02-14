
using System.Collections.Generic;


namespace Knight_Short_Path_MVC.Models
{
    public class ChessBoard
    {
   
            private int[,] directions = new int[,] { { 2, 1 }, { 2, -1 }, { -2, 1 }, { -2, -1 }, { 1, 2 }, { 1, -2 }, { -1, 2 }, { -1, -2 } };
            private int size = 10;
            private int[,] board;

            public ChessBoard()
            {
                board = new int[size, size];
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        board[i, j] = -1;
                    }
                }
            }

        public List<int[]> GetShortestPath(int x, int y)
            {
                Queue<Tuple<int, int>> queue = new Queue<Tuple<int, int>>();
                queue.Enqueue(new Tuple<int, int>(0, 0));
                board[0, 0] = 0;

                while (queue.Count > 0)
                {
                    var current = queue.Dequeue();
                    int i = current.Item1;
                    int j = current.Item2;
                    for (int k = 0; k < 8; k++)
                    {
                        int x1 = i + directions[k, 0];
                        int y1 = j + directions[k, 1];
                        if (x1 >= 0 && x1 < size && y1 >= 0 && y1 < size && board[x1, y1] == -1)
                        {
                            queue.Enqueue(new Tuple<int, int>(x1, y1));
                            board[x1, y1] = board[i, j] + 1;
                        }
                    }
                }

                List<int[]> path = new List<int[]>();
                path.Add(new int[] { x, y });
                int distance = board[x, y];
                while (distance != 0)
                {
                    for (int k = 0; k < 8; k++)
                    {
                        int x1 = x + directions[k, 0];
                        int y1 = y + directions[k, 1];
                        if (x1 >= 0 && x1 < size && y1 >= 0 && y1 < size && board[x1, y1] == distance - 1)

                        {
                            x = x1;
                            y = y1;
                            path.Add(new int[] { x, y });
                            distance = board[x, y];
                            break;
                        }
                    }
                }
                path.Reverse();


                return path;
            }
        
    }
}







/*
using System;
using System.Collections.Generic;


namespace Knight_Short_Path_MVC.Models
{
    public class ChessBoard
    {
        private static int[,] moves = new int[,] { { 2, 1 }, { 1, 2 }, { -1, 2 }, { -2, 1 }, { -2, -1 }, { -1, -2 }, { 1, -2 }, { 2, -1 } };
        private static int rows = 8;
        private static int columns = 8;

        public static List<int[]> GetShortestPath(int[] destination)
        {
            int[,] grid = new int[rows, columns];
            Queue<int[]> queue = new Queue<int[]>();

            queue.Enqueue(new int[] { 0, 0, 0 });
            grid[0, 0] = 1;

            while (queue.Count > 0)
            {
                int[] move = queue.Dequeue();

                if (move[0] == destination[0] && move[1] == destination[1])
                {
                    return BuildPath(move, grid);
                }

                for (int i = 0; i < 8; i++)
                {
                    int x = move[0] + moves[i, 0];
                    int y = move[1] + moves[i, 1];

                    if (IsValidMove(x, y, rows, columns) && grid[x, y] == 0)
                    {
                        grid[x, y] = move[2] + 1;
                        queue.Enqueue(new int[] { x, y, move[2] + 1 });
                    }
                }
            }

            return null;
        }

        public static bool IsValidMove(int x, int y, int rows, int columns)
        {
            return x >= 0 && x < rows && y >= 0 && y < columns;
        }

        public static List<int[]> BuildPath(int[] move, int[,] grid)
        {
            List<int[]> path = new List<int[]>();
            int x = move[0];
            int y = move[1];
            int steps = move[2];

            while (steps > 0)
            {
                path.Add(new int[] { x, y });

                for (int i = 0; i < 8; i++)
                {
                    int a = x + moves[i, 0];
                    int b = y + moves[i, 1];

                    if (IsValidMove(a, b, rows, columns) && grid[a, b] == steps)
                    {
                        x = a;
                        y = b;
                        steps--;
                        break;
                    }
                }
            }

            path.Add(new int[] { 0, 0 });
            path.Reverse();

            return path;
        }
    }

}
*/
