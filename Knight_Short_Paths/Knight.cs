using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knight_Short_Paths
{
    internal class Knight
    {

        // Moves Limits
        static int[,] directions = new int[,] { { 2, 1 }, { 2, -1 }, { -2, 1 }, { -2, -1 }, { 1, 2 }, { 1, -2 }, { -1, 2 }, { -1, -2 } };


        public Knight()
        {
        }



        public static int[,] BFS(int size)
        {
            int[,] board = new int[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    board[i, j] = -1;
                }
            }

            //BFS
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

            return board;

        }



        public static List<Tuple<int, int>> getPathPoints(int[,] board, int size, int x, int y)
        {
            // Find the path points
            Console.WriteLine("Shortest path from (0, 0) to (" + x + ", " + y + "):");
            List<Tuple<int, int>> path = new List<Tuple<int, int>>();
            path.Add(new Tuple<int, int>(x, y));
            int distance = board[x, y];
            while (distance != 0)
            {
                for (int k = 0; k < size; k++)
                {
                    int x1 = x + directions[k, 0];
                    int y1 = y + directions[k, 1];
                    if (x1 >= 0 && x1 < size && y1 >= 0 && y1 < size && board[x1, y1] == distance - 1)

                    {
                        x = x1;
                        y = y1;
                        path.Add(new Tuple<int, int>(x, y));
                        distance = board[x, y];
                        break;
                    }
                }
            }
            path.Reverse();

            return path;
        }




       /* public static int[,] BFS_MultiProccessing(int size)
        {
            int[,] board = new int[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    board[i, j] = -1;
                }
            }

            //BFS
            ConcurrentQueue<Tuple<int, int>> queue = new ConcurrentQueue<Tuple<int, int>>();
            queue.Enqueue(new Tuple<int, int>(0, 0));
            board[0, 0] = 0;

            while (queue.Count > 0)
            {
                int count = queue.Count;
                Parallel.For(0, count, (i) =>
                {
                    if (queue.TryDequeue(out Tuple<int, int> current))
                    {
                        int x = current.Item1;
                        int y = current.Item2;
                        for (int k = 0; k < 8; k++)
                        {
                            int x1 = x + directions[k, 0];
                            int y1 = y + directions[k, 1];
                            if (x1 >= 0 && x1 < size && y1 >= 0 && y1 < size && board[x1, y1] == -1)
                            {
                                queue.Enqueue(new Tuple<int, int>(x1, y1));
                                board[x1, y1] = board[x, y] + 1;
                            }
                        }
                    }
                });
            }

            return board;
        }*/





        public static void CreateImageOutput(List<Tuple<int, int>> path, int size)
        {


            //Get Result String
            string result = stringOutput(size, path);
            // Font Text
            Font font = new Font("Arial", 10, FontStyle.Bold);
            // Get Size
            SizeF textSize = MeasureString(result, font);

            // Create & Draw Image
            Bitmap image = new Bitmap((int)textSize.Width, (int)textSize.Height);
            Graphics graphics = Graphics.FromImage(image);
            graphics.Clear(Color.White);
            Brush brush = new SolidBrush(Color.Blue);
            graphics.DrawString(result, font, brush, 0, 0);


            // Save the image
            image.Save("knight_path.bmp", ImageFormat.Bmp);

            Console.WriteLine("A Representation Of Type Image Can be Found in directory of the project.");

        }

        public static string stringOutput(int size, List<Tuple<int, int>> path)
        {
            string result = "";

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (path.Contains(new Tuple<int, int>(i, j)))
                    result += "1\t";

                    else
                    result += ".\t";

                }
                result += "\n";
            }

            return result;
        }

        private static SizeF MeasureString(string text, Font font)
        {
            using (Graphics graphics = Graphics.FromImage(new Bitmap(1, 1)))
            {
                return graphics.MeasureString(text, font);
            }
        }
    }
}



