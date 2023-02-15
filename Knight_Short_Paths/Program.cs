using Knight_Short_Paths;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;

namespace Knight_Short_Path
{
    internal class Program
    {


        static void Main(string[] args)
        {
            //Inputs
            Console.WriteLine("Enter destination position (x y): ");
            int x;
            do
            {
                Console.WriteLine("x=?");
                int.TryParse(Console.ReadLine(), out x);

            } while (x < 0);
            int y;
            do
            {
                Console.WriteLine("y=?");
                int.TryParse(Console.ReadLine(), out y);
            } while (y < 0);


            //The Grid size
            int size = 10;

            //BFS
            int[,] board = Knight.BFS(size);
            // Path (x,y)
            List<Tuple<int, int>> path = Knight.getPathPoints(board, size, x, y);
            Knight.CreateImageOutput(path, size);

            // string Result Format
            string result = Knight.stringOutput(size, path);

            if (size < 11)
            {
                Console.WriteLine(result);
            }
            Console.WriteLine("Shortest Path Points: ");
            foreach (var step in path)
            {
                Console.Write(" (" + step.Item1 + ", " + step.Item2 + ") ");
            }
            Console.ReadLine();


        }
    }
}
